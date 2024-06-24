using Ealse.Growatt.Api.Models;

namespace Ealse.Growatt.Api.Helpers
{
    public static class StatusHelper
    {
        public static string getDeviceTypeStatus(DeviceByPlant device)
        {
            string status;
            switch (device.DeviceTypeName)
            {
                case "max":
                    status = getMaxDeviceStatus(device.Status);
                    break;
                case "storage":
                    status = getStorageDeviceStatus(device.Status);
                    break;
                case "mix":
                    status = getMixDeviceStatus(device.Status);
                    break;
                case "pcs":
                    status = getPcsDeviceStatus(device.Status);
                    break;
                case "hps":
                    status = getHpsDeviceStatus(device.Status);
                    break;
                case "spa":
                    status = getSpaDeviceStatus(device.Status);
                    break;
                case "tlx":
                    status = getTlxDeviceStatus(device.Status);
                    break;
                case "pbd":
                    status = getPbdDeviceStatus(device.Status);
                    break;
                case "eybondInv":
                    status = getEybondDeviceStatus(device.Status);
                    break;
                case "igenInv":
                    status = getIgenDeviceStatus(device.Status, int.Parse(device.DeviceType));
                    break;
                case "pumper":
                    status = getPumperDeviceStatus(device.Status);
                    break;
                default:
                    status = "N/A (possible new device type?)";
                    break;
            }

            return status;
        }

        public static string getStorageDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "-1":
                    status = $"Lost ({deviceStatus})";
                    break;
                case "0":
                    status = $"Standby ({deviceStatus})";
                    break;
                case "1":
                    status = $"PV&Grid Supporting Loads ({deviceStatus})";
                    break;
                case "2":
                    status = $"Battery Discharging ({deviceStatus})";
                    break;
                case "3":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                case "4":
                    status = $"Flash ({deviceStatus})";
                    break;
                case "5":
                    status = $"MPPT charge ({deviceStatus})";
                    break;
                case "6":
                    status = $"AC charge ({deviceStatus})";
                    break;
                case "7":
                    status = $"PV&Grid Charging ({deviceStatus})";
                    break;
                case "8":
                    status = $"PV&Grid Charging+Grid Bypass ({deviceStatus})";
                    break;
                case "9":
                    status = $"PV Charging+Grid Bypass ({deviceStatus})";
                    break;
                case "10":
                    status = $"Grid Charging+Grid Bypass ({deviceStatus})";
                    break;
                case "11":
                    status = $"Grid Bypass ({deviceStatus})";
                    break;
                case "12":
                    status = $"PV Charging+Loads Supporting ({deviceStatus})";
                    break;
                case "13":
                    status = $"AC charge and Discharge ({deviceStatus})";
                    break;
                case "14":
                    status = $"Combine charge and Discharge ({deviceStatus})";
                    break;
                default:
                    status = $"Unknown ({deviceStatus})";
                    break;
            }

            return status;
        }

        public static string getMaxDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "-1":
                    status = $"Lost ({deviceStatus})";
                    break;
                case "1":
                    status = $"Connection ({deviceStatus})";
                    break;
                case "2":
                case "3":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                default:
                    status = $"Wait ({deviceStatus})";
                    break;
            }

            return status;
        }

        public static string getMixDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "-1":
                    status = $"Lost ({deviceStatus})";
                    break;
                case "0":
                    status = $"Standby ({deviceStatus})";
                    break;
                case "1":
                    status = $"Checking ({deviceStatus})";
                    break;
                case "3":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                case "4":
                    status = $"Burning ({deviceStatus})";
                    break;
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    status = $"Normal ({deviceStatus})";
                    break;
                default:
                    status = $"Unknown ({deviceStatus})";
                    break;
            }

            return status;
        }

        public static string getPcsDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "0":
                    status = $"Wait ({deviceStatus})";
                    break;
                case "1":
                    status = $"Checking ({deviceStatus})";
                    break;
                case "2":
                    status = $"Normal ({deviceStatus})";
                    break;
                case "3":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                case "4":
                    status = $"Permanent Fault ({deviceStatus})";
                    break;
                case "5":
                    status = $"Off Grid ({deviceStatus})";
                    break;
                case "6":
                    status = $"Single MPPT ({deviceStatus})";
                    break;
                default:
                    status = $"Lost ({deviceStatus})";
                    break;
            }

            return status;
        }

        public static string getHpsDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "0":
                    status = $"Wait ({deviceStatus})";
                    break;
                case "1":
                    status = $"Checking ({deviceStatus})";
                    break;
                case "2":
                    status = $"On-Grid ({deviceStatus})";
                    break;
                case "3":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                case "4":
                    status = $"Permanent Fault ({deviceStatus})";
                    break;
                case "5":
                    status = $"Off Grid ({deviceStatus})";
                    break;
                case "6":
                    status = $"Single MPPT mode ({deviceStatus})";
                    break;
                default:
                    status = $"Lost ({deviceStatus})";
                    break;
            }

            return status;
        }

        public static string getSpaDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "-1":
                    status = $"Lost ({deviceStatus})";
                    break;
                case "0":
                    status = $"Standby ({deviceStatus})";
                    break;
                case "1":
                    status = $"Checking ({deviceStatus})";
                    break;
                case "3":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                case "4":
                    status = $"Burning ({deviceStatus})";
                    break;
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    status = $"Normal ({deviceStatus})";
                    break;
                default:
                    status = $"Unknown ({deviceStatus})";
                    break;
            }

            return status;
        }

        public static string getTlxDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "0":
                    status = $"Standby ({deviceStatus})";
                    break;
                case "1":
                    status = $"Normal ({deviceStatus})";
                    break;
                case "2":
                    status = $"Off Grid ({deviceStatus})";
                    break;
                case "3":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                case "4":
                    status = $"Burning ({deviceStatus})";
                    break;
                case "5":
                case "6":
                case "7":
                case "8":
                    status = $"Checking ({deviceStatus})";
                    break;
                default:
                    status = $"Lost ({deviceStatus})";
                    break;
            }

            return status;
        }

        public static string getPbdDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "0":
                    status = $"Standby ({deviceStatus})";
                    break;
                case "1":
                    status = $"Normal ({deviceStatus})";
                    break;
                case "2":
                    status = $"Off Grid ({deviceStatus})";
                    break;
                case "3":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                case "4":
                    status = $"Burning ({deviceStatus})";
                    break;
                case "5":
                case "6":
                case "7":
                case "8":
                    status = $"Checking ({deviceStatus})";
                    break;
                default:
                    status = $"Lost ({deviceStatus})";
                    break;
            }

            return status;
        }

        public static string getEybondDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "0":
                    status = $"Connection ({deviceStatus})";
                    break;
                case "2":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                case "3":
                    status = $"Wait ({deviceStatus})";
                    break;
                default:
                    status = $"Lost ({deviceStatus})";
                    break;
            }

            return status;
        }

        public static string getIgenDeviceStatus(string deviceStatus, int deviceType)
        {
            string status;
            if (deviceType >= 20 && deviceType <= 30)
            {
                switch (deviceStatus)
                {
                    case "0":
                        status = $"Wait ({deviceStatus})";
                        break;
                    case "1":
                        status = $"Connection ({deviceStatus})";
                        break;
                    case "3":
                        status = $"Malfunction ({deviceStatus})";
                        break;
                    default:
                        status = $"Lost ({deviceStatus})";
                        break;
                }
            }
            else
            {
                switch (deviceStatus)
                {
                    case "0":
                        status = $"Wait ({deviceStatus})";
                        break;
                    case "1":
                    case "2":
                    case "3":
                        status = $"Connection ({deviceStatus})";
                        break;
                    case "4": // (status)>=4
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        status = $"Malfunction ({deviceStatus})";
                        break;
                    default:
                        status = $"Lost ({deviceStatus})";
                        break;
                }
            }

            return status;
        }

        public static string getPumperDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "1":
                case "2":
                case "3":
                    status = $"Normal ({deviceStatus})";
                    break;
                case "4":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                case "5":
                    status = $"Wait ({deviceStatus})";
                    break;
                default:
                    status = $"Lost ({deviceStatus})";
                    break;
            }

            return status;
        }

        public static string getGenericDeviceStatus(string deviceStatus)
        {
            string status;
            switch (deviceStatus)
            {
                case "0":
                    status = $"Wait ({deviceStatus})";
                    break;
                case "1":
                    status = $"Connection ({deviceStatus})";
                    break;
                case "2":
                    status = $"Checking ({deviceStatus})";
                    break;
                case "3":
                    status = $"Malfunction ({deviceStatus})";
                    break;
                case "4":
                    status = $"Keep ({deviceStatus})";
                    break;
                default:
                    status = $"Lost ({deviceStatus})";
                    break;
            }

            return status;
        }
    }
}