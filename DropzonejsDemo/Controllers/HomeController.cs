using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DropzonejsDemo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DropzonejsDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly string _path = System.Web.HttpContext.Current.Server.MapPath("/UploadedImages/");

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {

            List<ImageStoreModel> images = new List<ImageStoreModel>();

            for(int index = 0; index < Request.Files.Count; index++)
            {
                HttpPostedFileBase file = Request.Files[index];

                //Save file content goes here
                if(file != null && file.ContentLength > 0)
                {
                    string fullPath = CreatePath(_path, file.FileName);

                    try
                    {
                        file.SaveAs(fullPath);

                        images.Add(new ImageStoreModel()
                        {
                            Name = file.FileName,
                            Size = file.ContentLength.ToString(),
                            FullPath = fullPath,
                            IsSuccess = "True",
                            Message = file.FileName + " uploaded successfully."
                        });

                    }
                    catch(Exception)
                    {

                        images.Add(new ImageStoreModel()
                        {
                            Name = file.FileName,
                            Size = file.ContentLength.ToString(),
                            FullPath = fullPath,
                            IsSuccess = "False",
                            Message = file.FileName + " was not uploaded. Please try again and if the problem persists, please cantact system admin/ vendor."
                        });
                    }
                }

            }
            if(Request.IsAjaxRequest())
            {
                return JsonResult(images);
            }
            else
            {
                return RedirectToAction("PostUpload");
            }
        }

        [HttpPost]
        public JsonResult DeleteFile(string data)
        {
            ImageStoreModel image = new ImageStoreModel();

            if(Directory.Exists(_path))
            {
                string fullPath = Path.Combine(_path, data);

                FileInfo fileInfo = new FileInfo(fullPath);

                if(fileInfo.Exists)
                {
                    fileInfo.Delete();
                    image.Name = data;
                    image.Size = fileInfo.Length.ToString();
                    image.FullPath = fullPath;
                    image.IsSuccess = "True";
                    image.Message = data + " is deleted succesfully.";
                }
            }

            return JsonResult(image);

        }

        public JsonResult DownloadFiles()
        {
            List<ImageStoreModel> images = new List<ImageStoreModel>();

            if(Directory.Exists(_path))
            {
                var files = Directory.GetFiles(_path);

                foreach(var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string fullPath = Path.Combine(_path, fileName);

                    FileInfo fileInfo = new FileInfo(fullPath);

                    string fileSize = fileInfo.Length.ToString();

                    if (fileInfo.Extension.ToLower() == ".jpg" || fileInfo.Extension.ToLower() == ".png" || fileInfo.Extension.ToLower() == ".bmp")
                        images.Add(new ImageStoreModel() { Name = fileName, Size = fileSize, IsSuccess = "True" });
                }

            }
            else
            {
                images.Add(new ImageStoreModel() { Name = "", Size = "", IsSuccess = "False" });
            }



            return JsonResult(images);
        }

        
        private string CreatePath(string filePath, string fileName)
        {

            CreateDirectory(filePath);

            var fullPath = Path.Combine(filePath, fileName);
            return fullPath;
        }

       
        private static void CreateDirectory(string pathString)
        {
            bool isExists = System.IO.Directory.Exists(pathString);

            if(!isExists)
                System.IO.Directory.CreateDirectory(pathString);
        }

        private JsonResult JsonResult(List<ImageStoreModel> images)
        {
            var settings = new JsonSerializerSettings();

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return Json(JsonConvert.SerializeObject(images, Formatting.None, settings), JsonRequestBehavior.AllowGet);
        }

        private JsonResult JsonResult(ImageStoreModel image)
        {
            var settings = new JsonSerializerSettings();

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return Json(JsonConvert.SerializeObject(image, Formatting.None, settings), JsonRequestBehavior.AllowGet);
        }
    }
}