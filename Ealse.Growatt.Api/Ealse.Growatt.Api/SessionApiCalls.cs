using Ealse.Growatt.Api.Enum;
using Ealse.Growatt.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ealse.Growatt.Api
{
    public partial class Session : IDisposable
    {
        /// <summary>
        /// Gets data logger device information
        /// </summary>
        /// <returns>Data logger device information</returns>
        public async Task<DeviceInfoDataLogger> GetDataLoggerDeviceInfo(string plantId, string serialNumber)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("deviceTypeName", "datalog"),
                new KeyValuePair<string, string>("sn", serialNumber)
            });

            return await GetPostResponseData<DeviceInfoDataLogger>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.DeviceInfo), "obj");
        }

        /// <summary>
        /// Gets information of data logger devices
        /// </summary>
        /// <returns>Data logger devices information</returns>
        public async Task<List<DataLoggerDevice>> GetDataLoggerDevices(string plantId, string currentPage = "1")
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("currPage", currentPage),
                new KeyValuePair<string, string>("plantId", plantId),
            });

            return await GetPostResponseData<List<DataLoggerDevice>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.DataLoggerDeviceList), "datas");
        }

        /// <summary>
        /// Gets devices by plant
        /// </summary>
        /// <returns>Devices by plant</returns>
        public async Task<List<DeviceByPlant>> GetDevicesByPlantList(string plantId, string currentPage = "1")
        {
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("currPage", currentPage),
                    new KeyValuePair<string, string>("plantId", plantId)
            });

            return await GetPostResponseData<List<DeviceByPlant>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.DevicesByPlantList), "obj.datas");
        }

        /// <summary>
        /// Gets devices by plant
        /// </summary>
        /// <returns>Devices by plant</returns>
        public async Task<List<PlantFaultLog>> GetPlantFaultLogs(string plantId, DateTime date, DateFilterType dateFilterType,
            string deviceSerialNumberFilter = "", string currentPage = "1")
        {
            var formattedDate = date.ToString("yyyy-MM-dd");

            if (dateFilterType == DateFilterType.Month)
                formattedDate = date.ToString("yyyy-MM");
            if (dateFilterType == DateFilterType.Year)
                formattedDate = date.ToString("yyyy");

            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("plantId", plantId),
                    new KeyValuePair<string, string>("deviceSn", deviceSerialNumberFilter),
                    new KeyValuePair<string, string>("date", formattedDate),
                    new KeyValuePair<string, string>("type", ((int) dateFilterType).ToString()),
                    new KeyValuePair<string, string>("toPageNum", currentPage),

            });

            return await GetPostResponseData<List<PlantFaultLog>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.PlantFaultLog), "obj.datas");
        }

        /// <summary>
        /// Gets data for plant
        /// </summary>
        /// <returns>Gets data for plant</returns>
        public async Task<PlantData> GetPlantData(string plantId)
        {
            return await GetPostResponseData<PlantData>(new StringContent(string.Empty), new Uri(GrowattApiBaseUrl, RelativeUrls.PlantData + $"?plantId={plantId}"), "obj");
        }

        /// <summary>
        /// Gets amount of power generated for each 5 minutes of the given day.
        /// </summary>
        /// <param name="plantId"></param>
        /// <param name="date"></param>
        /// <param name="serialNumber"></param>
        /// <param name="param"></param>
        /// <param name="deviceTypeName">When serialNumber is given the deviceTypeName should also be given</param>
        /// <returns>Amount of power generated for each 5 minutes of the given day.</returns>
        public async Task<List<double?>> GetPlantDetailDayChartData(string plantId, DateTime date, string serialNumber = null, string param = InverterPlantParameters.Power.Pac, string deviceTypeName = "")
        {
            var jsonDataType = string.IsNullOrEmpty(serialNumber) ? "plant" : deviceTypeName;
            var sn = serialNumber ?? plantId;
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("date", date.ToString("yyyy-MM-dd")),
                new KeyValuePair<string, string>("jsonData", $"[{{\"type\":\"{jsonDataType}\",\"sn\":\"{sn}\",\"params\":\"{param}\"}}]"),
            });

            return await GetPostResponseData<List<double?>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.InverterEnergyDataDayChart), $"obj.0.datas.{param}");
        }

        /// <summary>
        /// Gets amount of power generated for each 5 minutes of the given day.
        /// </summary>
        /// <returns>Amount of power generated for each 5 minutes of the given day.</returns>
        public async Task<List<double?>> GetPlantDetailDayData(string plantId, DateTime date)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("date", date.ToString("yyyy-MM-dd")),
            });

            return await GetPostResponseData<List<double?>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.InverterEnergyDataDay), "obj.pac");
        }

        /// <summary>
        /// Gets amount of power generated for each day of the given month. 
        /// </summary>
        /// <param name="plantId"></param>
        /// <param name="date"></param>
        /// <param name="serialNumber"></param>
        /// <param name="type"></param>
        /// <param name="param"></param>
        /// <param name="deviceTypeName">When serialNumber is given the deviceTypeName should also be given</param>
        /// <returns>Amount of power generated for each day of the given month.</returns>
        public async Task<List<double>> GetPlantDetailMonthChartData(string plantId, DateTime date, string serialNumber = null, string type = null, string param = "energy", string deviceTypeName = "")
        {
            var jsonDataType = string.IsNullOrEmpty(serialNumber) ? "plant" : deviceTypeName;
            var sn = type is null && serialNumber != null ? serialNumber : plantId;
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("date", date.ToString("yyyy-MM")),
                new KeyValuePair<string, string>("jsonData", $"[{{\"type\":\"{jsonDataType}\",\"sn\":\"{sn}\",\"params\":\"{param}\"}}]"),
            });

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.InverterEnergyDataMonthChart), $"obj.0.datas.{param}");
        }

        /// <summary>
        /// Gets amount of power generated for each day of the given month.
        /// </summary>
        /// <returns>Amount of power generated for each day of the given month.</returns>
        public async Task<List<double>> GetPlantDetailMonthData(string plantId, DateTime date)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("date", date.ToString("yyyy-MM")),
            });

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.InverterEnergyDataMonth), "obj.energy");
        }

        /// <summary>
        /// Gets amount of power generated for each year
        /// </summary>
        /// <returns>Amount of generated power for each year</returns>
        public async Task<List<double>> GetPlantDetailTotalChartData(string plantId, string serialNumber = null, string type = null, string param = "energy")
        {
            var jsonDataType = type is null ? string.IsNullOrEmpty(serialNumber) ? "plant" : "inv" : type;
            var sn = type is null && serialNumber != null ? serialNumber : plantId;
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("year", DateTime.Now.ToString("yyyy")),
                new KeyValuePair<string, string>("jsonData", $"[{{\"type\":\"{jsonDataType}\",\"sn\":\"{sn}\",\"params\":\"{param}\"}}]"),
            });

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.InverterEnergyDataTotalChart), $"obj.0.datas.{param}");
        }

        /// <summary>
        /// Gets amount of power generated for each year
        /// </summary>
        /// <returns>Amount of generated power for each year</returns>
        public async Task<List<double>> GetPlantDetailTotalData(string plantId)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("year", DateTime.Now.ToString("yyyy")),
            });

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.InverterEnergyDataTotal), "obj.energy");
        }

        /// <summary>
        /// Gets amount of power generated for each month of the given year.
        /// </summary>
        /// <returns>Amount of power generated for each month of the given year.</returns>
        public async Task<List<double>> GetPlantDetailYearChartData(string plantId, DateTime date, string serialNumber = null, string type = null, string param = "energy")
        {
            var jsonDataType = type is null ? string.IsNullOrEmpty(serialNumber) ? "plant" : "inv" : type;
            var sn = type is null && serialNumber != null ? serialNumber : plantId;
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("year", date.ToString("yyyy")),
                new KeyValuePair<string, string>("jsonData", $"[{{\"type\":\"{jsonDataType}\",\"sn\":\"{sn}\",\"params\":\"{param}\"}}]"),
            });

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.InverterEnergyDataYearChart), $"obj.0.datas.{param}");
        }

        /// <summary>
        /// Gets amount of power generated for each month of the given year.
        /// </summary>
        /// <returns>Amount of power generated for each month of the given year.</returns>
        public async Task<List<double>> GetPlantDetailYearData(string plantId, DateTime date)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("year", date.ToString("yyyy")),
            });

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.InverterEnergyDataYea), "obj.energy");
        }

        /// <summary>
        /// Gets current plant information of all plants.
        /// </summary>
        /// <returns>Current information of all plants</returns>
        public async Task<List<Plant>> GetPlantList()
        {
            return await GetResponseData<List<Plant>>(new Uri(GrowattApiBaseUrl, RelativeUrls.PlantList), string.Empty);
        }

        /// <summary>
        /// Gets total of money and energy since the plant is created
        /// </summary>
        /// <returns>Gets data for plant</returns>
        public async Task<PlantDataTotals> GetPlantTotals(string plantId)
        {
            return await GetPostResponseData<PlantDataTotals>(new StringContent(string.Empty), new Uri(GrowattApiBaseUrl, RelativeUrls.InverterTotals + $"?plantId={plantId}"), "obj");
        }

        /// <summary>
        /// Gets storage battery chart data
        /// </summary>
        /// <returns>Storage battery chart data</returns>
        public async Task<StorageBatChartData> GetStorageBatChartData(string plantId, string storageSerialNumber)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("storageSn", storageSerialNumber)
            });

            return await GetPostResponseData<StorageBatChartData>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.StorageBatChartData), "obj");
        }

        /// <summary>
        /// Gets storage device information
        /// </summary>
        /// <returns>Storage device information</returns>
        public async Task<DeviceInfoStorage> GetStorageDeviceInfo(string plantId, string serialNumber)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("deviceTypeName", "storage"),
                new KeyValuePair<string, string>("sn", serialNumber)
            });

            return await GetPostResponseData<DeviceInfoStorage>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.DeviceInfo), "obj");
        }

        /// <summary>
        /// Gets storage battery chart data
        /// </summary>
        /// <returns>Storage battery chart data</returns>
        public async Task<StorageEnergyDayChart> GetStorageEnergyDayChart(string plantId, string storageSerialNumber, DateTime date)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("date", date.ToString("yyyy-MM-dd")),
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("storageSn", storageSerialNumber)
            });

            return await GetPostResponseData<StorageEnergyDayChart>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.StorageEnergyDayChartData), "obj");
        }

        /// <summary>
        /// Gets status storage data by plant, inverter
        /// </summary>
        /// <returns>Status storage data by plant, inverter</returns>
        public async Task<StorageStatusData> GetStorageStatusDataByPlant(string plantId, string storageSerialNumber)
        {
            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("storageSn", storageSerialNumber) });
            return await GetPostResponseData<StorageStatusData>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.StorageStatusData + $"?plantId={plantId}"), "obj");
        }

        /// <summary>
        /// Gets total storage data by plant, inverter
        /// </summary>
        /// <returns>Total storage data by plant, inverter</returns>
        public async Task<StorageTotalData> GetStorageTotalDataByPlant(string plantId, string storageSerialNumber)
        {
            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("storageSn", storageSerialNumber) });
            return await GetPostResponseData<StorageTotalData>(content, new Uri(GrowattApiBaseUrl, RelativeUrls.StorageTotalData + $"?plantId={plantId}"), "obj.datas");
        }

        /// <summary>
        /// Gets weather by plant
        /// </summary>
        /// <returns>Weather by plant</returns>
        public async Task<Weather> GetWeatherByPlant(string plantId)
        {
            return await GetPostResponseData<Weather>(new StringContent(string.Empty), new Uri(GrowattApiBaseUrl, RelativeUrls.WeatherByPlantId + $"?plantId={plantId}"), "obj");
        }

        /// <summary>
        /// Sets setting of plant
        /// </summary>
        /// <returns>Result of type SetSettingResponse</returns>
        public async Task<SetSettingResponse> PostSetting(string action, string serialNumber, string type, string[] parameters)
        {
            var formDictionary = new Dictionary<string, string>
            {
                { "action", action },
                { "serialNum", serialNumber },
                { "type", type }
            };

            for (var i = 0; i < parameters.Length; i++)
            {
                formDictionary.Add($"param{i + 1}", parameters[i]);
            }

            return await GetPostResponseData<SetSettingResponse>(new FormUrlEncodedContent(formDictionary), new Uri(GrowattApiBaseUrl, RelativeUrls.TcpSet), string.Empty);
        }
    }
}