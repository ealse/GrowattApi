﻿using Ealse.Growatt.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ealse.Growatt.Api
{
    public partial class Session : IDisposable
    {
        public string DeviceInfo { get; set; } = "panel/getDeviceInfo";
        public string DevicesByPlantList { get; set; } = "panel/getDevicesByPlantList";
        public string InverterEnergyDataDayChartUrl { get; set; } = "energy/compare/getDevicesDayChart";
        public string InverterEnergyDataDayUrl { get; set; } = "panel/inv/getInvDayChart";
        public string InverterEnergyDataMonthChartUrl { get; set; } = "energy/compare/getDevicesMonthChart";
        public string InverterEnergyDataMonthUrl { get; set; } = "panel/inv/getInvMonthChart";
        public string InverterEnergyDataTotalChartUrl { get; set; } = "energy/compare/getDevicesTotalChart";
        public string InverterEnergyDataTotalUrl { get; set; } = "panel/inv/getInvTotalChart";
        public string InverterEnergyDataYearChartUrl { get; set; } = "energy/compare/getDevicesYearChart";
        public string InverterEnergyDataYearUrl { get; set; } = "panel/inv/getInvYearChart";
        public string LoginRelativeUrl { get; set; } = "login";
        public string PlantData { get; set; } = "panel/getPlantData";
        public string PlantList { get; set; } = "index/getPlantListTitle";
        public string StorageBatChartData { get; set; } = "panel/storage/getStorageBatChart";
        public string StorageEnergyDayChartData { get; set; } = "panel/storage/getStorageEnergyDayChart";
        public string StorageStatusData { get; set; } = "panel/storage/getStorageStatusData";
        public string StorageTotalData { get; set; } = "panel/storage/getStorageTotalData";
        public string TcpSet { get; set; } = "tcpSet.do";
        public string WeatherByPlantId { get; set; } = "index/getWeatherByPlantId";

        /// <summary>
        /// Gets data logger device information
        /// </summary>
        /// <returns>Data logger device information</returns>
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
        /// Gets devices by plant
        /// </summary>
        /// <returns>Devices by plant</returns>
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
        public async Task<List<double?>> GetPlantDetailDayChartData(string plantId, DateTime date, string serialNumber = null, string param = InverterPlantParameters.Power.Pac)
        {
            var jsonDataType = string.IsNullOrEmpty(serialNumber) ? "plant" : "inv";
            var sn = serialNumber ?? plantId;
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("date", date.ToString("yyyy-MM-dd")),
                new KeyValuePair<string, string>("jsonData", $"[{{\"type\":\"{jsonDataType}\",\"sn\":\"{sn}\",\"params\":\"{param}\"}}]"),
            });

            return await GetPostResponseData<List<double?>>(content, new Uri(GrowattApiBaseUrl, InverterEnergyDataDayChartUrl), $"obj.0.datas.{param}");
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

            return await GetPostResponseData<List<double?>>(content, new Uri(GrowattApiBaseUrl, InverterEnergyDataDayUrl), "obj.pac");
        }

        /// <summary>
        /// Gets amount of power generated for each day of the given month.
        /// </summary>
        /// <returns>Amount of power generated for each day of the given month.</returns>
        public async Task<List<double>> GetPlantDetailMonthChartData(string plantId, DateTime date, string serialNumber = null, string type = null, string param = "energy")
        {
            var jsonDataType = type is null ? string.IsNullOrEmpty(serialNumber) ? "plant" : "inv" : type;
            var sn = type is null && serialNumber != null ? serialNumber : plantId;
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("plantId", plantId),
                new KeyValuePair<string, string>("date", date.ToString("yyyy-MM")),
                new KeyValuePair<string, string>("jsonData", $"[{{\"type\":\"{jsonDataType}\",\"sn\":\"{sn}\",\"params\":\"{param}\"}}]"),
            });

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, InverterEnergyDataMonthChartUrl), $"obj.0.datas.{param}");
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

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, InverterEnergyDataTotalChartUrl), $"obj.0.datas.{param}");
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

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, InverterEnergyDataTotalUrl), "obj.energy");
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

            return await GetPostResponseData<List<double>>(content, new Uri(GrowattApiBaseUrl, InverterEnergyDataYearChartUrl), $"obj.0.datas.{param}");
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
        /// Gets current plant information of all plants.
        /// </summary>
        /// <returns>Current information of all plants</returns>
        public async Task<List<Plant>> GetPlantList()
        {
            return await GetResponseData<List<Plant>>(new Uri(GrowattApiBaseUrl, PlantList), string.Empty);
        }

        /// <summary>
        /// Gets storage battery chart data
        /// </summary>
        /// <returns>Storage battery chart data</returns>
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
        /// Gets storage device information
        /// </summary>
        public async Task<DeviceInfoStorage> GetStorageDeviceInfo(String plantId, String sn)
        /// <returns>Storage device information</returns>
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
        /// Gets storage battery chart data
        /// </summary>
        /// <returns>Storage battery chart data</returns>
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

        /// <summary>
        /// Gets status storage data by plant, inverter
        /// </summary>
        /// <returns>Status storage data by plant, inverter</returns>
        public async Task<StorageStatusData> GetStorageStatusDataByPlant(String plantId, String storageSn)
        {
            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("storageSn", storageSn) });
            return await GetPostResponseData<StorageStatusData>(content, new Uri(GrowattApiBaseUrl, StorageStatusData + $"?plantId={plantId}"), "obj");
        }

        /// <summary>
        /// Gets total storage data by plant, inverter
        /// </summary>
        /// <returns>Total storage data by plant, inverter</returns>
        public async Task<StorageTotalData> GetStorageTotalDataByPlant(string plantId, string storageSn)
        {
            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("storageSn", storageSn) });
            return await GetPostResponseData<StorageTotalData>(content, new Uri(GrowattApiBaseUrl, StorageTotalData + $"?plantId={plantId}"), "obj.datas");
        }

        /// <summary>
        /// Gets weather by plant
        /// </summary>
        /// <returns>Weather by plant</returns>
        public async Task<Weather> GetWeatherByPlant(string plantId)
        {
            return await GetPostResponseData<Weather>(new StringContent(string.Empty), new Uri(GrowattApiBaseUrl, WeatherByPlantId + $"?plantId={plantId}"), "obj");
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

            return await GetPostResponseData<SetSettingResponse>(new FormUrlEncodedContent(formDictionary), new Uri(GrowattApiBaseUrl, TcpSet), string.Empty);
        }
    }
}