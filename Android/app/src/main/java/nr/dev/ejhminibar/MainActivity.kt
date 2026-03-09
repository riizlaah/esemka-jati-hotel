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
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.BasicTextField
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ArrowDropDown
import androidx.compose.material3.Button
import androidx.compose.material3.DropdownMenu
import androidx.compose.material3.DropdownMenuItem
import androidx.compose.material3.Icon
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.RadioButton
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.derivedStateOf
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.unit.dp
import androidx.compose.ui.window.Dialog
import androidx.core.text.isDigitsOnly
import kotlinx.coroutines.launch
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
    val fdPrice by remember {
        derivedStateOf {
            (selectedFD?.price ?: 0).toString()
        }
    }
    // others
    var isFood by remember { mutableStateOf(true) }
//    var subtotal by remember { mutableStateOf("") }
    var quantity by remember { mutableStateOf("1") }
    var rooms by remember { mutableStateOf(listOf<Room>()) }
    var fds by remember { mutableStateOf(listOf<FD>()) }
    var filteredFDs by remember { mutableStateOf(listOf<FD>()) }
    var errMsg by remember { mutableStateOf("") }
    var confirmState by remember { mutableStateOf("no") }
    val scope = rememberCoroutineScope()
    val subtotal by remember {
        derivedStateOf {
            val qty = quantity.toIntOrNull() ?: 0
            val prc = fdPrice.toIntOrNull() ?: 0
            if(qty <= 0) "0"
            else (qty * prc).toString()
        }
    }

    suspend fun filterFDs() {
        filteredFDs = if (isFood) {
            HttpClient.getFDs("F")
        } else {
            HttpClient.getFDs("D")
        }
        selectedFD = null
        println(fds.count())
        fdExpanded = false
        fdName = "Select Item"
    }

    LaunchedEffect(Unit) {
        if (rooms.isEmpty()) {
            rooms = HttpClient.getRooms()
            fds = HttpClient.getFDs()
            filterFDs()
        }
    }

    LaunchedEffect(isFood) {
        filterFDs()
    }

    LaunchedEffect(confirmState) {
        if (confirmState == "ok") {
            scope.launch {
                HttpClient.sendFDReq(
                    selectedFD!!.id,
                    selectedRoom!!.id,
                    quantity.toIntOrNull() ?: 1
                )
                isFood = true
                selectedRoom = null
                selectedFD = null
                fdName = "Select item"
                quantity = "1"
                roomNumber = "Select Room"
            }
        }
    }

    Column(modifier.fillMaxSize()) {
        Alert(errMsg.isNotEmpty(), errMsg, { errMsg = "" })
        Alert(
            visible = confirmState == "pending",
            msg = "Are you sure want to purchase ${quantity} ${selectedFD?.name ?: "?"}?",
            onOk = { confirmState = "ok" },
            title = "Confirmation",
            confirmMode = true,
            onCancel = { confirmState = "no" }
        )

        Box(
            modifier
                .fillMaxWidth()
                .background(DodgerBlue)
                .padding(12.dp)
        ) {
            Text(
                "LKS Esemka Jati Hotel Mini Bar",
                fontSize = MaterialTheme.typography.headlineSmall.fontSize,
                fontWeight = FontWeight.Bold,
                color = Color.White
            )
        }
        Column(
            Modifier
                .fillMaxSize()
                .padding(12.dp),
            verticalArrangement = Arrangement.spacedBy(8.dp)
        ) {
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
                        onDismissRequest = { rNumExpanded = false }
                    ) {
                        rooms.forEach { room ->
                            DropdownMenuItem(
                                text = { Text(room.number) },
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
                        onDismissRequest = { fdExpanded = false }
                    ) {
                        if (filteredFDs.count() == 0) {
                            DropdownMenuItem(
                                text = { Text("Empty") },
                                onClick = { fdExpanded = false })
                        } else {
                            filteredFDs.forEach { fd ->
                                DropdownMenuItem(
                                    text = { Text(fd.name) },
                                    onClick = {
                                        selectedFD = fd
                                        fdName = fd.name
                                        fdExpanded = false
                                    }
                                )
                            }
                        }
                    }
                }
            }
            CenteredRow {
                Text("Price :")
                BorderedTextField(fdPrice, {}, Modifier.weight(1f), readOnly = true)
            }
            CenteredRow {
                Text("Quantity :")
                BorderedTextField(quantity, {quantity = it}, Modifier.weight(1f), keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number))
            }
            CenteredRow {
                Text("Sub Total :")
                BorderedTextField(subtotal, {}, Modifier.weight(1f), readOnly = true)
            }
            Button(
                onClick = {
                    if (selectedRoom == null) {
                        errMsg = "Please select a room."
                        return@Button
                    }
                    if (selectedFD == null) {
                        errMsg = "Please select an item."
                        return@Button
                    }
                    if (!quantity.isDigitsOnly()) {
                        errMsg = "Quantity not valid."
                        return@Button
                    }
                    val qty = quantity.toInt()
                    if (qty <= 0) {
                        errMsg = "Quantity not valid."
                        return@Button
                    }
                    confirmState = "pending"

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

@Composable
fun BorderedTextField(
    value: String,
    onValChange: (String) -> Unit,
    modifier: Modifier = Modifier,
    singleLine: Boolean = true,
    readOnly: Boolean = false,
    keyboardOptions: KeyboardOptions = KeyboardOptions.Default
) {
    BasicTextField(
        value = value,
        onValueChange = onValChange,
        singleLine = singleLine,
        readOnly = readOnly,
        modifier = modifier,
        keyboardOptions = keyboardOptions,
        decorationBox = { tField ->
            Box(
                Modifier
                    .fillMaxWidth()
                    .background(Color.DarkGray)
                    .padding(bottom = 2.dp)
                    .background(Color.White)
                    .padding(8.dp, 12.dp), contentAlignment = Alignment.CenterStart
            ) {
                tField()
            }
        }
    )
}

@Composable
fun Alert(
    visible: Boolean,
    msg: String,
    onOk: () -> Unit,
    title: String = "Alert",
    confirmMode: Boolean = false,
    onCancel: () -> Unit = {}
) {
    if (visible) {
        Dialog({}) {
            Box(Modifier.fillMaxSize(), contentAlignment = Alignment.Center) {
                Column(
                    Modifier
                        .fillMaxWidth(0.75f)
                        .clip(RoundedCornerShape(12.dp))
                        .background(Color.White)
                        .padding(12.dp)
                ) {
                    Text(
                        title,
                        fontSize = MaterialTheme.typography.titleSmall.fontSize,
                        fontWeight = FontWeight.SemiBold
                    )
                    Spacer(Modifier.height(12.dp))
                    Text(msg)
                    Row(
                        Modifier
                            .fillMaxWidth()
                            .padding(8.dp),
                        horizontalArrangement = Arrangement.End,
                        verticalAlignment = Alignment.CenterVertically
                    ) {
                        if (confirmMode) {
                            TextButton(onClick = onCancel) {
                                Text("Cancel")
                            }
                        }
                        TextButton(onClick = onOk) {
                            Text("OK")
                        }
                    }
                }
            }
        }
    }
}