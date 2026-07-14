package com.example.myapplication16

import android.os.Bundle
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.ListAdapter
import android.widget.ListView
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.collection.MutableIntList
import androidx.collection.mutableIntListOf
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

        // buttons
        val rollDices_Button = findViewById<Button>(R.id.button_rollDices)
        val resetGame_Button = findViewById<Button>(R.id.button_reset)

        // image container
        val imageContainer = findViewById<LinearLayout>(R.id.imagesContainer)

        // textviews
        val drawResult_TextView = findViewById<TextView>(R.id.textView_drawResult)
        val gameResult_TextView = findViewById<TextView>(R.id.textView_gameResult)

        // previous results list
        val previousResults_List = findViewById<ListView>(R.id.previousResults)

        // ints
        var drawResult = 0
        var gameResult = 0

        // lists
        var images = listOf(R.drawable.k1, R.drawable.k2, R.drawable.k3, R.drawable.k4, R.drawable.k5, R.drawable.k6)
        var drawNums = mutableIntListOf()
        val previousResults = mutableListOf<Int>()

        val adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, previousResults )

        previousResults_List.adapter = adapter

        previousResults_List.setOnItemClickListener { _, _, index,_->
            var clickedItem = previousResults[index]
            Toast.makeText(this, "W losowaniu ${index + 1}: ${clickedItem}", Toast.LENGTH_SHORT).show()

        }

        previousResults_List.setOnItemLongClickListener{  _, _, index, _ ->
            var clickedLongItem = previousResults[index]
            Toast.makeText(this, "Usunięto losowanie ${index + 1}: ${clickedLongItem}", Toast.LENGTH_SHORT).show()
            previousResults.removeAt(index)
            adapter.notifyDataSetChanged()
            true
        }

        rollDices_Button.setOnClickListener {
            for (i in 0 until imageContainer.childCount){
                val item = imageContainer.getChildAt(i)
                if (item is ImageView){
                    var random = (0..5).random()
                    item.setImageResource(images[random])
                    drawNums.add(++random)
                }
            }

            drawResult = CountPoints(drawNums)
            gameResult += drawResult

            drawResult_TextView.text = "Wynik tego losowania: ${drawResult}"
            gameResult_TextView.text = "Wynik gry: ${gameResult}"

            previousResults.add(drawResult)
            adapter.notifyDataSetChanged()
            drawNums.clear()
        }

        resetGame_Button.setOnClickListener {
            drawResult = 0
            gameResult = 0

            drawResult_TextView.text = "Wynik tego losowania: ${drawResult}"
            gameResult_TextView.text = "Wynik gry: ${gameResult}"
        }



    }

    fun CountPoints(drawNums: MutableIntList): Int{
        var points = 0
        var counter = 0

        for (i in 1 .. 6){
            for (j in 0 until drawNums.size){
                if (i == drawNums[j]){
                    counter++
                }
            }

            if (counter >= 2){
                points += i * counter
            }

            counter = 0
        }


        return points
    }
}