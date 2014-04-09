using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using DropzonejsDemo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DropzonejsDemo.Helper
{
    public static class ImageStoreExtensions
    {
        public static JsonResult ToJson(this List<ImageStoreModel> images)
        {
            var settings = JsonSerializerSettings;

            return Json(JsonConvert.SerializeObject(images, Formatting.None, settings), JsonRequestBehavior.AllowGet);
        }

        private static JsonResult Json(string p, JsonRequestBehavior jsonRequestBehavior)
        {
            throw new NotImplementedException();
        }

        private static JsonSerializerSettings JsonSerializerSettings
        {
            get
            {
                var settings = new JsonSerializerSettings();

                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                return settings;
            }
        }
    }
}