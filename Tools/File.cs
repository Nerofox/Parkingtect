using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tools
{
    public class File
    {
        public static void UploadHttpFile(HttpPostedFileBase file, string destination)
        {
            if (file != null && file.ContentLength > 0)
            {
                file.SaveAs(destination);
            }
            else
            {
                throw new Exception("File invalid");
            }
        }

        public static void Delete(string path)
        {

        }
    }
}
