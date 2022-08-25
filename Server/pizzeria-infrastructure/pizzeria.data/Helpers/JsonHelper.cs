using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace pizzeria.data.Helpers
{
    public static class JsonHelper
    {
        private static string basePath = @"K:\Practical\Pizzeria\Server\pizzeria-api\Assets\Database";

        public static List<T> GetAll<T>(string tableName)
        {
            List<T> result = new List<T>();
            if (!string.IsNullOrEmpty(tableName))
            {
                var json = File.ReadAllText(GetFilePath(tableName));
                try
                {
                    //var jObject = JObject.Parse(json);
                    //var tableSet = jObject[tableName] as JArray;
                    //if (tableSet != null)
                    //    result = tableSet.ToObject<List<T>>();
                    var format = "dd/MM/yyyy hh:mm:ss"; // your datetime format
                    var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
                    List<T> jsonResult = JsonConvert.DeserializeObject<List<T>>(json, dateTimeConverter);
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return result;
        }

        public static T GetDataById<T>(string tableName, int id)
        {
            T result = default;
            string path = GetFilePath(tableName);
            if (!string.IsNullOrEmpty(path) && id > 0)
            {
                string json = File.ReadAllText(path);
                try
                {
                    var jObject = JObject.Parse(json);
                    var tableSet = jObject[tableName] as JArray;
                    if (tableSet != null)
                    {
                        var token = tableSet.FirstOrDefault(tb => tb != null && tb["Id"].Value<int>() == id);
                        if (token != null)
                            result = token.ToObject<T>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return result;
        }

        public static T Add<T>(string tableName, T entity)
        {
            string path = GetFilePath(tableName);
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    var json = File.ReadAllText(path);
                    var format = "dd/MM/yyyy hh:mm:ss"; // your datetime format
                    var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
                    List<T> jsonResult = JsonConvert.DeserializeObject<List<T>>(json, dateTimeConverter);
                    if (jsonResult != null)
                    {
                        jsonResult.Add(entity);
                        string newJsonResult = JsonConvert.SerializeObject(jsonResult);
                        File.WriteAllText(path, newJsonResult);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return entity;
        }

        private static string GetFilePath(string tableName)
        {
            string fileURL = null;
            if (!string.IsNullOrEmpty(tableName))
                fileURL = Path.Combine(basePath, $"{tableName}.json");
            return fileURL;
        }
    }
}
