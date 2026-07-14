package com.example.myapplication14

import android.graphics.Color
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.RadioButton
import android.widget.RadioGroup
import android.widget.SeekBar
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        // 1. USTAW WIDOK NAJPIERW
        setContentView(R.layout.activity_main)

        // 2. USUNIĘTO enableEdgeToEdge() - to ona najczęściej powoduje czarny ekran przy złym XML

        // RadioGroup
        val colorsRadioGroup: RadioGroup = findViewById(R.id.radioGroup_Colors)

        // SeekBar
        val redSeekBar : SeekBar = findViewById(R.id.seekBar_Red)
        val greenSeekBar : SeekBar = findViewById(R.id.seekBar_Green)
        val blueSeekBar : SeekBar = findViewById(R.id.seekBar_Blue)

        // SeekBar's TextView
        val redTextView : TextView = findViewById(R.id.textView_Red)
        val greenTextView : TextView = findViewById(R.id.textView_Green)
        val blueTextView : TextView = findViewById(R.id.textView_Blue)

        // Button, TextView, View
        val submitButton : Button = findViewById(R.id.button_submit)
        val resultTextView : TextView = findViewById(R.id.textView_Result)
        val resultView : View = findViewById(R.id.View_Result)

        // Wspólna funkcja do aktualizacji koloru przycisku w locie
        fun updateButtonColor() {
            val color = Color.rgb(redSeekBar.progress, greenSeekBar.progress, blueSeekBar.progress)
            submitButton.setBackgroundColor(color)
        }

        // Słuchacz dla Czerwonego
        redSeekBar.setOnSeekBarChangeListener(object : SeekBar.OnSeekBarChangeListener {
            override fun onProgressChanged(s: SeekBar?, progress: Int, f: Boolean) {
                redTextView.text = progress.toString()
                updateButtonColor()
            }
            override fun onStartTrackingTouch(s: SeekBar?) {}
            override fun onStopTrackingTouch(s: SeekBar?) {}
        })

        // Słuchacz dla Zielonego
        greenSeekBar.setOnSeekBarChangeListener(object : SeekBar.OnSeekBarChangeListener {
            override fun onProgressChanged(s: SeekBar?, progress: Int, f: Boolean) {
                greenTextView.text = progress.toString()
                updateButtonColor()
            }
            override fun onStartTrackingTouch(s: SeekBar?) {}
            override fun onStopTrackingTouch(s: SeekBar?) {}
        })

        // Słuchacz dla Niebieskiego
        blueSeekBar.setOnSeekBarChangeListener(object: SeekBar.OnSeekBarChangeListener{
            override fun onProgressChanged(s: SeekBar?, progress: Int, f: Boolean) {
                blueTextView.text = progress.toString()
                updateButtonColor()
            }
            override fun onStartTrackingTouch(s: SeekBar?) {}
            override fun onStopTrackingTouch(s: SeekBar?) {}
        })

        // Przycisk ZATWIERDŹ
        submitButton.setOnClickListener {
            val r = redSeekBar.progress
            val g = greenSeekBar.progress
            val b = blueSeekBar.progress
            val color = Color.rgb(r, g, b)

            val checkedRadioButtonId = colorsRadioGroup.checkedRadioButtonId


            when(checkedRadioButtonId){
                R.id.radioButton_HEX -> {
                    // Poprawione formatowanie HEX (zawsze 6 znaków)
                    val hex = String.format("#%02X%02X%02X", r, g, b)
                    resultTextView.text = "Twój kolor:\n $hex"
                }
                R.id.radioButton_RGB -> {
                    resultTextView.text = "Twój kolor:\n RGB($r, $g, $b)"
                }
                else -> {
                    Toast.makeText(this, "Wybierz format (HEX/RGB)!", Toast.LENGTH_SHORT).show()
                }
            }

            resultView.setBackgroundColor(color)
        }
    }
}
