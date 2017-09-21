using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aanvragen.Web.Generators {
    public class PrefixNumberGenerator {
        public string Prefix() {
            DateTime dateTimeNow = DateTime.Now;
            string year = dateTimeNow.Year.ToString();
            string month = dateTimeNow.Month.ToString().PadLeft(2, '0');
            string day = dateTimeNow.Day.ToString().PadLeft(2, '0');
            string hour = dateTimeNow.Hour.ToString().PadLeft(2, '0');
            string minute = dateTimeNow.Minute.ToString().PadLeft(2, '0');

            string numberString = string.Format("{0}{1}{2}{3}{4}", year, month, day, hour, minute);

            return numberString;
        }
    }
}