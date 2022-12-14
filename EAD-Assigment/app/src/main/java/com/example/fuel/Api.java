package com.example.fuel;

import com.example.fuel.model.Driver;
import com.example.fuel.model.FuelInventory;
import com.example.fuel.model.FuelStation;
import com.example.fuel.model.FuelType;
import com.example.fuel.model.User;
import com.google.gson.JsonArray;
import com.google.gson.JsonObject;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.Headers;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;

public interface Api {

    String BASE_URL = "https://localhost:5001/";


    @POST("User/registerDriver")
    Call<Driver> registerDriver(@Body Driver driver);

    @POST("FuelStation/registerFuelStation")
    Call<FuelStation> registerFuelStation(@Body FuelStation fuelStation);

    @POST("User/userLogin")
    Call<JsonObject> login(@Body User user);

    @GET("GetFuelTypes")
    Call<List<FuelType>> getFuelTypes();

    @GET("VehicleType/GetVehicleTypes")
    Call<JsonArray> getVehicleTypes();

    @GET("FuelStation/{id}")
    Call<JsonObject> getFuelStation(@Path("id") String id);

    @GET("FuelInventory/{id}")
    Call<JsonArray> getFuelInventory(@Path("id") String id);

    @PUT("FuelStation/{id}")
    Call<JsonObject> updateFuelStation(@Path("id") String id, @Body FuelStation fuelStation);

    @PUT("FuelInventory/{id}")
    Call<JsonObject> updateFuelInventory(@Path("id") String id, @Body FuelInventory fuelInventory);

    @PUT("VehicleType/UpdateAllowedFuelAmount/{vid}/{amount}")
    Call<Void> updateVehicleMaxFuelAmount(@Path("vid") String id, @Path("amount") Integer amount);


}

