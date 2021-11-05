package com.example.mybestappsofar;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;

public class ShoppingListActivity extends AppCompatActivity {

    RecyclerView shoppingListRV;
    MyCustomAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_shopping_list);

        //TODO: Delete

        Product[] products = new Product[]{
                new Product("Kока-кола", 0.5),
                new Product("Ракия", 14),
                new Product("Kраставици", 10),
                new Product("Домати", 0.5),
                new Product("Бира", 1),
                new Product("Сирене", 11),
                new Product("Кашкавал", 13),
                new Product("Боза", 14),
        };

        //Setup-ване на SQLite (SQLiteHelper)
        //Създаване на модел Product
        //Създаване на shoppingListRecycleView
        //Adapter

        shoppingListRV = findViewById(R.id.shoppingListRV);
        shoppingListRV.setHasFixedSize(true); //работи и без това
        shoppingListRV.setLayoutManager(new LinearLayoutManager(this));

        adapter = new MyCustomAdapter(products);

        shoppingListRV.setAdapter(adapter);
    }
}