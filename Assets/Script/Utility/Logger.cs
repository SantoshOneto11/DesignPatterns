using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Utility
{
    public enum LogLevels { DEBUG, INFO, WARN, ERROR };
    public enum LogCategory { UI, AUDIO, VIDEO, ANIMATION, PHYSICS, SERVER, OTHER }

    public class Logger
    {
        // Assigning Color
        private const string infoColor = nameof(Color.white);
        private const string warnColor = nameof(Color.yellow);
        private const string errorColor = nameof(Color.red);


        private static string FormatMessage(string color, string message, LogCategory category = LogCategory.UI)
        {
            return $"<color=\"{color}\">[{category}]</color> {message}";
        }

        public static void myLog(string message)
        {
            Debug.Log(DateTime.Now.ToString() + " " + message);
        }

        public static void myLog(int data)
        {
            Debug.Log(DateTime.Now.ToString() + " " + data);
        }

        public static void myLog(string message, LogCategory category = LogCategory.OTHER)
        {
            Debug.Log(DateTime.Now.ToString() + " " + FormatMessage(warnColor, message, category));
        }

        public static void myLog(string message, LogLevels level = LogLevels.DEBUG)
        {
            string msg = $"{DateTime.Now.ToString()} [{level}] {message}";

            switch (level)
            {
                case LogLevels.DEBUG:
                    Debug.Log(msg); break;
                case LogLevels.INFO:
                    Debug.Log(msg); break;
                case LogLevels.WARN:
                    Debug.LogWarning(msg); break;
                case LogLevels.ERROR:
                    Debug.LogError(msg); break;
                default:
                    Debug.Log(msg); break;
            }
        }

        public static void myWarnnig(string message)
        {
            Debug.LogWarning(DateTime.Now.ToString() + " " + message);
        }

        public static void myError(string message)
        {
            Debug.LogError(DateTime.Now.ToString() + " " + message);
        }

        public static string EncryptMsg(string data, int key)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                char ch = (char)(data[i] ^ key);
                stringBuilder.Append(ch);
            }
            return stringBuilder.ToString();
        }

        public static string ConvertSHA256(string data)
        {
            using (HMACSHA256 hmacsha256 = new HMACSHA256())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(data);
                byte[] hashByte = hmacsha256.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in hashByte)
                {
                    stringBuilder.Append(item);
                }
                return stringBuilder.ToString();
            }
        }

        public static string ConvertSHA256WithKey(string data, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            using (HMACSHA256 hmac = new HMACSHA256(keyBytes))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(data);
                byte[] hashBytes = hmac.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }

}
