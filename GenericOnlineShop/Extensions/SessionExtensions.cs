using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text.Json;
using System.Data;

namespace GenericOnlineShop.Extensions
{
    public static class SessionExtensions
    {
        public static List<T> GetList<T>(this ISession session, string key)
        {
            string jsonData = session.GetString(key);
            if (jsonData == null)
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(jsonData);
        }

        public static void SetList<T>(this ISession session, string key, List<T> value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
    }
}
