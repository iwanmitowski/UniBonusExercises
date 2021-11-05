package com.example.mybestappsofar;

import androidx.appcompat.app.AppCompatActivity;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Random;

public class GameActivity extends AppCompatActivity {

    SharedPreferences pref;
    SharedPreferences.Editor editor;

    final int Lives = 5;

    int tries = 0;
    int wins = 0;
    int loses = 0;
    int currentNumber;
    Random randomGen = new Random();

    TextView scoreTV;
    ImageView imageIV;
    EditText guessET;
    TextView losesTV;
    TextView winsTV;
    TextView guessesTV;
    Button guessBtn;
    Button retryBtn;

    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View view) {

            if (view.getId()==R.id.retryBtn)
            {
                RestartGame();
                return;
            }

            if (guessET.getText().length() == 0)
            {
                Toast.makeText(GameActivity.this, "Enter a guess number!", Toast.LENGTH_SHORT).show();
                return;
            }

            tries++;
            scoreTV.setText(tries + "/" + Lives);

            int userGuess = Integer.parseInt(guessET.getText().toString());
            guessET.setText("");

            guessesTV.setText((guessesTV.getText() + " " + userGuess));

            if (userGuess > currentNumber)
            {
                imageIV.setImageResource(R.drawable.down);
            }
            else if (userGuess < currentNumber)
            {
                imageIV.setImageResource(R.drawable.up);
            }
            else{
                imageIV.setImageResource(R.drawable.winner);
                guessBtn.setEnabled(false);

                wins++;
                editor.putInt("wins", wins); // Ако го има като поле, ще го ъпдейтен, ако не ще го създаде
                editor.apply();//За да го запише в SharedPreferences

                UpdateOldScore();
                return;
            }

            if (tries == Lives)
            {
                imageIV.setImageResource(R.drawable.loser);

                loses++;
                editor.putInt("loses", loses);
                editor.apply();

                UpdateOldScore();
                guessBtn.setEnabled(false);
            }
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game);

        scoreTV = findViewById(R.id.scoreTV);
        imageIV = findViewById(R.id.imageIV);
        guessET = findViewById(R.id.guessET);
        losesTV = findViewById(R.id.losesTV);
        winsTV = findViewById(R.id.winsTV);
        guessesTV = findViewById(R.id.guessesTV);
        guessBtn = findViewById(R.id.guessBtn);
        retryBtn = findViewById(R.id.retryBtn);

        guessBtn.setOnClickListener(onClickListener);
        retryBtn.setOnClickListener(onClickListener);

        RestartGame();

        pref = getSharedPreferences("scoreStats", MODE_PRIVATE);
        editor = pref.edit();

        wins = pref.getInt("wins", 0); // Ако не намери ключ wins връща 0
        loses = pref.getInt("loses", 0);

        UpdateOldScore();
    }

    private void UpdateOldScore(){
        winsTV.setText("Wins: "+ wins);
        losesTV.setText("Loses: "+ loses);
    }


    private void RestartGame(){
        currentNumber = randomGen.nextInt(101);
        tries = 0;
        scoreTV.setText("0/" + Lives);
        guessesTV.setText("");
        guessBtn.setEnabled(true);

        Log.wtf("cheat", currentNumber + " ");
    }

}