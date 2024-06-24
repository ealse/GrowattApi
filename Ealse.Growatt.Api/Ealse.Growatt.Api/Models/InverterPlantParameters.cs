namespace Ealse.Growatt.Api.Models
{
    public class InverterPlantParameters
    {
        public class Current
        {
            public const string Mppt1 = "IPV1";
            public const string Mppt2 = "IPV2";
            public const string Mppt3 = "IPV3";
            public const string String1 = "cString1";
            public const string String2 = "cString2";
            public const string String3 = "cString3";
            public const string String4 = "cString4";
            public const string String5 = "cString5";
            public const string String6 = "cString6";
            public const string String7 = "cString7";
            public const string String8 = "cString8";
        }

        public class Power
        {
            public const string MpptPower = "ppv";
            public const string Pac = "pac";
            public const string Power1 = "ppv1";
            public const string Power2 = "ppv2";
            public const string Power3 = "ppv3";
            public const string RPhasePower = "pacr";
            public const string SPhasePower = "pacs";
            public const string TPhasePower = "pact";
        }

        public class Voltage
        {
            public const string Mppt1 = "VPV1";
            public const string Mppt2 = "VPV2";
            public const string Mppt3 = "VPV3";
            public const string String1 = "vString1";
            public const string String2 = "vString2";
            public const string String3 = "vString3";
            public const string String4 = "vString4";
            public const string String5 = "vString5";
            public const string String6 = "vString6";
            public const string String7 = "vString7";
            public const string String8 = "vString8";
        }
    }
}