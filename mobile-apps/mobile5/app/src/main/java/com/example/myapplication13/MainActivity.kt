package com.example.myapplication13

import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.ListView
import android.widget.SeekBar
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.core.view.forEach
import androidx.core.view.size

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

        var speciesArr = listOf("Pies", "Kot", "Świnka morska")
        var speciesAgeArr = listOf(18, 20, 9)

        var speciesList = findViewById<ListView>(R.id.speciesList)
        var ageText = findViewById<TextView>(R.id.ageText)
        var ageSeekBar = findViewById<SeekBar>(R.id.ageSeekBar)

        var adapter = ArrayAdapter(this,android.R.layout.simple_list_item_1, speciesArr)

        var submitBtn = findViewById<Button>(R.id.submitBtn)
        var fullName = findViewById<EditText>(R.id.fullNameEditText)
        var visitPurpose = findViewById<EditText>(R.id.visitPurposeEditText)
        var time = findViewById<EditText>(R.id.timeEditText)

        speciesList.adapter = adapter

        var clickedItem = "Kot"

        speciesList.setOnItemClickListener{ parent, _, position, _ ->
            clickedItem = parent.getItemAtPosition(position).toString()

            for (i in 0 until  speciesList.size){
                if (speciesArr[i] == clickedItem){
                    ageSeekBar.max = speciesAgeArr[i]
                    break
                }
            }

        }

        ageSeekBar.setOnSeekBarChangeListener(object: SeekBar.OnSeekBarChangeListener{
            override fun onProgressChanged(
                seekBar: SeekBar?,
                progress: Int,
                fromUser: Boolean
            ) {
                ageText.text = progress.toString()
            }

            override fun onStartTrackingTouch(seekBar: SeekBar?) {

            }

            override fun onStopTrackingTouch(seekBar: SeekBar?) {

            }

        } )

        submitBtn.setOnClickListener {
            AlertDialog.Builder(this)
                .setTitle("Zapisana wizyta")
                .setMessage("${fullName.text}, ${clickedItem}, ${ageSeekBar.progress}, ${visitPurpose.text}, ${time.text}")
                .setPositiveButton("OK"){ dialog, which ->
                    dialog.dismiss()
                }
                .show()
        }


    }
}