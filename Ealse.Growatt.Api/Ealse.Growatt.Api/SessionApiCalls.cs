using System;
using System.Threading.Tasks;
using System.Net;
using Ealse.Growatt.Api.Models;
using System.Linq;
using System.Collections.Generic;

namespace Ealse.Growatt.Api
{
    public partial class Session : IDisposable
    {
        public string LoginRelativeUrl => "newLoginAPI.do";

        public string PlantRelativeUrl => "newPlantAPI.do";

        public string PlantListRelativeUrl => "PlantListAPI.do";

        public string PlantDetailRelativeUrl => "newPlantDetailAPI.do";

        public string InverterRelativeUrl => "newInverterAPI.do";

        /// <summary>
        /// Gets current plant information of all plants.
        /// </summary>
        /// <returns>Current information of all plants</returns>
        public async Task<PlantList> GetPlantList()
        {
            var response = await GetMessageReturnResponse<PlantList>(new Uri(GrowattApiBaseUrl, PlantListRelativeUrl), HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets inverter Serial numbers and some inverter information data
        /// </summary>
        /// <returns>Inverter Serial numbers and some inverter information data</returns>
        public async Task<NewPlant> GetInverterSerialNumbers(string plantId)
        {
            var response = await GetMessageReturnResponse<NewPlant>(new Uri(GrowattApiBaseUrl, $"{PlantRelativeUrl}?op=getAllDeviceListThree&pageNum=1&pageSize=15&plantId={plantId}" ), HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets Inverter production data
        /// </summary>
        /// <returns>Unknown</returns>
        public async Task<InverterData> GetInverterProductionData(string serialNumber, DateTime date)
        {
            var dateString = date.ToString("yyyy-MM-dd");
            var response = await GetMessageReturnResponse<InverterData>(new Uri(GrowattApiBaseUrl, $"{InverterRelativeUrl}?op=getInverterData&type=1&date={dateString}&id={serialNumber}" ), HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets amount of power generated on each half hour of the given day.
        /// </summary>
        /// <returns>Amount of power generated on each half hour of the given day.</returns>
        public async Task<PlantDetailDay> GetPlantDetailDayData(string plantId, DateTime date)
        {
            var dateString = date.ToString("yyyy-MM-dd");
            var response = await GetMessageReturnResponse<PlantDetailDay>(new Uri(GrowattApiBaseUrl, $"{PlantDetailRelativeUrl}?plantId={plantId}&type=1&date={dateString}"), HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets amount of power generated for each day of the given month.
        /// </summary>
        /// <returns>Amount of power generated for each day of the given month.</returns>
        public async Task<PlantDetailMonth> GetPlantDetailMonthData(string plantId, DateTime date)
        {
            var dateString = date.ToString("yyyy-MM");
            var response = await GetMessageReturnResponse<PlantDetailMonth>(new Uri(GrowattApiBaseUrl, $"{PlantDetailRelativeUrl}?plantId={plantId}&type=2&date={dateString}"), HttpStatusCode.OK);
            response.Data = response.Data.ToDictionary(o => new DateTime(date.Year, date.Month, o.Key.Day), o => o.Value);
            return response;
        }

        /// <summary>
        /// Gets amount of power generated for each month of the given year.
        /// </summary>
        /// <returns>Amount of power generated for each month of the given year.</returns>
        public async Task<PlantDetailYear> GetPlantDetailYearData(string plantId, DateTime date)
        {
            var response = await GetMessageReturnResponse<PlantDetailYear>(new Uri(GrowattApiBaseUrl, $"{PlantDetailRelativeUrl}?plantId={plantId}&type=3&date={date.Year}"), HttpStatusCode.OK);
            response.Data = response.Data.ToDictionary(o => new DateTime(date.Year, o.Key.Month, date.Day), o => o.Value);
            return response;
        }

        /// <summary>
        /// Gets amount of power generated for each year
        /// </summary>
        /// <returns>Amount of genereted power for each year</returns>
        public async Task<PlantDetailTotal> GetPlantDetailTotalData(string plantId)
        {
            var response = await GetMessageReturnResponse<PlantDetailTotal>(new Uri(GrowattApiBaseUrl, $"{PlantDetailRelativeUrl}?plantId={plantId}&type=4"), HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Gets information about the user currently loggedin and some login information
        /// </summary>
        /// <returns>Information about the current user</returns>
        public async Task<LoginInfo> GetUserData()
        {
            return await GetNewSession();
        }
    }
}