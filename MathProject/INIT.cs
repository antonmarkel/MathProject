using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Windows.Controls;

namespace MathProject
{
    static class INIT
    {
        public static List<Formul> UPLOAD_FORMULS()
        {
            FileStream fs = new FileStream(@"C:\Users\mr.Dmitry\source\repos\MathProject\MathProject\Data\formuls.json", FileMode.OpenOrCreate);
            List<Formul> DOWNLOAD;
            DOWNLOAD = JsonSerializer.Deserialize<List<Formul>>(fs) ?? new List<Formul>();

            return DOWNLOAD;

        }

        #region ToCreate
            public static void SAVE_DATA()
            {

            }
        #endregion



    }
}
