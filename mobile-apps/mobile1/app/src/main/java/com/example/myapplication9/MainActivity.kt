package com.example.myapplication9

import android.annotation.SuppressLint
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    @SuppressLint("MissingInflatedId")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        var email : EditText = findViewById(R.id.email)
        var password : EditText = findViewById(R.id.password)
        var passwordRepeat : EditText = findViewById(R.id.passwordRepeat)
        var submitBtn : Button = findViewById(R.id.submitBtn)
        var result : TextView = findViewById(R.id.result)


        submitBtn.setOnClickListener {
            var emailRegex: Regex = Regex("^[A-Z,a-z,0-9]+@[A-Za-z0-9.-]+\\.[a-zA-Z]{2,}$")

            var emailValidation : Boolean = emailRegex.matches(email.text.toString())
            var passwordValidation : Boolean = password.text.toString() == passwordRepeat.text.toString()

            if ( emailValidation && passwordValidation ){
                result.text = "Witaj " + email.text
            }else{
                if (!emailValidation){
                    result.text = "Nieprawidłowy adres e-mail"
                }
                if(!passwordValidation){
                    result.text = "Hasła się różnią"
                }
            }
        }





    }
}