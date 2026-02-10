package nr.dev.ejhminibar

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ArrowDropDown
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
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.em
import androidx.core.text.isDigitsOnly
import nr.dev.ejhminibar.ui.theme.DodgerBlue
import nr.dev.ejhminibar.ui.theme.EJHMiniBarTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            EJHMiniBarTheme {
                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    Minibar(Modifier.padding(innerPadding))
                }
            }
        }
    }
}

@Composable
fun Minibar(modifier: Modifier) {
    // rooms
    var rNumExpanded by remember { mutableStateOf(false) }
    var selectedRoom by remember { mutableStateOf<Room?>(null) }
    var roomNumber by remember { mutableStateOf("Select Room") }
    // fds
    var fdExpanded by remember { mutableStateOf(false) }
    var selectedFD by remember { mutableStateOf<FD?>(null) }
    var fdName by remember { mutableStateOf("Select Item") }
    var fdPrice by remember { mutableStateOf("") }
    // others
    var isFood by remember { mutableStateOf(true) }
    var subtotal by remember { mutableStateOf("") }
    var quantity by remember { mutableStateOf("1") }
    var rooms by remember { mutableStateOf(listOf<Room>()) }
    var fds by remember { mutableStateOf(listOf<FD>()) }
    var filteredFDs by remember { mutableStateOf(listOf<FD>()) }

    fun filterFDs() {
        filteredFDs = if(isFood) {
            fds.filter { it.type == "F" }
        } else {
            fds.filter { it.type == "D" }
        }
        selectedFD = null
        println(fds.count())
        fdExpanded = false
        fdName = "Select Item"
        fdPrice = "0"
    }

    fun calculateSubtotal() {
        if(quantity.isNotEmpty() && fdPrice.isNotEmpty()) {
            val qty = quantity.toIntOrNull() ?: 1
            val prc = fdPrice.toIntOrNull() ?: 0
            subtotal = (qty * prc).toString()
        }
    }

    LaunchedEffect(Unit) {
        if(rooms.isEmpty()) {
            rooms = HttpClient.getRooms()
            fds = HttpClient.getFDs()
            filterFDs()
        }
    }

    LaunchedEffect(quantity, subtotal) {
        calculateSubtotal()
    }

    LaunchedEffect(isFood) {
        filterFDs()
    }

    Column(modifier) {
        Box(modifier.fillMaxWidth()
            .background(DodgerBlue)
            .padding(18.dp)) {
            Text("LKS Esemka Jati Hotel Mini Bar", fontSize = 5.em, fontWeight = FontWeight.Bold, color = Color.White)
        }
        Column(
            Modifier.padding(12.dp),
            verticalArrangement = Arrangement.spacedBy(12.dp)) {
            Spacer(modifier.height(75.dp))
            CenteredRow {
                Text("Room Number :")
                Box {
                    TextButton(onClick = {
                        rNumExpanded = !rNumExpanded
                    }) {
                        Text(roomNumber)
                        Icon(Icons.Default.ArrowDropDown, "Arrow Dropdown")
                    }
                    DropdownMenu(
                        expanded = rNumExpanded,
                        onDismissRequest = {rNumExpanded = false}
                    ) {
                        rooms.forEach { room ->
                            DropdownMenuItem(
                                text = {Text(room.number)},
                                onClick = {
                                    selectedRoom = room
                                    roomNumber = room.number
                                    rNumExpanded = false
                                }
                            )
                        }
                    }
                }
            }
            Column {
                CenteredRow {
                    RadioButton(selected = isFood, onClick = {
                        isFood = true
                    })
                    Text("Food")
                }
                CenteredRow {
                    RadioButton(selected = !isFood, onClick = {
                        isFood = false
                    })
                    Text("Drink")
                }
            }
            CenteredRow {
                Text("Item : ")
                Box {
                    TextButton(
                        onClick = {
                            fdExpanded = !fdExpanded
                        }
                    ) {
                        Text(fdName)
                        Icon(Icons.Default.ArrowDropDown, "Arrow Dropdown")
                    }
                    DropdownMenu(
                        expanded = fdExpanded,
                        onDismissRequest = {fdExpanded = false}
                    ) {
                        if(filteredFDs.count() == 0) {
                            DropdownMenuItem(text = {Text("Empty")}, onClick = {fdExpanded = false})
                        } else {
                            filteredFDs.forEach { fd ->
                                DropdownMenuItem(
                                    text = {Text(fd.name)},
                                    onClick = {
                                        selectedFD = fd
                                        fdPrice = fd.price.toString()
                                        fdName = fd.name
                                        fdExpanded = false
                                        calculateSubtotal()
                                    }
                                )
                            }
                        }
                    }
                }
            }
            CenteredRow {
                Text("Price :")
                TextField(
                    value = fdPrice,
                    onValueChange = {str: String -> fdPrice = str},
                    readOnly = true
                )
            }
            CenteredRow {
                Text("Quantity :")
                TextField(
                    value = quantity,
                    onValueChange = {str: String ->
                        quantity = str
                    },
                    keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number)
                )
            }
            CenteredRow {
                Text("Sub Total :")
                TextField(
                    value = subtotal,
                    onValueChange = {str: String -> subtotal = str},
                    readOnly = true
                )
            }
            Button(
                onClick = {
                    //...
                }
            ) {
                Text("Submit")
            }
        }
    }
}

@Composable
fun CenteredRow(function: @Composable () -> Unit) {
    Row(
        verticalAlignment = Alignment.CenterVertically,
        horizontalArrangement = Arrangement.spacedBy(8.dp)
    ) {
        function()
    }
}