package com.example.myapplication15

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.RatingBar
import android.widget.TextView
import android.widget.Toast
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

        // washing machine
        val code_editText = findViewById<EditText>(R.id.editText_code)
        val submit_button = findViewById<Button>(R.id.button_submit)
        val code_textview = findViewById<TextView>(R.id.textView_code)

        submit_button.setOnClickListener {
            if ((1 .. 12).contains(code_editText.text.toString().toInt())){
                code_textview.text = "Numer prania: ${code_editText.text.toString()}"
            }
        }

        // hoover
        val on_off_button = findViewById<Button>(R.id.button_on_off)
        val on_off_textview = findViewById<TextView>(R.id.textView_on_off)
        var status = false

        on_off_button.setOnClickListener {
            if (!status){
                on_off_button.text = "Wyłącz"
                on_off_textview.text = "Odkurzacz włączony"
                status = true
            }else{
                on_off_button.text = "Włącz"
                on_off_textview.text = "Odkurzacz wyłączony"
                status = false
            }
        }

        // rating app
        val rate_RatingBar = findViewById<RatingBar>(R.id.ratingBar_rating)
        val rate_TextView = findViewById<TextView>(R.id.textView_rating)
        val submitRating_Button = findViewById<Button>(R.id.button_submitRating)

        rate_RatingBar.setOnRatingBarChangeListener{ _, rate, _ ->
            rate_TextView.text = "${rate.toInt()}/${rate_RatingBar.max}"
        }

        submitRating_Button.setOnClickListener {
            var message : String
            var rate = "Dziękujemy za ocenę ${rate_RatingBar.progress.toInt()}/${rate_RatingBar.max}"

            when(rate_RatingBar.progress){
                3 -> message = ". Postaramy się poprawić następnym razem."
                4 -> message = ". Cieszymy się że aplikacja sprostała oczekiwaniom."
                5 -> message = ". Cieszymy się że aplikacja była ponad oczekiwaniami."
                else -> message = ". Przepraszmy za nieudogodnienia."
            }

            Toast.makeText(this, rate + message, Toast.LENGTH_LONG).show()
        }





    }
}