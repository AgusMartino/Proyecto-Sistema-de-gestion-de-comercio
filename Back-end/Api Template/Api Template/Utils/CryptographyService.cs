using System.Collections.Generic;
using Api_Template.Models.Template;
using Api_Template.Entities;
using Api_Template.Contracts;
using System;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel;

namespace Api_Template.Utils
{
    /// <summary>
    /// Brinda funciones de encriptación y hashing.
    /// </summary>
    public static class CryptographyService
    {
        static Random rd = new Random();
        public static string RandomString(int length, AllowedChars allowedChars = AllowedChars.AlphanumericUpperLower)/*!@$?_-*/
        {
            string allowedCharsValue = EnumHelper.GetDescription(allowedChars);

            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedCharsValue[rd.Next(0, allowedCharsValue.Length)];
            }

            return new string(chars);
        }
        public static string Hash_SHA256(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }
        public static string GetSalt()
        {
            return Guid.NewGuid().ToString();
        }

        public enum AllowedChars
        {
            [Description("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")]
            AlphanumericUpperLower,
            [Description("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")]
            AlphanumericUpper,
            [Description("abcdefghijklmnopqrstuvwxyz0123456789")]
            AlphanumericLower,
            [Description("0123456789")]
            Numeric,
            [Description("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
            Upper,
            [Description("abcdefghijklmnopqrstuvwxyz")]
            Lower
        }
    }
}
