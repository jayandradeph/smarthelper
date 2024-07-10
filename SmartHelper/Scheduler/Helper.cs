using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHelper.Scheduler
{
    public static class CronHelper
    {
        public static string ExtractTime(string dateTimeString)
        {
            if (DateTime.TryParse(dateTimeString, out DateTime dateTime))
            {
                return dateTime.ToString("H:mm"); // Format the time part as "H:mm"
            }
            throw new ArgumentException("Invalid date-time format");
        }

        public static string ConvertTimeToCronExpression(string time)
        {
            if (TimeSpan.TryParse(time, out TimeSpan timeSpan))
            {
                int hours = timeSpan.Hours;
                int minutes = timeSpan.Minutes;
                return $"0 {minutes} {hours} 1/1 * ? *";
            }
            throw new ArgumentException("Invalid time format");
        }
    }
}
