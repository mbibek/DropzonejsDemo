using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web;

namespace DropzonejsDemo.Models
{
    public class ImageStoreModel
    {
        
        //-----------------------------------------------------------------------------------------------
        #region Public Methods

        public string Name { get; set; }
        public string Size { get; set; }
        public string FullPath { get; set; }
        public string IsSuccess { get; set; }
        public string Message { get; set; }

        #endregion
        //-----------------------------------------------------------------------------------------------

    }
}
