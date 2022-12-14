package com.example.fuel.model;

public class FuelStation {

    private String id;
    private String nic;
    private String userName;
    private String stationName;
    private String permitNumber;
    private String stationAddress;
    private String password;

    public FuelStation(String id, String username, String nic, String name, String permit_no, String address, String password) {
        this.id = id;
        this.nic = nic;
        this.userName = username;
        this.stationName = name;
        this.permitNumber = permit_no;
        this.stationAddress = address;
        this.password = password;
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

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getStationName() {
        return stationName;
    }

    public void setStationName(String stationName) {
        this.stationName = stationName;
    }

    public String getPermitNumber() {
        return permitNumber;
    }

    public void setPermitNumber(String permitNumber) {
        this.permitNumber = permitNumber;
    }

    public String getStationAddress() {
        return stationAddress;
    }

    public void setStationAddress(String stationAddress) {
        this.stationAddress = stationAddress;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
