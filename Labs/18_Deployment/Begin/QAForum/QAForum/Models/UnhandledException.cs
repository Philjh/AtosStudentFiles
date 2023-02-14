using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.Models
{
    public class UnhandledException
    {
        public int UnhandledExceptionId { get; set; }
        public DateTime ExceptionDateTime { get; set; }
        public string? Path { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? BaseExceptionMessage { get; set; }
        public string? StackTrace { get; set; }
    }
}
