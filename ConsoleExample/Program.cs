using Ealse.Growatt.Api;
using Ealse.Growatt.Api.Helpers;
using System.Text.Json;

var session = new Session("", "");

var plants = await session.GetPlantList();
var plant = plants[0];

if (plants != null && plant != null && plant.Id != null)
{
    var weather = await session.GetWeatherByPlant(plant.Id);

    Console.WriteLine("----- Weather -------");
    Console.WriteLine($"- City: {weather.City}");
    Console.WriteLine($"- Sunrise: {weather.Data.WeatherList[0]?.Basic?.Sunrise}");
    Console.WriteLine($"- Sunset: {weather.Data.WeatherList[0]?.Basic?.Sunset}");
    Console.WriteLine($"- Latitude: {weather.Data.WeatherList[0]?.Basic?.Latitude}");
    Console.WriteLine($"- Longitude: {weather.Data.WeatherList[0]?.Basic?.Longitude}");
    Console.WriteLine($"- Temperature: {weather.Data.WeatherList[0]?.Now?.Temperature} C");
    Console.WriteLine($"- Cloud Volume: {weather.Data.WeatherList[0]?.Now?.Cloud}");
    Console.WriteLine($"- Condition: {weather.Data.WeatherList[0]?.Now?.ConditionText}");
    Console.WriteLine("---------------------");
    Console.WriteLine("");

    var devices = await session.GetDevicesByPlantList(plant.Id);
    var device = devices[0];
    var storageDevice = await session.GetStorageDeviceInfo(plant.Id, device.Sn);
    var dataLoggerDevice = await session.GetDatalogDeviceInfo(plant.Id, device.DatalogSn);
    var utcDateTime = DateTime.Parse(device.TimeServer).AddHours(-8);
    var localDateTime = utcDateTime.AddHours(int.Parse(device.Timezone));
    var deviceStatus = StatusHelper.getDeviceTypeStatus(device);

    Console.WriteLine("----- My Photovoltaic Devices -------");
    Console.WriteLine($"- Device Serial Number: {device.Sn}");
    Console.WriteLine($"- User Name: {device.AccountName}");
    Console.WriteLine($"- Today(kWh): {device.EToday}");
    Console.WriteLine($"- Status: {deviceStatus}");
    Console.WriteLine($"- Plant Name: {device.PlantName}");
    Console.WriteLine($"- This Month(kWh): {device.EMonth}");
    Console.WriteLine($"- Server Update Time: {DateTime.Parse(device.TimeServer).ToString("yyyy-MM-dd HH:mm:ss")}"); // Server Timezone is China (UTC+8)
    Console.WriteLine($"- UTC Update Time: {utcDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
    Console.WriteLine($"- Local Update Time: {localDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
    Console.WriteLine($"- Data Logger: {device.DatalogSn}");
    Console.WriteLine($"----- Signal: {SignalHelper.getSimSignalText(int.Parse(dataLoggerDevice.SimSignal), dataLoggerDevice.DeviceTypeIndicate)}");
    Console.WriteLine($"----- Collector Model: {device.DatalogTypeTest}");
    Console.WriteLine($"----- Firmware Version: {dataLoggerDevice.FirmwareVersion}");
    Console.WriteLine($"----- Ip & Port: {dataLoggerDevice.IpAndPort}");
    Console.WriteLine($"----- Data Update Interval: {dataLoggerDevice.Interval} Minute");
    Console.WriteLine($"- Total Energy(kWh): {device.ETotal}");
    Console.WriteLine($"- Rated Power(W): {device.NominalPower}");
    Console.WriteLine($"- Current Power(W): {device.Pac}");
    Console.WriteLine("-------------------");
    Console.WriteLine("");
    
    var plantData = await session.GetPlantData(plant.Id);
    
    Console.WriteLine("----- Social Contribution -------");
    Console.WriteLine($"- CO2 Reduced: {plantData.Co2} kg");
    Console.WriteLine($"- Tree: {plantData.Tree}");
    Console.WriteLine($"- Coal: {plantData.Coal}");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("");


    if (devices != null && devices != null && device.Sn != null)
    {
        var totalStorageData = await session.GetStorageTotalDataByPlant(plant.Id, device.Sn);

        Console.WriteLine("----- Solar -------");
        Console.WriteLine($"- Today: {totalStorageData.EpvToday} kWh");
        Console.WriteLine($"- Total: {totalStorageData.EpvTotal} kWh");
        Console.WriteLine("-------------------");
        Console.WriteLine("");
        Console.WriteLine("----- Discharged -------");
        Console.WriteLine($"- Today: {totalStorageData.EDischargeToday} kWh");
        Console.WriteLine($"- Total: {totalStorageData.EDischargeTotal} kWh");
        Console.WriteLine("-------------------");
        Console.WriteLine("");
        Console.WriteLine("----- Charged -------");
        Console.WriteLine($"- Today: {totalStorageData.ChargeToday} kWh");
        Console.WriteLine($"- Total: {totalStorageData.ChargeTotal} kWh");
        Console.WriteLine("-------------------");
        Console.WriteLine("");
        Console.WriteLine("----- Imported from Grid -------");
        Console.WriteLine($"- Today: {totalStorageData.EToUserToday} kWh");
        Console.WriteLine($"- Total: {totalStorageData.EToUserTotal} kWh");
        Console.WriteLine("-------------------");
        Console.WriteLine("");
        Console.WriteLine("----- Load Consumption -------");
        Console.WriteLine($"- Today: {totalStorageData.UseEnergyToday} kWh");
        Console.WriteLine($"- Total: {totalStorageData.UseEnergyTotal} kWh");
        Console.WriteLine("-------------------");
        Console.WriteLine("");
        
        var statusStorageData = await session.GetStorageStatusDataByPlant(plant.Id, device.Sn);
        var deviceType = statusStorageData.DeviceType == "1" ? "Inverter" : (statusStorageData.DeviceType == "2" ? "Mix" : "Storage");
        var isBatteryCharging = int.Parse(statusStorageData.BatPower) < 0;
        var batPower = statusStorageData.BatPower.Replace("-","");
        
        Console.WriteLine("----- Storage Status -------");
        Console.WriteLine($"- Device Type: {deviceType}");
        Console.WriteLine($"- Device S/N: {device.Sn}");
        Console.WriteLine($"- Data Sources: {deviceStatus}");
        Console.WriteLine($"- Battery Voltage: {statusStorageData.VBat}");
        Console.WriteLine($"- PV1/PV2 Voltage: {statusStorageData.VPv1}/{statusStorageData.VPv2} V");
        Console.WriteLine($"- PV1/PV2 Recharging Current: {statusStorageData.IPv1}/{statusStorageData.IPv2} A");
        Console.WriteLine($"- Totale Charge Current: {statusStorageData.ITotal} A");
        Console.WriteLine($"- Ac Input Voltage/Frequency: {statusStorageData.VAcInput}V/{statusStorageData.FAcInput}Hz");
        Console.WriteLine($"- Ac Output Voltage/Frequency: {statusStorageData.VAcOutput}V/{statusStorageData.FAcOutput}Hz");
        Console.WriteLine($"- Consumption Power: {statusStorageData.LoadPower}W/{statusStorageData.RateVA}VA");
        Console.WriteLine($"- Load Percentage: {statusStorageData.LoadPrecent}%");
        Console.WriteLine("- ");
        Console.WriteLine($"- Solar Power: {statusStorageData.Ppv1}W");
        Console.WriteLine($"- Grid Import: {statusStorageData.GridPower}W");
        Console.WriteLine($"- Battery {(isBatteryCharging ? "Charging" : "Discharging")}: {batPower}W");
        Console.WriteLine($"- Battery SoC: {statusStorageData.Capacity}%");
        Console.WriteLine($"- Status: {statusStorageData.InvStatus}");
        Console.WriteLine("-------------------");
        Console.WriteLine("");

        var statusBatChartData = await session.GetStorageBatChart(plant.Id, device.Sn);

        Console.WriteLine("----- Battery Information -------");

        for (int i = 0; i < statusBatChartData.CdsTitle.Count; i++) 
        {
            Console.WriteLine($"- {statusBatChartData.CdsTitle[i]} : Charged {statusBatChartData.CdsData.CdChargeList[i]} kWh / Discharged {statusBatChartData.CdsData.CdDischargeList[i]} kWh");
        }      

        Console.WriteLine("--------------------------------");
        Console.WriteLine("");

        Console.WriteLine("----- Battery SoC -------");

        var now = DateOnly.FromDateTime(DateTime.Now).ToDateTime(TimeOnly.Parse("00:00 AM"));
        for (int i = 0; i < statusBatChartData.SocChart.Capacity.Count; i++) 
        {
            if (statusBatChartData.SocChart.Capacity[i] != null)
            {
                Console.WriteLine($"- {now.ToString("yyyy-MM-dd HH:mm")} : {statusBatChartData.SocChart.Capacity[i]} %");
                now = now.AddMinutes(int.Parse(dataLoggerDevice.Interval));
            }
        }      

        Console.WriteLine("--------------------------------");
        Console.WriteLine("");

        var statusEnergyDayChartData = await session.GetStorageEnergyDayChart(plant.Id, device.Sn, DateTime.Now);

        Console.WriteLine("----- Energy Trend -------");
        Console.WriteLine($"---- Charge {statusEnergyDayChartData.EChargeTotal} kWh : Solar Storage {statusEnergyDayChartData.ECharge} kWh / Grid Storage {statusEnergyDayChartData.EAcCharge} kWh");
        Console.WriteLine($"---- Load Consumption {statusEnergyDayChartData.EDisChargeTotal} kWh : Inverter {statusEnergyDayChartData.EDisCharge} kWh / Inverter {statusEnergyDayChartData.EAcDisCharge} kWh");
        
        now = DateOnly.FromDateTime(DateTime.Now).ToDateTime(TimeOnly.Parse("00:00 AM"));
        for (int i = 0; i < statusEnergyDayChartData.Charts.UserLoad.Count; i++) 
        {
            if (statusEnergyDayChartData.Charts.UserLoad[i] != null)
            {
                Console.WriteLine($"- {now.ToString("yyyy-MM-dd HH:mm")} : Solar {statusEnergyDayChartData.Charts.Ppv[i]} W / Imported from Grid {statusEnergyDayChartData.Charts.PacToUser[i]} W / Load Consumption {statusEnergyDayChartData.Charts.UserLoad[i]} W");
                now = now.AddMinutes(int.Parse(dataLoggerDevice.Interval));
            }
        }      

        Console.WriteLine("--------------------------------");
        Console.WriteLine("");

        
       
    }       
    
}
