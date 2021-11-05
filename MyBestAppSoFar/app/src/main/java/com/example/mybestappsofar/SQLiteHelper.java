package com.example.mybestappsofar;

import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class SQLiteHelper extends SQLiteOpenHelper {

    public static final String Database_Name = "shoppingDB.db";
    public static final int Version = 1;

    public static final String Table_Products = "products";
    public static final String Table_Products_Id = "id";
    public static final String Table_Products_Name = "name";
    public static final String Table_Products_Quantity = "quantity";
    public static final String Table_Products_Price = "price";
    public static final String Table_Products_Bought = "bought";

    public static final String Create_Table_Products = "CREATE TABLE " + Table_Products +
            "(" +
            "'" + Table_Products_Id + "' INTEGER PRIMARY KEY AUTOINCREMENT,"+
            "'" + Table_Products_Name + "' VARCHAR(250) NOT NULL," +
            "'" + Table_Products_Quantity + "' REAL NOT NULL," +
            "'" + Table_Products_Price + "' REAL,"+
            "'" + Table_Products_Bought + "' NUMERIC DEFAULT 0)";

    public SQLiteHelper(@Nullable Context context) {
        super(context, Database_Name, null, Version);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(Create_Table_Products);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

        db.execSQL("DROP TABLE IF EXISTS " + Table_Products);

        onCreate(db);
    }

    public void insertProduct(Product product)
    {
        //ППЦ го слагаме в try catch finally

        //Отваряме конекция
        SQLiteDatabase db = getWritableDatabase();

        //Ключ-стойност
        ContentValues cv = new ContentValues();
        cv.put(Table_Products_Name, product.name);
        cv.put(Table_Products_Quantity, product.quantity);
        cv.put(Table_Products_Price, product.price);

        //Записваме в базата
        db.insert(Table_Products, null, cv);

        //Затваряме конекция
        db.close();
    }
}
