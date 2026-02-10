package nr.dev.ejhminibar

import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import org.json.JSONArray
import java.net.HttpURLConnection
import java.net.URL

data class HttpRequest(
    val url: String,
    val method: String = "GET",
    val body: String? = null,
    val headers: Map<String, String> = emptyMap(),
    val timeout: Int = 10000
)
data class HttpResponse(
    val code: Int,
    val body: String?,
    val headers: Map<String, List<String>> = emptyMap(),
    val errors: String? = null
)
data class Room(
    val id: Int,
    val number: String
)
data class FD(
    val id: Int,
    val name: String,
    val type: String,
    val price: Int
)

object HttpClient {
    const val address = "http://10.0.2.2:3000"
    suspend fun send(req: HttpRequest): HttpResponse {
        val conn = URL(req.url).openConnection() as HttpURLConnection
        return try {
            conn.requestMethod = req.method
            conn.readTimeout = req.timeout
            conn.connectTimeout = req.timeout
            req.headers.forEach { (k, v) -> conn.setRequestProperty(k, v) }
            if(req.method in listOf("POST", "PUT", "PATCH") && req.body != null) {
                conn.getOutputStream().buffered().use { it.write(req.body.toByteArray()) }
            }
            conn.connect()
            val status = conn.responseCode
            val body = if(status in 200..299) {
                conn.getInputStream().bufferedReader().use {it.readText()}
            } else {
                conn.errorStream?.bufferedReader()?.use {it.readText()}
            }
            HttpResponse(
                code = status,
                body = body,
                headers = conn.headerFields
            )
        } catch(e: Exception) {
            HttpResponse(
                code = -1,
                body = null,
                errors = e.message ?: "Network Error"
            )
        } finally {
            conn.disconnect()
        }
    }
    suspend fun getRooms(): List<Room> {
        val res = withContext(Dispatchers.IO) {
            send(HttpRequest(address + "/rooms"))
        }
//        println(res.errors)
        val arr = JSONArray(res.body)
        val datas = mutableListOf<Room>()
        for(i in 0 until arr.length()) {
            val obj = arr.getJSONObject(i)
            datas.add(Room(
                obj.getString("id").toInt(),
                obj.getString("number")
            ))
        }
        return datas
    }
    suspend fun getFDs(): List<FD> {
        val res = withContext(Dispatchers.IO) {
            send(HttpRequest(address + "/fds"))
        }
        val arr = JSONArray(res.body)
        val datas = mutableListOf<FD>()
        for(i in 0 until arr.length()) {
            val obj = arr.getJSONObject(i)
            datas.add(FD(
                obj.getString("id").toInt(),
                obj.getString("name"),
                obj.getString("type"),
                obj.getInt("price")
            ))
        }
        return datas
    }
}