using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DropzonejsDemo.Helper
{
    public static class HtmlHelperExtensions
    {
        private static readonly JsonSerializerSettings Settings;

        static HtmlHelperExtensions()
        {
            Settings = new JsonSerializerSettings();
            // CamelCase: "MyProperty" will become "myProperty"
            Settings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        }

        //public static JsonResult ToJson(this IEnumerable<object> value)
        //{
        //    return new JsonResult (JsonConvert.SerializeObject(value, Formatting.None, Settings));
        //}
    }
}