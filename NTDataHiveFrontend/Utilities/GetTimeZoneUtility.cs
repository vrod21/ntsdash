using System.Runtime.InteropServices;

namespace NTDataHiveFrontend.Utilities
{
    public class GetTimeZoneUtility
    {
        private readonly IConfiguration _config;
        public GetTimeZoneUtility(IConfiguration config)
        {
            _config = config;
        }

        //public GetTimeZoneUtility()
        //{
        //    DateTime dateTime = DateTime.Now;

        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //    {
        //        var tz = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
        //        DateTime tstTime = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local, tz);
        //        _myVar.IsDaylightSavingTime(dateTime);
        //    }

        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //    {
        //        var tz = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
        //        DateTime tstTime = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local, tz);
        //        _myVar.IsDaylightSavingTime(dateTime);
        //    }
        //    else throw new NotImplementedException("GetTimeZone() for this OS is not implemented.");
        //}                

        //public TimeZoneInfo timeZone
        //{
        //    get { 
        //        return _myVar;
        //    }            
        //}

        public TimeZoneInfo GetTimeZone()
        {

            TimeZoneInfo ret;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ret = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
                //DateTime dateTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, ret);
                //ret.IsDaylightSavingTime(dateTime);                
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                ret = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
                //DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, ret);
                //ret.IsDaylightSavingTime(tstTime);
            }
            else
                throw new NotImplementedException("GetTimeZone() for this OS is not implemented.");

            return ret;
        }

    }
}
