package ejh.id.minibar

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
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
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.getValue
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.RectangleShape
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.em
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
    var roomNumberOpened by remember { mutableStateOf(false) }
    var itemOpened by remember { mutableStateOf(false) }
    var selectedRoom by remember {mutableStateOf(0)}
    var selectedItem by remember {mutableStateOf("")}
    var quantity by remember {mutableStateOf("")}
    var price by remember {mutableStateOf("")}
    var subtotal by remember {mutableStateOf("")}
    Column(verticalArrangement = Arrangement.spacedBy(8.dp)) {
        Row(Modifier.fillMaxWidth().background(Color.Blue).padding(12.dp)) {
            Text("LKS-SMK Jatim Mini Bar", fontSize = 3.em)
        }
        Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.spacedBy(10.dp)) {
            Text("Room Number")
            Button({roomNumberOpened = true}, shape = RectangleShape) {
                Text("$selectedRoom")
                Icon(Icons.Default.KeyboardArrowDown, "ArrowDown")
                DropdownMenu(roomNumberOpened, {roomNumberOpened = false}) {
                    for(i in 100..107) {
                        DropdownMenuItem(onClick = {
                            roomNumberOpened = false
                            selectedRoom = i
                            }, text = {Text("$i")})
                    }
                }
            }
        }
        Text("Type")
        Column {
            Row(verticalAlignment = Alignment.CenterVertically) {
                RadioButton(false, onClick =  {})
                Text("Food")
            }
            Row(verticalAlignment = Alignment.CenterVertically) {
                RadioButton(false, onClick =  {})
                Text("Drink")
            }
        }
        Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.spacedBy(8.dp)) {
            Text("Item : ")
            TextButton(onClick = {itemOpened = true}, modifier = Modifier.fillMaxWidth()) {
                Text(selectedItem)
                Icon(Icons.Default.KeyboardArrowDown, "ArrowDown")
                DropdownMenu(itemOpened, {itemOpened = false}) {
                    DropdownMenuItem(onClick = {itemOpened = false}, text = {
                        Text("Makanan1")
                    })
                    DropdownMenuItem(onClick = {itemOpened = false}, text = {
                        Text("Makanan2")
                    })
                    DropdownMenuItem(onClick = {itemOpened = false}, text = {
                        Text("Makanan3")
                    })
                }
            }
        }
        Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.spacedBy(8.dp)) {
            Text("Price : ")
            TextField(value = price, readOnly = true, onValueChange = {str:String -> price = str})
        }
        Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.spacedBy(8.dp)) {
            Text("Quantity : ")
            TextField(value = quantity, onValueChange = {str:String -> quantity = str})
        }
        Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.spacedBy(8.dp)) {
            Text("Sub total : ")
            TextField(value = subtotal, readOnly = true, onValueChange = {str:String -> subtotal = str})
        }
        Button(onClick = {}) {
            Text("Submit")
        }
    }
}

@Preview(showBackground = true)
@Composable
fun MinibarPreview() {
    Minibar(Modifier.padding(8.dp))
}