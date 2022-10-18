package com.example.fuel;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.AppCompatTextView;

import android.os.Bundle;
import android.widget.TextView;

import com.example.fuel.sql.DatabaseHelper;

public class HomeActivity extends AppCompatActivity {

    private final AppCompatActivity activity = HomeActivity.this;
    private TextView textViewName;

    private DatabaseHelper databaseHelper;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        //getSupportActionBar().setTitle("");
        initViews();
        initObjects();
    }
    /**
     * This method is to initialize views
     */
    private void initViews() {
        textViewName = (TextView) findViewById(R.id.textViewName);

    }
    /**
     * This method is to initialize objects to be used
     */
    private void initObjects() {

        databaseHelper = new DatabaseHelper(activity);
       // String emailFromIntent = getIntent().getStringExtra("EMAIL");
       // textViewName.setText(emailFromIntent);

    }


}