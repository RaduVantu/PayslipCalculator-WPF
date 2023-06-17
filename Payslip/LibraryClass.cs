using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payslip
{
    class LibraryClass
    {
        public static bool CheckDouble(string valueToCheck)
        {
            if (double.TryParse(valueToCheck, out double result) == true && valueToCheck.Contains("-") == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckValue(string valueToCheck)
        {
            if (double.TryParse(valueToCheck, out double result) == true &&
                double.Parse(valueToCheck) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double Unit(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            else
            {
                if (LibraryClass.CheckDouble(value) == true)
                {
                    return double.Parse(value);
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
