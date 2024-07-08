# Growatt API
API in .NET Standard 2.0 to communicate with a Growatt server for changing settings and retrieving data from your solar panels and storage devices. It is device dependent, so not all methods may work for every device type. The example project shows most of the methods that can be called.

Available via Nuget: https://www.nuget.org/packages/Ealse.Growatt.Api

## Change device settings

The following method can be used to change your device settings.

```C#
PostSetting(string action, string serialNumber, string type, string[] parameters)
```

To discover which "action", "type" and "parameters" you should use, you can log in to [Growatt](https://server.growatt.com/login) and go to the place where the settings can be changed. Open the Network tab in the browser development tools and make a change to the settings. Now you will see a request with the request url `https://server.growatt.com/tcpSet.do` look into the payload to find the "action", "type" and "parameters" properties. The values of the parameters should be in the same order as in the payload: ["value param1", "value param2"]

Note: if you need a password please enter: `growattYYYYMMDD` using today's date.


## Console Example output (example with part of the options)
```
----- Weather -------
- City: ABCDEFGHJ
- Sunrise: 01:23
- Sunset: 01:23
- Latitude: 00.0000000
- Longitude: 00.000000
- Temperature: 12 C
- Cloud Volume: 12
- Condition: Cloudy
---------------------

----- My Photovoltaic Devices -------
- Device Serial Number: ABCDEFGHJ
- User Name: ABCDEFGHJ
- Today(kWh): 0.1
- Status: PV Charging+Grid Bypass (9)
- Plant Name: ABCDEFGHJ
- This Month(kWh): 123.4
- Server Update Time: 2022-03-15 12:34:56
- UTC Update Time: 2022-03-15 12:34:56
- Local Update Time: 2022-03-15 12:34:56
- Data Logger: ABCDEFGHJ
----- Signal: Excellent (0)
----- Collector Model: ShineWIFI-S
----- Firmware Version: 1.2.3.4
----- Ip & Port: /x.x.x.x:12345
----- Data Update Interval: 5 Minute
- Total Energy(kWh): 1234.5
- Rated Power(W): 1234
- Current Power(W): 123
-------------------

----- Social Contribution -------
- CO2 Reduced: 123.4 kg
- Tree: 12
- Coal: 123.4
--------------------------------

----- Solar -------
- Today: 0.1 kWh
- Total: 1234.5 kWh
-------------------

----- Discharged -------
- Today: 1.2 kWh
- Total: 1234.5 kWh
-------------------

----- Charged -------
- Today: 1.2 kWh
- Total: 1234.5 kWh
-------------------

----- Imported from Grid -------
- Today: 12.3 kWh
- Total: 1234.5 kWh
-------------------

----- Load Consumption -------
- Today: 12.3 kWh
- Total: 1234.5 kWh
-------------------

----- Storage Status -------
- Device Type: Storage
- Device S/N: ABCDEFGH
- Data Sources: PV Charging+Grid Bypass (9)
- Battery Voltage: 12.3
- PV1/PV2 Voltage: 123.4/0 V
- PV1/PV2 Recharging Current: 1.2/0 A
- Total Charge Current: 1.2 A
- Ac Input Voltage/Frequency: 123.4V/12.3Hz
- Ac Output Voltage/Frequency: 123.4V/12.3Hz
- Consumption Power: 1234W/1234VA
- Load Percentage: 12.3%
- 
- Solar Power: 123W
- Grid Import: 1234W
- Battery Charging: 123W
- Battery SoC: 12%
- Status: -12
-------------------

----- Battery Information -------
- 2022-03-09 : Charged 12 kWh / Discharged 1.2 kWh
- 2022-03-10 : Charged 12 kWh / Discharged 1.2 kWh
- 2022-03-11 : Charged 12 kWh / Discharged 1 kWh
- 2022-03-12 : Charged 12 kWh / Discharged 1.2 kWh
- 2022-03-13 : Charged 12 kWh / Discharged 0 kWh
- 2022-03-14 : Charged 12 kWh / Discharged 0 kWh
- 2022-03-15 : Charged 12 kWh / Discharged 1.2 kWh
--------------------------------

----- Battery SoC -------
- 2022-03-15 00:00 : 0 %
- 2022-03-15 00:05 : 25 %
- 2022-03-15 00:10 : 50 %
- 2022-03-15 00:15 : 75 %
- 2022-03-15 00:20 : 100 %
--------------------------------

----- Energy Trend -------
---- Charge 12.3 kWh : Solar Storage 1.2 kWh / Grid Storage 1.2 kWh
---- Load Consumption 12.3 kWh : Inverter 1.2 kWh / Inverter 12.3 kWh
- 2022-03-15 00:00 : Solar 0 W / Imported from Grid 1234 W / Load Consumption 1234 W
- 2022-03-15 00:05 : Solar 0 W / Imported from Grid 1234 W / Load Consumption 1234 W
- 2022-03-15 00:10 : Solar 0 W / Imported from Grid 1234 W / Load Consumption 1234 W
- 2022-03-15 00:15 : Solar 0 W / Imported from Grid 1234 W / Load Consumption 1234 W
--------------------------------
```

## System Requirements

This API is built using the Microsoft .NET Standard 2.0 framework and is fully asynchronous

## Usage Instructions

To communicate with the Growatt API, add the NuGet package to your solution and add a using reference in your code:

```C#
using Ealse.Growatt.Api;
```

Then create a new session instance using:
Note that this line does not perform any communications with the Growatt API yet.

```C#
var session = new Session("username", "password");
```

You can call one of the methods on the session instance to retrieve data, i.e.:

```C#
// Retrieves plant list
var plantList = await session.GetPlantList();
```

To retrieve weather for plant:

```C# 
var plantWeather = await session.GetWeatherByPlant("Plant Id");
```

To retrieve the devices for plant:

```C#
var plantDevices = await session.GetDevicesByPlantList("Plant Id");
```

To retrieve storage device info:

```C#
var storageDeviceInfo = await session.GetStorageDeviceInfo("Plant Id", "Device Sn");
```

To retrieve datalogger device info:

```C#
var datalogDeviceInfo = await session.GetDatalogDeviceInfo("Plant Id", "Datalog Sn");
```

To retrieve plant data:

```C#
var plantData = await session.GetPlantData("Plant Id");
```

For other method usage please look at the console example.

## Warning

Growatt has not officially released an API. This API has been created by mimicking the traffic to their own web application. This means they can change their Api at any time causing this Api and your code to break without advanced notice.

The developers who contributed to this project are not responsible for any problem or damage to your Growatt systems that result from using this library. Be sure you understand the consequences of this before using the Growatt Api in your own software.

## Available via NuGet

You can also pull this API in as a NuGet package by adding "Ealse.Growatt.Api" or running:

Install-Package Ealse.Growatt.Api

Package statistics: https://www.nuget.org/packages/Ealse.Growatt.Api