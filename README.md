# Growatt API
API in .NET Standard 2.0 to communicate with a Growatt server for retrieving data on solar panels

## Version History

0.1 - released September 28, 2019

- Initial version

## System Requirements

This API is built using the Microsoft .NET Standard 2.0 framework and is fully asynchronous

## Warning

Growatt has not officially released an API. This API has been created by mimicking the traffic to their own web application. This means they can change their Api at any time causing this Api and your code to break without advanced notice. Be sure you understand the consequences of this before using any Growatt Api in your own software.

## Usage Instructions

To communicate with the Growatt API, add the NuGet package to your solution and add a using reference in your code:

```C#
using Ealse.Growatt.Api;
```

Then create a new session instance using:
Note that this line does not perform any communications with the Growatt API yet.

```C#
var session = new Session("your@email.com", "yourpassword");
```

You can call one of the methods on the session instance to retrieve data, i.e.:

```C#
// Retrieves information about the currently logged on user
var me = await session.GetUserData();
```

To retrieve inverter Serial numbers:

```C# 
var a = await session.GetInverterSerialNumbers("123456");
```

To retrieve the inverter production data:

```C#
var b = await session.GetInverterProductionData("1ABC234567", DateTime.Now);
```

To retrieve the amount of power generated on each half hour of the given day:

```C#
var c = await session.GetPlantDetailDayData("123456", DateTime.Now);
```

To retrieve the amount of power generated for each day of the given month (example: Month = 7 and year = 2019):

```C#
var d = await session.GetPlantDetailYearData("123456", new DateTime(2019, 7, 7));
```

To retrieve the amount of power generated for each month of the given year (example: 2019):

```C#
var e = await session.GetPlantDetailMonthData("123456", new DateTime(2019, 7, 7));
```

To retrieve the amount of power generated for each year:

```C#
var f = await session.GetPlantDetailTotalData("123456");
```

## Available via NuGet

You can also pull this API in as a NuGet package by adding "Ealse.Growatt.Api" or running:

Install-Package Ealse.Growatt.Api

Package statistics: https://www.nuget.org/packages/Ealse.Growatt.Api

## Feedback

Any kind of feedback is welcome!