namespace Ealse.Growatt.Api
{
    public class RelativeUrl
    {
        public string DataLoggerDeviceList { get; set; } = "device/getDatalogList";
        public string DeviceInfo { get; set; } = "panel/getDeviceInfo";
        public string DevicesByPlantList { get; set; } = "panel/getDevicesByPlantList";
        public string PlantFaultLog { get; set; } = "log/getNewPlantFaultLog";
        public string InverterEnergyDataDayChart { get; set; } = "energy/compare/getDevicesDayChart";
        public string InverterEnergyDataDay { get; set; } = "panel/inv/getInvDayChart";
        public string InverterEnergyDataMonthChart { get; set; } = "energy/compare/getDevicesMonthChart";
        public string InverterEnergyDataMonth { get; set; } = "panel/inv/getInvMonthChart";
        public string InverterEnergyDataTotalChart { get; set; } = "energy/compare/getDevicesTotalChart";
        public string InverterEnergyDataTotal { get; set; } = "panel/inv/getInvTotalChart";
        public string InverterEnergyDataYearChart { get; set; } = "energy/compare/getDevicesYearChart";
        public string InverterEnergyDataYea { get; set; } = "panel/inv/getInvYearChart";
        public string InverterTotals { get; set; } = "panel/inv/getInvTotalData";
        public string Login { get; set; } = "login";
        public string PlantData { get; set; } = "panel/getPlantData";
        public string PlantList { get; set; } = "index/getPlantListTitle";
        public string StorageBatChartData { get; set; } = "panel/storage/getStorageBatChart";
        public string StorageEnergyDayChartData { get; set; } = "panel/storage/getStorageEnergyDayChart";
        public string StorageStatusData { get; set; } = "panel/storage/getStorageStatusData";
        public string StorageTotalData { get; set; } = "panel/storage/getStorageTotalData";
        public string TcpSet { get; set; } = "tcpSet.do";
        public string WeatherByPlantId { get; set; } = "index/getWeatherByPlantId";
    }
}
