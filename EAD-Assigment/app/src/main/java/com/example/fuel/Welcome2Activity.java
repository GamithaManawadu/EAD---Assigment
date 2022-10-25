package com.example.fuel;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class Welcome2Activity extends AppCompatActivity {

    Button driverButtonLogin;
    Button FSOButtonLogin;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_welcome2);
        driverButtonLogin = findViewById(R.id.driverButtonLogin);
        FSOButtonLogin = findViewById(R.id.FSOButtonLogin);
        OnClickButtonLister();
    }
    public void OnClickButtonLister() {

        driverButtonLogin.setOnClickListener(
                new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {


                        Intent intent = new Intent(Welcome2Activity.this, DriverLoginActivity.class);
                        startActivity(intent);
                    }
                }

        );
        FSOButtonLogin.setOnClickListener(
                new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {


                        Intent intent = new Intent(Welcome2Activity.this, DriverLoginActivity.class);
                        startActivity(intent);
                    }
                }

        );

    }
}