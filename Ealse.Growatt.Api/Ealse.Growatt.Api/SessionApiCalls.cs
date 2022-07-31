using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ealse.Growatt.Api.Models;

namespace Ealse.Growatt.Api
{
    public partial class Session : IDisposable
    {
        public string LoginRelativeUrl { get; set; } = "login";
        public string PlantList { get; set; } = "index/getPlantListTitle";
        public string InverterEnergyDataTotalUrl { get; set; } = "panel/inv/getInvTotalChart";
        public string InverterEnergyDataYearUrl { get; set; } = "panel/inv/getInvYearChart";
        public string InverterEnergyDataMonthUrl { get; set; } = "panel/inv/getInvMonthChart";
        public string InverterEnergyDataDayUrl { get; set; } = "panel/inv/getInvDayChart";
        public string DevicesByPlantList { get; set; } = "panel/getDevicesByPlantList";
        public string WeatherByPlantId { get; set; } = "index/getWeatherByPlantId";
        public string StorageTotalData { get; set; } = "panel/storage/getStorageTotalData";
        public string PlantData { get; set; } = "panel/getPlantData";
        public string StorageStatusData { get; set; } = "panel/storage/getStorageStatusData";
        public string StorageBatChartData { get; set; } = "panel/storage/getStorageBatChart";
        public string StorageEnergyDayChartData { get; set; } = "panel/storage/getStorageEnergyDayChart";
        public string DeviceInfo { get; set; } = "panel/getDeviceInfo";

        /// <summary>
        /// Gets current plant information of all plants.
        /// </summary>
        /// <returns>Current information of all plants</returns>
        public async Task<List<Plant>> GetPlantList()
        {
            return await GetResponseData<List<Plant>>(new Uri(GrowattApiBaseUrl, PlantList), string.Empty);
        }

        /// <summary>
        /// Gets devices by plant
        /// </summary>
        /// <returns>Gets devices by plant</returns>
        public async Task<List<DeviceByPlant>> GetDevicesByPlantList(string plantId)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("currPage", "1"),
                    new KeyValuePair<string, string>("plantId", plantId)
                });

            return await GetPostResponseData<List<DeviceByPlant>>(content, new Uri(GrowattApiBaseUrl, DevicesByPlantList), "obj.datas");
        }

        /// <summary>
        /// Gets datalog device info
        /// </summary>
        /// <returns>Gets datalog device info</returns>
        public async Task<DeviceInfoDatalog> GetDatalogDeviceInfo(string plantId, string sn)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("deviceTypeName", "datalog"),
                new KeyValuePair<string, string>("sn", sn)
                });

            return await GetPostResponseData<DeviceInfoDatalog>(content, new Uri(GrowattApiBaseUrl, DeviceInfo), "obj");
        }

        /// <summary>
        /// Gets weather by plant
        /// </summary>
        /// <returns>Gets weather by plant</returns>
        public async Task<Weather> GetWeatherByPlant(string plantId)
        {
            return await GetPostResponseData<Weather>(new StringContent(string.Empty), new Uri(GrowattApiBaseUrl, WeatherByPlantId + $"?plantId={plantId}"), "obj");
        }

        /// <summary>
        /// Gets data for plant
        /// </summary>
        /// <returns>Gets data for plant</returns>
        public async Task<PlantData> GetPlantData(string plantId)
        {
            return await GetPostResponseData<PlantData>(new StringContent(string.Empty), new Uri(GrowattApiBaseUrl, PlantData + $"?plantId={plantId}"), "obj");
        }

        /// <summary>
        /// Gets amount of power generated for each 5 minutes of the given day.
        /// </summary>
        /// <returns>Amount of power generated for each 5 minutes of the given day.</returns>
        public async Task<List<Nullable<double>>> GetPlantDetailDayData(string plantId, DateTime date)
        {
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("date", date.ToString("yyyy-MM-dd")),
                });

            return await GetPostResponseData<List<Nullable<double>>>(content, new Uri(GrowattApiBaseUrl, InverterEnergyDataDayUrl), "obj.pac");
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

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, InverterEnergyDataMonthUrl), "obj.energy");
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

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, InverterEnergyDataYearUrl), "obj.energy");
        }

        /// <summary>
        /// Gets amount of power generated for each year
        /// </summary>
        /// <returns>Amount of genereted power for each year</returns>
        public async Task<List<double>> GetPlantDetailTotalData(string plantId)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("year", DateTime.Now.ToString("yyyy")),
            });

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, InverterEnergyDataTotalUrl), "obj.energy");
        }

        /// <summary>
        /// Gets storage device info
        /// </summary>
        /// <returns>Gets storage device info</returns>
        public async Task<DeviceInfoStorage> GetStorageDeviceInfo(String plantId, String sn)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("deviceTypeName", "storage"),
                new KeyValuePair<string, string>("sn", sn)
                });

            return await GetPostResponseData<DeviceInfoStorage>(content, new Uri(GrowattApiBaseUrl, DeviceInfo), "obj");
        }

        /// <summary>
        /// Gets total storage data by plant, inverter
        /// </summary>
        /// <returns>Gets total storage data by plant, inverter</returns>
        public async Task<StorageTotalData> GetStorageTotalDataByPlant(string plantId, string storageSn)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("storageSn", storageSn)
                });

            return await GetPostResponseData<StorageTotalData>(content, new Uri(GrowattApiBaseUrl, StorageTotalData + $"?plantId={plantId}"), "obj.datas");
        }

        /// <summary>
        /// Gets status storage data by plant, inverter
        /// </summary>
        /// <returns>Gets status storage data by plant, inverter</returns>
        public async Task<StorageStatusData> GetStorageStatusDataByPlant(String plantId, String storageSn)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("storageSn", storageSn)
             });

            return await GetPostResponseData<StorageStatusData>(content, new Uri(GrowattApiBaseUrl, StorageStatusData + $"?plantId={plantId}"), "obj");
        }

        /// <summary>
        /// Gets storage battery chart data
        /// </summary>
        /// <returns>Gets storage battery chart data</returns>
        public async Task<StorageBatChartData> GetStorageBatChartData(String plantId, String storageSn)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("storageSn", storageSn)
            });

            return await GetPostResponseData<StorageBatChartData>(content, new Uri(GrowattApiBaseUrl, StorageBatChartData), "obj");
        }

        /// <summary>
        /// Gets storage battery chart data
        /// </summary>
        /// <returns>Gets storage battery chart data</returns>
        public async Task<StorageEnergyDayChart> GetStorageEnergyDayChart(String plantId, String storageSn, DateTime date)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("date", date.ToString("yyyy-MM-dd")),
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("storageSn", storageSn)
            });

            return await GetPostResponseData<StorageEnergyDayChart>(content, new Uri(GrowattApiBaseUrl, StorageEnergyDayChartData), "obj");
        }
    }
}