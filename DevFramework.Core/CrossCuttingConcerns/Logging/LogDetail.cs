using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; } //Namespace barndıran sınıf (yolu)
        public string MethodName { get; set; }//sınıftaki hangi metod olduğunu getirir.
        public List<LogParameter> Parameters { get; set; }
    }
}
