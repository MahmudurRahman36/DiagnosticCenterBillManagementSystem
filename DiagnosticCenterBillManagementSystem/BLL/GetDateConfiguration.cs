using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class GetDateConfiguration
    {
        public string GetDate(string date)
        {
            string newDate = date;
            if (date.Length == 15)
            {
                string[] substrings = date.Split(' ');
                string month = substrings[1];
                string day = substrings[2];
                string year = substrings[3];

                if (month.Equals("Jan"))
                {
                    month = "01";
                }
                else if (month.Equals("Feb"))
                {
                    month = "02";
                }
                else if (month.Equals("Mar"))
                {
                    month = "03";
                }
                else if (month.Equals("Apr"))
                {
                    month = "04";
                }
                else if (month.Equals("May"))
                {
                    month = "05";
                }
                else if (month.Equals("Jun"))
                {
                    month = "06";
                }
                else if (month.Equals("Jul"))
                {
                    month = "07";
                }
                else if (month.Equals("Aug"))
                {
                    month = "08";
                }
                else if (month.Equals("Sep"))
                {
                    month = "09";
                }
                else if (month.Equals("Oct"))
                {
                    month = "10";
                }
                else if (month.Equals("Nov"))
                {
                    month = "11";
                }
                else if (month.Equals("Dec"))
                {
                    month = "12";
                }
                newDate = day + "-" + month + "-" + year;
            }

            return newDate;
        }

        public double GetDateInDouble(string date)
        {
            string newDate = date;
            string[] substrings = date.Split('-');
            string day = substrings[0];
            if (Convert.ToInt32(day) < 10)
            {
                day = "0" + Convert.ToInt32(day);
            }
            string month = substrings[1];
            if (Convert.ToInt32(month) < 10)
            {
                month = "0" + Convert.ToInt32(month);
            }
            string year = substrings[2];
            newDate = year + month + day;
            double dateInDouble = Convert.ToDouble(newDate);
            return dateInDouble;
        }
    }
}