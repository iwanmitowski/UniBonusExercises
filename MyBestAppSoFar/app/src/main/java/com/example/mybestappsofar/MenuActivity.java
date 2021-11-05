package com.example.mybestappsofar;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MenuActivity extends AppCompatActivity {

    //1 Създаваме променливата
    Button helloBtn;
    Button calculatorBtn;
    Button gameBtn;
    Button shoppingBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);

        //2 Инициализираме променливата
        helloBtn = findViewById(R.id.helloWorldBtn);
        calculatorBtn = findViewById(R.id.calculatorBtn);
        gameBtn = findViewById(R.id.gameBtn);
        shoppingBtn = findViewById(R.id.shoppingListBtn);

        //3 Сетваме onClickListener
        helloBtn.setOnClickListener(onClickListener);
        calculatorBtn.setOnClickListener(onClickListener);
        gameBtn.setOnClickListener(onClickListener);
        shoppingBtn.setOnClickListener(onClickListener);
    }

    //4 Сетваме intent-a при клик
    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View view) {

            Intent intent = null;

            switch(view.getId())
            {
                case R.id.helloWorldBtn:
                    intent = new Intent(MenuActivity.this, MainActivity.class);
                        break;
                case R.id.calculatorBtn:
                    intent = new Intent(MenuActivity.this,CalculatorActivity.class);
                        break;
                case R.id.gameBtn:
                    intent = new Intent(MenuActivity.this, GameActivity.class);
                    break;
                case R.id.shoppingListBtn:
                    intent = new Intent(MenuActivity.this, ShoppingListActivity.class);
                    break;
            }

            startActivity(intent);
        }
    };
}