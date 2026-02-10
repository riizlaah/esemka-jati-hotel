package ejh.id.minibar

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.KeyboardArrowDown
import androidx.compose.material3.Button
import androidx.compose.material3.DropdownMenu
import androidx.compose.material3.DropdownMenuItem
import androidx.compose.material3.Icon
import androidx.compose.material3.RadioButton
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.getValue
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.RectangleShape
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.em
import androidx.core.text.isDigitsOnly
import ejh.id.minibar.ui.theme.DodgerBlue
import ejh.id.minibar.ui.theme.EJHMiniBarTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            EJHMiniBarTheme {
                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    Minibar(modifier = Modifier.padding(innerPadding))
                }
            }
        }
    }
}

@Composable
fun Minibar(modifier: Modifier) {
    // rooms
    var rNumExpanded by remember { mutableStateOf(false) }
    var roomName by remember { mutableStateOf("") }
    var selectedRoom by remember { mutableStateOf<Room?>(null) }
    // food & drinks
    var fdExpanded by remember { mutableStateOf(false) }
    var selectedFD by remember {mutableStateOf<FD?>(null)}
    var FDName by remember { mutableStateOf("") }
    // others
    var quantity by remember {mutableStateOf("1")}
    var price by remember {mutableStateOf("")}
    var subtotal by remember {mutableStateOf("")}
    var isFood by remember { mutableStateOf(true) }
    var rooms = remember { listOf<Room>() }
    var fds = remember { listOf<FD>() }
    var filteredFDs = if(isFood) {
        fds.filter { it.type == "F" }
    } else {
        fds.filter { it.type == "D" }
    }
    LaunchedEffect(Unit) {
        rooms = HttpClient.getRooms()
        fds = HttpClient.getFDs()
    }
    LaunchedEffect(quantity, price) {
        if(quantity.isNotEmpty() && price.isNotEmpty()) {
            val qty = quantity.toIntOrNull() ?: 1
            val prc = price.toIntOrNull() ?: 0
            subtotal = (qty * prc).toString()
        }
    }
    Column {
        Row(Modifier.fillMaxWidth().background(DodgerBlue).padding(12.dp)) {
            Text("LKS-SMK Jatim Mini Bar", fontSize = 3.em, color = Color.White, fontWeight = FontWeight.Bold)
        }
        Column(Modifier.padding(12.dp), verticalArrangement = Arrangement.spacedBy(16.dp)) {
            Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.spacedBy(10.dp)) {
                Text("Room Number")
                Box {
                    Button({
                        rNumExpanded = true
                           println("wtf")}, shape = RectangleShape) {
                        Text(roomName)
                        Icon(Icons.Default.KeyboardArrowDown, "ArrowDown")
                    }
                    DropdownMenu(expanded = rNumExpanded, {rNumExpanded = false}) {
                        rooms.forEach { room ->
                            DropdownMenuItem(onClick = {
                                rNumExpanded = false
                                selectedRoom = room
                                roomName = room.number
                            }, text = {Text(room.number)
                            })
                        }
                    }
                }
            }
            Text("Type")
            Column {
                Row(verticalAlignment = Alignment.CenterVertically) {
                    RadioButton(isFood, onClick = {})
                    Text("Food")
                }
                Row(verticalAlignment = Alignment.CenterVertically) {
                    RadioButton(!isFood, onClick = {})
                    Text("Drink")
                }
            }
            Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.spacedBy(8.dp)) {
                Text("Item : ")
                Box {
                    TextButton(onClick = {fdExpanded = true}) {
                        Text(FDName)
                        Icon(Icons.Default.KeyboardArrowDown, "ArrowDown")
                    }
                    DropdownMenu(expanded = fdExpanded, {fdExpanded = false}) {
                        for(fd in fds) {
                            DropdownMenuItem(onClick = {
                                fdExpanded = false
                                selectedFD = fd
                                FDName = fd.name
                                price = fd.price.toString()
                                isFood = fd.type == "F"
                            }, text = {
                                Text(fd.name)
                            })
                        }
                    }
                }
            }
            Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.spacedBy(8.dp)) {
                Text("Price : ")
                TextField(value = price, readOnly = true, onValueChange = {str:String -> price = str}, modifier = maxW())
            }
            Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.spacedBy(8.dp)) {
                Text("Quantity : ")
                TextField(value = quantity, onValueChange = {str:String ->
                    if(str.isBlank()) return@TextField
                    if(!str.isDigitsOnly()) return@TextField
                    quantity = str
                    }, keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number), modifier = maxW())
            }
            Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.spacedBy(8.dp)) {
                Text("Sub total : ")
                TextField(value = subtotal, readOnly = true, onValueChange = {str:String -> subtotal = str}, modifier = maxW())
            }
            Button(onClick = {}, modifier = maxW(), shape = RoundedCornerShape(8.dp)) {
                Text("Submit")
            }
        }

    }
}

@Preview(showBackground = true)
@Composable
fun MinibarPreview() {
    Minibar(Modifier.padding(8.dp))
}