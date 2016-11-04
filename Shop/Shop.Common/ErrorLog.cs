using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebLibs;

namespace Shop.Common
{
    public class ErrorLog
    {
        public void WriteLog(Exception objEx, string ipError, string actionError,
            string moduleName, string createdUser)
        {
            IData objData = new IData();
            try
            {
                objData.Connect();
                objEx.SaveLogToDB<IData>(objData, MethodBase.GetCurrentMethod().ReflectedType.Namespace, createdUser, actionError);
            }
            finally
            {
                objData.DeConnect();
            }
        }
    }
}
