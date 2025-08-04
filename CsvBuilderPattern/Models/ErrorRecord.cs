using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsvBuilderPattern.Models
{
    public class ErrorRecord
    {
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}