using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApplicationsErrorlog
    {
        public Guid Id { get; init; }
        public string ErrorLogId { get; set; }
        public string ApplicationName { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Details { get; set; }
        public DateTimeOffset CreatedDate { get; set; } 
    }
}
