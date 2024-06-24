using Ealse.Growatt.Api.Models;

namespace Ealse.Growatt.Api.Helpers
{
    public static class StatusHelper
    {
        public static string GetDeviceTypeStatus(DeviceByPlant device)
        {
            string status;

            switch (device.DeviceTypeName)
            {
                case "max":
                    status = GetMaxDeviceStatus(device.Status);
                    break;
                case "storage":
                    status = GetStorageDeviceStatus(device.Status);
                    break;
                case "mix":
                    status = GetMixDeviceStatus(device.Status);
                    break;
                case "pcs":
                    status = GetPcsDeviceStatus(device.Status);
                    break;
                case "hps":
                    status = GetHpsDeviceStatus(device.Status);
                    break;
                case "spa":
                    status = GetSpaDeviceStatus(device.Status);
                    break;
                case "tlx":
                    status = GetTlxDeviceStatus(device.Status);
                    break;
                case "pbd":
                    status = GetPbdDeviceStatus(device.Status);
                    break;
                case "eybondInv":
                    status = GetEybondDeviceStatus(device.Status);
                    break;
                case "igenInv":
                    status = GetIgenDeviceStatus(device.Status, int.Parse(device.DeviceType));
                    break;
                case "inv":
                    status = GetMixDeviceStatus(device.Status);
                    break;
                case "pumper":
                    status = GetPumperDeviceStatus(device.Status);
                    break;
                default:
                    status = "N/A (possible new device type?)";
                    break;
            }

            return status;
        }

        public static string GetStorageDeviceStatus(string deviceStatus)
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

        public static string GetMaxDeviceStatus(string deviceStatus)
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

        public static string GetMixDeviceStatus(string deviceStatus)
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

        public static string GetPcsDeviceStatus(string deviceStatus)
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

        public static string GetHpsDeviceStatus(string deviceStatus)
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

        public static string GetSpaDeviceStatus(string deviceStatus)
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

        public static string GetTlxDeviceStatus(string deviceStatus)
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

        public static string GetPbdDeviceStatus(string deviceStatus)
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

        public static string GetEybondDeviceStatus(string deviceStatus)
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

        public static string GetIgenDeviceStatus(string deviceStatus, int deviceType)
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

        public static string GetPumperDeviceStatus(string deviceStatus)
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

        public static string GetGenericDeviceStatus(string deviceStatus)
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