using System.Web;
using System.Web.Hosting;

namespace DropzonejsDemo.Helper
{
    public static class MyPath
    {
        private const string Pathinfo ="~/UploadImages/";

        public static string PathInfo 
        {
            get { return Pathinfo; }
        }

        ////public MyPath()
        ////{
        ////}

        ////public MyPath(string pathinfo)
        ////{
        ////    this._pathinfo = pathinfo;
        ////}
    }
}