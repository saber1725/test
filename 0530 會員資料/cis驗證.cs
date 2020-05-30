using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Web;

namespace 會員資料.Models
{
    public class cis驗證
    {
        

        public bool is快速註冊資料正確(cis會員資料 p)
        {
            if (!string.IsNullOrEmpty(p.is會員資料姓名) && !string.IsNullOrEmpty(p.is會員資料密碼) && !string.IsNullOrEmpty(p.is會員資料Email))
            {
                if (p.is會員資料姓名.Length < 11 && p.is會員資料密碼.Length<11)
                {
                    if (RegexUtilities.IsValidEmail(p.is會員資料Email)) {
                        if (RegexUtilities.IsValidPassWord(p.is會員資料密碼)) {
                            if (RegexUtilities.IsValidUserName(p.is會員資料姓名)) { 
                        return true;
                            }
                            else { return false; }
                        }
                        else { return false; }
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false;}
        }

        public class RegexUtilities
        {
            public static bool IsValidEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                try
                {
                    // Normalize the domain
                    email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                          RegexOptions.None, TimeSpan.FromMilliseconds(200));

                    // Examines the domain part of the email and normalizes it.
                    string DomainMapper(Match match)
                    {
                        // Use IdnMapping class to convert Unicode domain names.
                        var idn = new IdnMapping();

                        // Pull out and process domain name (throws ArgumentException on invalid)
                        var domainName = idn.GetAscii(match.Groups[2].Value);

                        return match.Groups[1].Value + domainName;
                    }
                }
                catch (RegexMatchTimeoutException e)
                {
                    return false;
                }
                catch (ArgumentException e)
                {
                    return false;
                }

                try
                {
                    return Regex.IsMatch(email,
                        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
            }

            public static bool IsValidPassWord(string password)
            {
                if (string.IsNullOrWhiteSpace(password))
                    return false;
                try { 
                string pattern = @"^(?=.*\d)(?=.*[a-zA-Z])(?=.*\W).{6,10}$";
                return Regex.IsMatch(password, pattern);
                }
                catch(Exception e) { return false; }                
            }

            public static bool IsValidUserName(string username)
            {
                if (string.IsNullOrWhiteSpace(username))
                    return false;
                try
                {
                    string pattern = @"^(?=*\d)(?=.*[\u4e00-\u9fa5].{2,10}";

                    return Regex.IsMatch(username , pattern);
                }

                catch(Exception e) { return false; }
            }
            

        }
    }
}