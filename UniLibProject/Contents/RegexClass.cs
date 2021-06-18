using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace UniLibProject.Contents
{
    internal class RegexClass
    {
        //true means valid
       public static bool Username(string username)
        {
            if (!(username.Length >= 3 && username.Length <= 32))
            {
                return false;
            }
            return true;
        }

       public static bool Email(string username)
        {
            bool isEmail = Regex.IsMatch(username, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (isEmail == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       public static bool PhoneNumber(string input)
        {
            if (input.Length != 11)
            {
                return false;
            }
            if (!(input.All(char.IsDigit)))
            {
                return false;
            }
            if (!((int)Char.GetNumericValue(input[0]) == 0 && (int)Char.GetNumericValue(input[1]) == 9))
            {
                return false;
            }

            return true;
        }

       public static bool Password(string input)
        {
            if (!(input.Length >= 8 && input.Length <= 32))
            {
                return false;
            }
            int valid = 0;
            foreach (char ch in input)
            {
                if (char.IsUpper(ch))
                {
                    valid = 1;
                    break;
                }
            }
            if (valid == 0)
            {
                return false;
            }
            return true;
        }

       public static bool CVV(string input)
        {
            if (input.Length != 3 && input.Length != 4)
            {
                return false;
            }
            foreach (char ch in input)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

       public static bool CardNumber(string input)
        {
            if (input.Length != 16)
            {
                return false;
            }
            if (!(input.All(char.IsDigit)))
            {
                return false;
            }
            int sum = 0;
            int temp;
            for (int i = 0; i < 16; i++)
            {
                if (i % 2 == 0)
                {
                    temp = ((int)Char.GetNumericValue(input[i])) * 2;
                    if (temp > 9)
                    {
                        sum += ((temp - (temp % 10)) / 10 + (temp % 10));
                    }
                    else
                    {
                        sum += temp;
                    }
                }
                else
                {
                    sum += (int)Char.GetNumericValue(input[i]);
                }
            }
            if (sum % 10 != 0)
            {
                return false;
            }
            return true;
        }

       public static bool Expire(string _year, string _month)
        {
            int ExpYear = 0;
            bool result = int.TryParse(_year, out ExpYear);
            if (result == false)
            {
                return false;
            }

            int ExpMonth = 0;
            result = int.TryParse(_month, out ExpMonth);
            if (result == false)
            {
                return false;
            }

            DateTime today = DateTime.Today;
            int CurrentYear = int.Parse(today.ToString("yyyy"));
            int CurrentMonth = int.Parse(today.ToString("MM"));
            CurrentMonth += 3;
            if (CurrentMonth > 12)
            {
                CurrentMonth -= 12;
                CurrentYear += 1;
            }
            if ((ExpYear < CurrentYear))
            {
                return false;
            }
            else if ((ExpYear == CurrentYear) && (ExpMonth < CurrentMonth))
            {
                return false;
            }
            return true;
        }
    }
}