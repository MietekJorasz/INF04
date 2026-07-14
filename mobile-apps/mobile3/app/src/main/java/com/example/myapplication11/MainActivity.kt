package com.example.myapplication11

import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.ListView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        var list = mutableListOf("Zakupy: chleb, masło, ser", "Do zrobienia: obiad, umyć podłogi", "weekend: kino, spacer z psem")

        var task = findViewById<EditText>(R.id.newTaskEditText)
        var addBtn = findViewById<Button>(R.id.AddButton)
        var toDoList = findViewById<ListView>(R.id.toDoList)

        val adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, list)

        toDoList.adapter = adapter

        addBtn.setOnClickListener {
            list.add(task.text.toString())
            adapter.notifyDataSetChanged()
        }


    }
}