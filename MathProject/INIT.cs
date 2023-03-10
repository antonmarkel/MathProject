using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathProject
{
    static class INIT
    {
        public static List<Formul> UPLOAD_FORMULS()
        {
            #region ToChange

            List<Formul> UPLOAD = new List<Formul>(100);
            for (int i = 0; i < 100; i++)
            {
                UPLOAD.Add( new Formul("formul_def" + i.ToString(), "formul_ans" + i.ToString()) );
            }
            return UPLOAD;

            #endregion
        }
    }
}
