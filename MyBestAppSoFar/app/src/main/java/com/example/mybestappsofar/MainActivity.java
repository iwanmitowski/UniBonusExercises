package com.example.mybestappsofar;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    TextView helloTV;
    EditText nameET;
    Button hiBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        helloTV = findViewById(R.id.helloTextView);
        nameET = findViewById(R.id.nameEditText);
        hiBtn = findViewById(R.id.hiButton);

        //Вземане на текст от бутона

        //Създаване на нов Listener
        //Ако се ползва веднъж го създаваме така.
        hiBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Пишем какво да става при клика на бутона

                //Взимаме текста
                String name = nameET.getText().toString();

                //Сетваме го
                helloTV.setText("Hello " + name);
            }
        });


    }
}