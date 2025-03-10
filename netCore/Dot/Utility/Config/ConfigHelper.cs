﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Dot.Config.Model;

namespace Dot.Utility.Config
{
    public class ConfigHelper
    {
        /// <summary>
        /// 获取配置文件中的AppSettings的指定键的值，并转换为指定类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetValueOrDefault<T>(string key, T defaultValue = default(T))
            where T : struct
        {
            var value = GetValueOrDefault(key);
            if (!string.IsNullOrWhiteSpace(value))
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter.CanConvertFrom(typeof(string)))
                {
                    try
                    {
                        return (T)converter.ConvertFromString(value);
                    }
                    catch { }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// 获取配置文件中的AppSettings的指定键的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetValueOrDefault(string key, string defaultValue = "")
        {
            if (null != PlatformConfig.ServerConfig
               && null != PlatformConfig.ServerConfig.KeyValueSettings
               && PlatformConfig.ServerConfig.KeyValueSettings[key] != null)
                return PlatformConfig.ServerConfig.KeyValueSettings[key].Value;
            var value = ($"{Configuration[key]}");
            return !string.IsNullOrEmpty(value) ? value : defaultValue;
        }

        static IConfigurationRoot configuration;
        public static IConfigurationRoot Configuration
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();
                }
                return configuration;
            }
        }
        /// <summary>
        /// 获取配置文件中的AppSettings的指定键的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetAppSettingOrDefault(string key, string defaultValue = "")
        {
            var value = ($"{Configuration[key]}");
            return !string.IsNullOrEmpty(value) ? value : defaultValue;
        }


        /// <summary>
        /// 获取配置文件中的ConnectionString的指定键的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetConnectionStringOrDefault(string key, string defaultValue = "")
        {
            return Configuration.GetConnectionString(key) ?? defaultValue;
        }

        /// <summary>
        /// 获取配置文件路径
        /// 可以为每个公司配置不同的配置文件
        /// </summary>
        /// <param name="dirPath">配置文件所在文件夹</param>
        /// <param name="configName">配置文件名</param>
        /// <param name="company">配置文件所属公司</param>
        /// <returns></returns>
        public static string GetConfigPath(string dirPath, string configName, string company)
        {
            var files = System.IO.Directory.GetFiles(dirPath, configName + "*");
            var companyConfig = files.FirstOrDefault(m => m.Contains(company));
            if (string.IsNullOrWhiteSpace(companyConfig))
                return files.FirstOrDefault();
            else
                return companyConfig;
        }

        /// <summary>
        /// 获取环境变量
        /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetEnvironmentVariables(string key= "PATH")
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            var configuration = builder.Build();
            var path = configuration.GetSection(key)?.Value;
            return path;
        }

        public string ASPNETCORE_ENVIRONMENT
        {
            get { return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"); }
        }
        
        ///// <summary>
        ///// 是否存在key配置项
        ///// </summary>
        ///// <param name="key">不区分大小写</param>
        ///// <returns></returns>
        //public static bool ExistsAppSetting(string key)
        //{
        //    return ConfigurationManager.AppSettings.AllKeys.Any(k => k.Equals(key, StringComparison.OrdinalIgnoreCase));
        //}
        //public static void SetAppSetting(string key, string value)
        //{
        //    SetAppSetting(null, key, value);
        //}

        //public static void SetAppSetting(string exePath, string key, string value)
        //{
        //    Configuration config;
        //    if (string.IsNullOrWhiteSpace(exePath))
        //    {
        //        config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    }
        //    else
        //    {
        //        config = ConfigurationManager.OpenExeConfiguration(exePath);
        //    }

        //    if (config.AppSettings.Settings[key] != null)
        //        config.AppSettings.Settings[key].Value = value;
        //    else
        //        config.AppSettings.Settings.Add(key, value);

        //    config.Save(ConfigurationSaveMode.Modified);
        //    ConfigurationManager.RefreshSection("appSettings");
        //}

        //public static void SetConnectionString(string key, string value)
        //{
        //    SetConnectionString(null, key, value);
        //}
        //public static void SetConnectionString(string exePath, string key, string value)
        //{
        //    Configuration config;
        //    if (string.IsNullOrWhiteSpace(exePath))
        //    {
        //        config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    }
        //    else
        //    {
        //        config = ConfigurationManager.OpenExeConfiguration(exePath);
        //    }

        //    if (config.ConnectionStrings.ConnectionStrings[key] != null)
        //        config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
        //    else
        //        config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(key, value));

        //    config.Save(ConfigurationSaveMode.Modified);
        //    ConfigurationManager.RefreshSection("appSettings");
        //}


    }
}
