package com.example.fuel.model;

public class Driver {
    private String id;
    private String nic;
    private String Name;
    private String password;
    private String vehicleNo;
    private String fuelType;
    private String vehicleType;

    public Driver(String id, String name, String nic, String password, String vehicleNumber, String fuelType, String vehicleType) {
        this.id = id;
        this.nic = nic;
        this.Name = name;
        this.password = password;
        this.vehicleNo = vehicleNumber;
        this.fuelType = fuelType;
        this.vehicleType = vehicleType;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getNic() {
        return nic;
    }

    public void setNic(String nic) {
        this.nic = nic;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getVehicleNumber() {
        return vehicleNo;
    }

    public void setVehicleNumber(String vehicleNumber) {
        this.vehicleNo = vehicleNumber;
    }

    public String getFuelType() {
        return fuelType;
    }

    public void setFuelType(String fuelType) {
        this.fuelType = fuelType;
    }

    public String getVehicleType() {
        return vehicleType;
    }

    public void setVehicleType(String vehicleType) {
        this.vehicleType = vehicleType;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        this.Name = name;
    }
}
