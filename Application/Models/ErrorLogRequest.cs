using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ErrorLogRequest
    {
        //public DateTime? CreatedDate { get; internal set; }

        public string ApplicationName { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Details { get; set; }
        //public string ErrorLogId { get; internal set; }
    }
}
