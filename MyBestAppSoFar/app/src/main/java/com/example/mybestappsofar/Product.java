package com.example.mybestappsofar;

public class Product {
    // Не е добра практика поленцата да са public!!!

    public int id;
    public String name;
    public double quantity;
    public double price;
    public boolean bought;

    public Product(String name, double quanity)
    {
        this.name = name;
        this.quantity = quanity;
    }

    public void switchStatus() {
        bought = !bought;
    }
}
