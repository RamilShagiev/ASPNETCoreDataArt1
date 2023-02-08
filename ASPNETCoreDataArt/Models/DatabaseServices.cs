using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;

namespace ASPNETCoreDataArt.Models
{
    public class DatabaseServices
    {
        // Transform date to ID
        public int Transform(DateTime date)
        {

            // FORMULA START

            DateTime firstDay = new DateTime(2023, 1, 1);
            TimeSpan daysHavePassed = date - firstDay;

            int transformResult = daysHavePassed.Days;

            // FORMULA END
            return transformResult;
        }
    }
}
