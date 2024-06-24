namespace Ealse.Growatt.Api.Helpers
{
    public static class NameHelper
    {
        public static string getSimSignalText(string rawName)
        {
            if (rawName == "modelText")
                return "Mode"; //模式
            else if (rawName == "simSignal")
                return "Signal"; //信号
            else if (rawName == "deviceType")
                return "Collector model"; //采集器型号
            else if (rawName == "firmwareVersion")
                return "Firmware Version"; //固件版本
            else if (rawName == "deviceTypeIndicate")
                return "Datalogger Type"; //采集器类型
            else if (rawName == "stateGrid")
                return "State Grid Data"; //国网数据
            else if (rawName == "stateGridModel")
                return "State Grid Data Version Module"; //国网数据版本模块
            else if (rawName == "fwVersion")
                return "Build number"; //内部版本号
            else if (rawName == "deviceModel")
                return "Device Model"; //设备型号
            else if (rawName == "innerVersion")
                return "Version"; //版本号
            else if (rawName == "communicationVersion")
                return "Communication version number"; //通讯版本号
            else if (rawName == "ipAndPort")
                return "Ip & Port"; //ip及端口号
            else if (rawName == "interval")
                return "Data Update Interval"; //间隔时间
            else if (rawName == "bdc1Sn")
                return "Serial"; //BDC序列号
            else if (rawName == "bdcStatus")
                return "Working state"; //连接状态
            else if (rawName == "bdc1ChargePower")
                return "Charging(W)"; //BDC充电功率
            else if (rawName == "bdc1DischargePower")
                return "Discharging(W)"; //BDC放电功率
            else if (rawName == "bdc1Vbat")
                return "Battery Voltage(V)"; //电池电压
            else if (rawName == "bdc1Ibat")
                return "Battery Current(A)"; //电池电流
            else if (rawName == "echargeToday")
                return "Daily Charge(kWh)"; //今日充电量
            else if (rawName == "edischargeToday")
                return "Daily Discharge(kWh)"; //今日放电量
            else if (rawName == "echargeTotal")
                return "Total Charged(kWh)"; //累计充电量
            else if (rawName == "edischargeTotal")
                return "Total Discharged(kWh)"; //累计放电量
            else if (rawName == "bdc1Version")
                return "Software Version"; //BDC的软件版本
            else if (rawName == "bdc1Model")
                return "model"; //BDC的model
            else if (rawName == "liBatteryManufacturers")
                return "Manufacturers of batteries"; //锂电池的厂家
            else if (rawName == "liBatteryFwVersion")
                return "BatteryFirmware Version"; //锂电池的固件版本
            else if (rawName == "dataLogSn")
                return "Data logger serial number"; //数据采集器序列号
            else if (rawName == "hardwareVersion")
                return "hardware version"; //硬件版本
            else if (rawName == "softwareVersion")
                return "Software Version"; //软件版本
            else if (rawName == "batSn")
                return "Battery serial number"; //电池序列号
            else if (rawName == "monitorVersion")
                return "BDTVersion"; //监控软件版本
            else if (rawName == "mcVersion")
                return "BCUVersion"; //电池主控软件版本号

            return string.Empty;
        }
    }
}