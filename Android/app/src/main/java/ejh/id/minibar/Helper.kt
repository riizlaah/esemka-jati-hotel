package ejh.id.minibar

import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.ui.Modifier
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.coroutineScope
import kotlinx.coroutines.withContext
import org.json.JSONArray
import java.net.HttpURLConnection
import java.net.URL

fun maxW(): Modifier {
    return Modifier.fillMaxWidth()
}

data class HttpRequest (
    val url: String,
    val method: String = "GET",
    val headers: Map<String, String> = emptyMap(),
    val body: String? = null,
    val timeout: Int = 10000
)

data class HttpResponse (
    val statusCode: Int,
    val body: String? = null,
    val headers: Map<String, List<String>> = emptyMap(),
    val errors: String? = null
)

object HttpClient {
    const val addr = "http://10.0.2.2:3000/"
    suspend fun send(req: HttpRequest): HttpResponse {
        val conn = URL(req.url).openConnection() as HttpURLConnection
        return try {
            conn.requestMethod = req.method
            conn.connectTimeout = req.timeout
            conn.readTimeout = req.timeout
            req.headers.forEach { (key, value) -> conn.setRequestProperty(key, value) }
            if(req.body != null && req.method in listOf("POST", "PUT", "PATCH")) {
                conn.doOutput = true
                conn.getOutputStream().use {it.write(req.body.toByteArray())}
            }
            println("connecting...")
            conn.connect()
            val stat = conn.responseCode
            println("connected: $stat ...")
            val respBody = if(stat in 200..299) {
                conn.getInputStream().bufferedReader().use {it.readText()}
            } else {
                conn.errorStream?.bufferedReader()?.use {it.readText()}
            }
            HttpResponse(
                statusCode = stat,
                body = respBody,
                headers = conn.headerFields
            )
        } catch (e: Exception) {
            HttpResponse(
                statusCode = -1,
                body = null,
                errors = e.message ?: "Network Error"
            )
        } finally {
            conn.disconnect()
        }
    }
    suspend fun getFDs(): List<FD> {
        val data = withContext(Dispatchers.IO) { send(HttpRequest(addr + "fds")).body }
        val res = JSONArray(data)
        val fds = mutableListOf<FD>()
        for(i in 0 until res.length()) {
            val obj = res.getJSONObject(i)
            fds.add(FD(
                obj.getString("id").toInt(),
                obj.getString("name"),
                obj.getString("type"),
                obj.getInt("price")
                ))
        }
        return fds
    }
    suspend fun getRooms(): List<Room> {
        val data = withContext(Dispatchers.IO) {send(HttpRequest(addr + "rooms"))}
        val res = JSONArray(data.body)
        val rooms = mutableListOf<Room>()
        for(i in 0 until res.length()) {
            val obj = res.getJSONObject(i)
            rooms.add(Room(obj.getString("id").toInt(), obj.getString("number")))
        }
        return rooms
    }
    suspend fun sendReq(FDId: Int, roomId: Int, quantity: Int, totalPrice: Int): Int {
        val body = """{"fdId": "$FDId", "roomId": "$roomId", "quantity": $quantity, "totalPrice": $totalPrice}"""
        return withContext(Dispatchers.IO) { send(HttpRequest(addr + "fd_requests", body = body)).statusCode }
    }
}

data class Room(
    val id: Int,
    val number: String
)
data class FD(
    val id: Int,
    val name: String,
    val type: String,
    val price: Int,
)



//
//object JSON {
//    fun parseValue(json: String): Any? {
//        val trimmed = json.trim()
//        return when {
//            trimmed.startsWith('{') -> parseObject(trimmed.substring(1, trimmed.length - 1))
//            trimmed.startsWith('[') -> parseArray(trimmed.substring(1, trimmed.length - 1))
//            trimmed.startsWith('"') -> trimmed.substring(1, trimmed.length - 1)
//            trimmed == "true" -> true
//            trimmed == "false" -> false
//            trimmed == "null" -> null
//            trimmed.contains('.') -> trimmed.toDoubleOrNull()
//            else -> trimmed.toIntOrNull() ?: trimmed.toLongOrNull()
//        }
//    }
//    fun parseArray(json: String): Any {
//        return json.split(',').map { parseValue(it.trim()) }
//    }
//    fun parseObject(json: String): Map<String, Any?> {
//        val trimmed = json.trim()
//        val result = mutableMapOf<String, Any?>()
//        var i = 0
//        var key = ""
//        var inString = false
//        while(i < json.length) {
//            when(json[i]) {
//                '"' -> inString = !inString
//                ':' -> if(!inString) {
//                    key = json.substring(0, 1).trim('"', ' ')
//                    val value = parseValue(json.substring(i + 1))
//                    result[key] = value
//                }
//
//            }
//            i++
//        }
//        return result
//    }
//}