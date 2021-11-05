package com.example.mybestappsofar;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class CalculatorActivity extends AppCompatActivity {

    EditText num1;
    EditText num2;
    Button plusBtn;
    Button minusBtn;
    Button divideBtn;
    Button multiplyBtn;
    TextView resultTV;
    View.OnClickListener listener;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_calculator);

        num1 = findViewById(R.id.num1ET);
        num2 = findViewById(R.id.num2ET);
        plusBtn = findViewById(R.id.plusBtn);
        minusBtn = findViewById(R.id.minusBtn);
        divideBtn = findViewById(R.id.divideBtn);
        multiplyBtn = findViewById(R.id.multiplyBtn);
        resultTV = findViewById(R.id.resultTV);

        plusBtn.setOnClickListener(onClickListener);
        minusBtn.setOnClickListener(onClickListener);
        divideBtn.setOnClickListener(onClickListener);
        multiplyBtn.setOnClickListener(onClickListener);

        }


        View.OnClickListener onClickListener = new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if(num1.getText().length() == 0 || num2.getText().length() == 0 ||
                    num1.getText().toString().equals(".") || num2.getText().toString().equals("."))
                {
                    return;
                }

                double firstNumber = Double.parseDouble(String.valueOf(num1.getText().toString()));
                double secondNumber = Double.parseDouble(String.valueOf(num2.getText().toString()));
                double result = 0;

                //Вариант със switch на id-то на бутона;
                switch (view.getId())
                {
                    case R.id.plusBtn:
                        result = firstNumber + secondNumber;
                        break;
                    case R.id.minusBtn:
                        result = firstNumber - secondNumber;
                        break;
                    case R.id.multiplyBtn:
                        result = firstNumber * secondNumber;
                        break;
                    case R.id.divideBtn:
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        break;
                }

                //Вариант със switch text-та на бутона;
                /*switch (((Button)view).getText().toString())
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber!=0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            result = Double.NaN;
                        }
                        break;
                }
                 */

                resultTV.setText("Result: " + result);
            }
        };
    }

