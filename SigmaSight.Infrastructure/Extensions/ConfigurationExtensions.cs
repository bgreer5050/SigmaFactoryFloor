using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.Binder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaSight.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetObject<T>(this IConfiguration configuration, string key, T defaultValue = default) where T : class, new()
        {
            var configurationSection = configuration.GetSection(key);
            return configurationSection == null ? defaultValue :
                GetObject(configurationSection, defaultValue);
        }

        public static T GetObject<T>(this IConfigurationSection configurationSection, T defaultValue = default) where T : class, new()
        {
            var result = ConfigurationBinder.Get<T>(configurationSection);
            return result ?? JsonConvert.DeserializeObject<T>(configurationSection.Value) ?? defaultValue;
        }
    }
}
