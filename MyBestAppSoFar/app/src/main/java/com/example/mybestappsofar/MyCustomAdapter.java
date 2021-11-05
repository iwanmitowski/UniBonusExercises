package com.example.mybestappsofar;

import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

public class MyCustomAdapter extends RecyclerView.Adapter<MyCustomAdapter.ViewHolder> {

    //Продуктите, които ще визуализираме
    private Product[] products;

    public MyCustomAdapter( Product[] products)
    {
        this.products = products;
    }


    //inflate - прилагане на даден xml
    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        View view = inflater.inflate(R.layout.list_row, parent, false);

        //нашият viewHolder
        ViewHolder vh = new ViewHolder(view);

        return  vh;
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {

        Product myProduct = products[position];
        holder.nameTV.setText(myProduct.name);
        holder.priceTV.setText(String.valueOf(myProduct.price));
        holder.quantityTV.setText(String.valueOf(myProduct.quantity));

        if (myProduct.bought)
        {
            holder.rowLL.setBackgroundColor(Color.GREEN);
        }
        else{
            holder.rowLL.setBackgroundColor(Color.RED);
        }

        //Смяна на цветовете
        holder.rowLL.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                myProduct.switchStatus();

                if (myProduct.bought)
                {
                    holder.rowLL.setBackgroundColor(Color.GREEN);
                }
                else{
                    holder.rowLL.setBackgroundColor(Color.RED);
                }
            }
        });

    }

    @Override
    public int getItemCount() {
        return products.length;
    }

    public static class ViewHolder extends RecyclerView.ViewHolder{

        public TextView nameTV;
        public TextView quantityTV;
        public TextView priceTV;
        public LinearLayout rowLL;

        //holder-a на нашите предмети
        public ViewHolder(@NonNull View itemView) {
            super(itemView);

            nameTV = itemView.findViewById(R.id.nameTV);
            quantityTV = itemView.findViewById(R.id.quantityTV);
            priceTV = itemView.findViewById(R.id.priceTV);
            rowLL = itemView.findViewById(R.id.rowLinearLayout);
        }
    }
}
