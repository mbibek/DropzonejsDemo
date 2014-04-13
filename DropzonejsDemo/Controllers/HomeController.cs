using System.IO;
using System.Web;
using System.Web.Mvc;

namespace DropzonejsDemo.Controllers
{
    /// <summary>
    /// Different functions needed for perfomring file actions such as upload and delete
    /// <author>Bibek Maharjan</author>
    /// <Date>12/04/2014</Date>
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Gets the dropzone for uploading the file
        /// View: Views/Home/Index.cshtml
        /// </summary>
        /// <returns>Index View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Uploads the file
        /// </summary>
        /// <returns>null</returns>
        [HttpPost]
        public ActionResult Upload()
        {
            //Loop through the HttpFileCollection to get the keys (names) of the files
            foreach (string fileName in Request.Files)
            {
                //Use the key (filename) to get the HttpPostedFileBase object
                HttpPostedFileBase file = Request.Files[fileName];

                //Check for the null reference i.e file is not null and content length is greater than zero
                if (file != null && file.ContentLength > 0)
                {
                    //Give the directory name where the file will be uploaded
                    string path = Server.MapPath("/UploadImages/");

                    //Check if the directory exists
                    if(!Directory.Exists(path))
                        //Create the diretory
                        Directory.CreateDirectory(path);

                    //Get the name of the file being uploaded
                    string fName = file.FileName;

                    //Create full path combining path and fileName
                    string fullPath = Path.Combine(path + fName.ToString());

                    //Save the file
                    file.SaveAs(fullPath);
                }
                
            }
            //Return null for remaining in the same page
            return null;
        }
    }
}
