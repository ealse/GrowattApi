using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Ealse.Growatt.Api.Models;

namespace Ealse.Growatt.Api
{
    public partial class Session : IDisposable
    {
        public string LoginRelativeUrl => "login";

        public string PlantList => "index/getPlantListTitle";

        public string DevicesByPlantList => "panel/getDevicesByPlantList";

        public string WeatherByPlantId => "index/getWeatherByPlantId";

        public string StorageTotalData => "panel/storage/getStorageTotalData";

        public string PlantData => "panel/getPlantData";

        public string StorageStatusData => "panel/storage/getStorageStatusData";

        public string StorageBatChartData => "panel/storage/getStorageBatChart";

        public string StorageEnergyDayChartData => "panel/storage/getStorageEnergyDayChart";

        public string DeviceInfo => "panel/getDeviceInfo";

        /// <summary>
        /// Gets current plant information of all plants.
        /// </summary>
        /// <returns>Current information of all plants</returns>
        public async Task<List<Plant>> GetPlantList()
        {
            var response = await GetMessageReturnResponse<List<Plant>>(new Uri(GrowattApiBaseUrl, PlantList), HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets devices by plant
        /// </summary>
        /// <returns>Gets devices by plant</returns>
        public async Task<List<DeviceByPlant>> GetDevicesByPlantList(String plantId)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("currPage", "1"),
                    new KeyValuePair<string, string>("plantId", plantId)
                });
            var response = await PostMessageReturnResponse<List<DeviceByPlant>>(new Uri(GrowattApiBaseUrl, DevicesByPlantList), content, HttpStatusCode.OK);
            return response;
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
            var response = await PostMessageReturnResponse<DeviceInfoStorage>(new Uri(GrowattApiBaseUrl, DeviceInfo), content, HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets datalog device info
        /// </summary>
        /// <returns>Gets datalog device info</returns>
        public async Task<DeviceInfoDatalog> GetDatalogDeviceInfo(String plantId, String sn)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("deviceTypeName", "datalog"),
                new KeyValuePair<string, string>("sn", sn)
                });
            var response = await PostMessageReturnResponse<DeviceInfoDatalog>(new Uri(GrowattApiBaseUrl, DeviceInfo), content, HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets weather by plant
        /// </summary>
        /// <returns>Gets weather by plant</returns>
        public async Task<Weather> GetWeatherByPlant(String plantId)
        {
            var response = await PostMessageReturnResponse<Weather>(new Uri(GrowattApiBaseUrl, WeatherByPlantId + $"?plantId={plantId}"), new StringContent(""), HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets total storage data by plant, inverter
        /// </summary>
        /// <returns>Gets total storage data by plant, inverter</returns>
        public async Task<StorageTotalData> GetStorageTotalDataByPlant(String plantId, String storageSn)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("storageSn", storageSn)
                });
            var response = await PostMessageReturnResponse<StorageTotalData>(new Uri(GrowattApiBaseUrl, StorageTotalData + $"?plantId={plantId}"), content, HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets data for plant
        /// </summary>
        /// <returns>Gets data for plant</returns>
        public async Task<PlantData> GetPlantData(String plantId)
        {
            var response = await PostMessageReturnResponse<PlantData>(new Uri(GrowattApiBaseUrl, PlantData + $"?plantId={plantId}"), new StringContent(""), HttpStatusCode.OK);
            return response;
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
            var response = await PostMessageReturnResponse<StorageStatusData>(new Uri(GrowattApiBaseUrl, StorageStatusData + $"?plantId={plantId}"), content, HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets storage battery chart data
        /// </summary>
        /// <returns>Gets storage battery chart data</returns>
        public async Task<StorageBatChartData> GetStorageBatChart(String plantId, String storageSn)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("storageSn", storageSn)
            });
            var response = await PostMessageReturnResponse<StorageBatChartData>(new Uri(GrowattApiBaseUrl, StorageBatChartData), content, HttpStatusCode.OK);
            return response;
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
            var response = await PostMessageReturnResponse<StorageEnergyDayChart>(new Uri(GrowattApiBaseUrl, StorageEnergyDayChartData), content, HttpStatusCode.OK);
            return response;
        }
    }
}