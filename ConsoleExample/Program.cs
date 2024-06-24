using Ealse.Growatt.Api;
using Ealse.Growatt.Api.Helpers;
using Ealse.Growatt.Api.Models;

// Insert your own information
var userHasStorageDevice = false;
var session = new Session("username", "password");

var plants = await session.GetPlantList();
var plant = plants[0];

var tableAlignment = "{0,-40}{1}";

if (plants != null && plant != null && plant.Id != null)
{
    var weather = await session.GetWeatherByPlant(plant.Id);

    Console.WriteLine("----- Weather -------");
    Console.WriteLine(tableAlignment, "- City:", $"{weather.City}");
    Console.WriteLine(tableAlignment, "- Sunrise:", $"{weather.Data.WeatherList[0]?.Basic?.Sunrise}");
    Console.WriteLine(tableAlignment, "- Sunset:", $"{weather.Data.WeatherList[0]?.Basic?.Sunset}");
    Console.WriteLine(tableAlignment, "- Latitude:", $"{weather.Data.WeatherList[0]?.Basic?.Latitude}");
    Console.WriteLine(tableAlignment, "- Longitude:", $"{weather.Data.WeatherList[0]?.Basic?.Longitude}");
    Console.WriteLine(tableAlignment, "- Temperature:", $"{weather.Data.WeatherList[0]?.Now?.Temperature} C");
    Console.WriteLine(tableAlignment, "- Cloud Volume:", $"{weather.Data.WeatherList[0]?.Now?.Cloud}");
    Console.WriteLine(tableAlignment, "- Condition:", $"{weather.Data.WeatherList[0]?.Now?.ConditionText}");
    Console.WriteLine("---------------------");
    Console.WriteLine("");

    var devices = await session.GetDevicesByPlantList(plant.Id);
    var device = devices[0];
    var allPlantDataForGivenDay = await session.GetPlantDetailDayChartData(plant.Id, DateTime.Now);
    var allPlantVoltageDataForGivenDay = await session.GetPlantDetailDayChartData(plant.Id, DateTime.Now, serialNumber: device.Sn, param: InverterPlantParameters.Voltage.Mppt1);
    var allPlantDataPerDayForGivenMonth = await session.GetPlantDetailMonthChartData(plant.Id, DateTime.Now);
    var allPlantDataPerMonthForGivenYear = await session.GetPlantDetailYearChartData(plant.Id, DateTime.Now);
    var allPlantDataPerYear = await session.GetPlantDetailTotalChartData(plant.Id);

    Console.WriteLine("----- My Solar Panel Information -------");
    Console.WriteLine(tableAlignment, "- Today at 13:45:", $"{allPlantDataForGivenDay[(13 * 60 + 45) / 5] ?? 0} W");
    Console.WriteLine(tableAlignment, "- Today at 13:45:", $"{allPlantVoltageDataForGivenDay[(13 * 60 + 45) / 5] ?? 0} Voltage");
    Console.WriteLine(tableAlignment, $"- {DateTime.Now:yyyy-MM-01}:", $"{allPlantDataPerDayForGivenMonth[0]} kWh");
    Console.WriteLine(tableAlignment, $"- {DateTime.Now:yyyy-MM}:", $"{allPlantDataPerMonthForGivenYear[DateTime.Now.Month - 1]} kWh");
    Console.WriteLine(tableAlignment, $"- {DateTime.Now:yyyy}:", $"{allPlantDataPerYear.Last()} kWh");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("");

    var dataLoggerDevice = await session.GetDatalogDeviceInfo(plant.Id, device.DatalogSn);
    var utcDateTime = DateTime.Parse(device.TimeServer).AddHours(-8);
    var localDateTime = utcDateTime.AddHours(double.Parse(device.Timezone));
    var deviceStatus = StatusHelper.getDeviceTypeStatus(device);

    Console.WriteLine("----- My Photovoltaic Devices -------");
    Console.WriteLine(tableAlignment, "- Device Serial Number:", $"{device.Sn}");
    Console.WriteLine(tableAlignment, "- User Name:", $"{device.AccountName}");
    Console.WriteLine(tableAlignment, "- Today(kWh):", $"{device.EToday}");
    Console.WriteLine(tableAlignment, "- Status:", $"{deviceStatus}");
    Console.WriteLine(tableAlignment, "- Plant Name:", $"{device.PlantName}");
    Console.WriteLine(tableAlignment, "- This Month(kWh):", $"{device.EMonth}");
    Console.WriteLine(tableAlignment, "- Server Update Time:", $"{DateTime.Parse(device.TimeServer):yyyy-MM-dd HH:mm:ss}"); // Server Time zone is China (UTC+8)
    Console.WriteLine(tableAlignment, "- UTC Update Time:", $"{utcDateTime:yyyy-MM-dd HH:mm:ss}");
    Console.WriteLine(tableAlignment, "- Local Update Time:", $"{localDateTime:yyyy-MM-dd HH:mm:ss}");
    Console.WriteLine(tableAlignment, "- Data Logger:", $"{device.DatalogSn}");
    Console.WriteLine(tableAlignment, "----- Signal:", $"{SignalHelper.getSimSignalText(int.Parse(dataLoggerDevice.SimSignal), dataLoggerDevice.DeviceTypeIndicate)}");
    Console.WriteLine(tableAlignment, "----- Collector Model:", $"{device.DatalogTypeTest}");
    Console.WriteLine(tableAlignment, "----- Firmware Version:", $"{dataLoggerDevice.FirmwareVersion}");
    Console.WriteLine(tableAlignment, "----- Ip & Port:", $"{dataLoggerDevice.IpAndPort}");
    Console.WriteLine(tableAlignment, "----- Data Update Interval:", $"{dataLoggerDevice.Interval} Minute");
    Console.WriteLine(tableAlignment, "- Total Energy(kWh):", $"{device.ETotal}");
    Console.WriteLine(tableAlignment, "- Rated Power(W):", $"{device.NominalPower}");
    Console.WriteLine(tableAlignment, "- Current Power(W):", $"{device.Pac}");
    Console.WriteLine("-------------------");
    Console.WriteLine("");

    var plantData = await session.GetPlantData(plant.Id);

    Console.WriteLine("----- Social Contribution -------");
    Console.WriteLine(tableAlignment, "- CO2 Reduced:", $"{plantData.Co2} kg");
    Console.WriteLine(tableAlignment, "- Tree:", $"{plantData.Tree}");
    Console.WriteLine(tableAlignment, "- Coal:", $"{plantData.Coal}");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("");

    if (devices != null && devices != null && device.Sn != null && userHasStorageDevice)
    {
        var totalStorageData = await session.GetStorageTotalDataByPlant(plant.Id, device.Sn);

        Console.WriteLine("----- Solar -------");
        Console.WriteLine(tableAlignment, $"- Today:", $"{totalStorageData.EpvToday} kWh");
        Console.WriteLine(tableAlignment, $"- Total:", $"{totalStorageData.EpvTotal} kWh");
        Console.WriteLine("-------------------");
        Console.WriteLine("");
        Console.WriteLine("----- Discharged -------");
        Console.WriteLine(tableAlignment, $"- Today:", $"{totalStorageData.EDischargeToday} kWh");
        Console.WriteLine(tableAlignment, $"- Total:", $"{totalStorageData.EDischargeTotal} kWh");
        Console.WriteLine("-------------------");
        Console.WriteLine("");
        Console.WriteLine("----- Charged -------");
        Console.WriteLine(tableAlignment, $"- Today:", $"{totalStorageData.ChargeToday} kWh");
        Console.WriteLine(tableAlignment, $"- Total:", $"{totalStorageData.ChargeTotal} kWh");
        Console.WriteLine("-------------------");
        Console.WriteLine("");
        Console.WriteLine("----- Imported from Grid -------");
        Console.WriteLine(tableAlignment, $"- Today:", $"{totalStorageData.EToUserToday} kWh");
        Console.WriteLine(tableAlignment, $"- Total:", $"{totalStorageData.EToUserTotal} kWh");
        Console.WriteLine("-------------------");
        Console.WriteLine("");
        Console.WriteLine("----- Load Consumption -------");
        Console.WriteLine(tableAlignment, "- Today:", $"{totalStorageData.UseEnergyToday} kWh");
        Console.WriteLine(tableAlignment, "- Total:", $"{totalStorageData.UseEnergyTotal} kWh");
        Console.WriteLine("-------------------");
        Console.WriteLine("");

        var statusStorageData = await session.GetStorageStatusDataByPlant(plant.Id, device.Sn);
        var deviceType = statusStorageData.DeviceType == "1" ? "Inverter" : (statusStorageData.DeviceType == "2" ? "Mix" : "Storage");
        var isBatteryCharging = int.Parse(statusStorageData.BatPower) < 0;
        var batPower = statusStorageData.BatPower.Replace("-", "");

        Console.WriteLine("----- Storage Status -------");
        Console.WriteLine(tableAlignment, "- Device Type:", $"{deviceType}");
        Console.WriteLine(tableAlignment, "- Device S/N:", $"{device.Sn}");
        Console.WriteLine(tableAlignment, "- Data Sources:", $"{deviceStatus}");
        Console.WriteLine(tableAlignment, "- Battery Voltage:", $"{statusStorageData.VBat}");
        Console.WriteLine(tableAlignment, "- PV1/PV2 Voltage:", $"{statusStorageData.VPv1}/{statusStorageData.VPv2} V");
        Console.WriteLine(tableAlignment, "- PV1/PV2 Recharging Current:", $"{statusStorageData.IPv1}/{statusStorageData.IPv2} A");
        Console.WriteLine(tableAlignment, "- Total Charge Current:", $"{statusStorageData.ITotal} A");
        Console.WriteLine(tableAlignment, "- Ac Input Voltage/Frequency:", $"{statusStorageData.VAcInput}V/{statusStorageData.FAcInput}Hz");
        Console.WriteLine(tableAlignment, "- Ac Output Voltage/Frequency:", $"{statusStorageData.VAcOutput}V/{statusStorageData.FAcOutput}Hz");
        Console.WriteLine(tableAlignment, "- Consumption Power:", $"{statusStorageData.LoadPower}W/{statusStorageData.RateVA}VA");
        Console.WriteLine(tableAlignment, "- Load Percentage:", $"{statusStorageData.LoadPrecent}%");
        Console.WriteLine(tableAlignment, "- ");
        Console.WriteLine(tableAlignment, "- Solar Power:", $"{statusStorageData.Ppv1}W");
        Console.WriteLine(tableAlignment, "- Grid Import:", $"{statusStorageData.GridPower}W");
        Console.WriteLine(tableAlignment, "- Battery", $"{(isBatteryCharging ? "Charging" : "Discharging")}: {batPower}W");
        Console.WriteLine(tableAlignment, "- Battery SoC:", $"{statusStorageData.Capacity}%");
        Console.WriteLine(tableAlignment, "- Status:", $"{statusStorageData.InvStatus}");
        Console.WriteLine("-------------------");
        Console.WriteLine("");

        var statusBatChartData = await session.GetStorageBatChartData(plant.Id, device.Sn);

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
                Console.WriteLine($"- {now:yyyy-MM-dd HH:mm} : {statusBatChartData.SocChart.Capacity[i]} %");
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
                Console.WriteLine($"- {now:yyyy-MM-dd HH:mm} : Solar {statusEnergyDayChartData.Charts.Ppv[i]} W / Imported from Grid {statusEnergyDayChartData.Charts.PacToUser[i]} W / Load Consumption {statusEnergyDayChartData.Charts.UserLoad[i]} W");
                now = now.AddMinutes(int.Parse(dataLoggerDevice.Interval));
            }
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine("");
    }
}