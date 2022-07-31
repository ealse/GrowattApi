namespace Ealse.Growatt.Api.Helpers
{
    public static class SignalHelper
    {
        public static string getSimSignalText(int simSignal, string deviceTypeIndicate) {
            string signalText = "";

            if(deviceTypeIndicate == "11" || deviceTypeIndicate == "16")
            {
                    if(simSignal <= 0 && simSignal >= -50)
                    {
                        signalText = "Excellent ("+simSignal+")";
                    }
                    else if(simSignal <= -51 && simSignal >= -75)
                    {
                        signalText= "Good ("+simSignal+")";
                    }
                    else if(simSignal <= -76 && simSignal >= -113)
                    {
                        signalText = "Poor ("+simSignal+")";
                    }
                    else
                    {
                        signalText = "No";
                    }
            }
            else
            {
                if(simSignal <= -51 && simSignal >= -70) 
                {
                    signalText= "Excellent ("+simSignal+")";
                }
                else if(simSignal <= -71 && simSignal >= -85)
                {
                    signalText = "Good ("+simSignal+")";
                }
                else if(simSignal <= -86 && simSignal >= -113)
                {
                    signalText = "Poor ("+simSignal+")";
                }
                else
                {
                    signalText = "No";
                }
            }

            return signalText;
        }
    }
}