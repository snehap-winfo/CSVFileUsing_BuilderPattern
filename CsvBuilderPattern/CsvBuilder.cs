using CsvBuilderPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsvBuilderPattern
{
    
        public interface ICsvBuilder<ErrorRecord>
        {
            ErrorRecord Build(IEnumerable<string> input);
        }
        public class CsvBuilder : ICsvBuilder<ErrorRecord>
        {
            public ErrorRecord Build(IEnumerable<string> input)
            {
                var num = input.ToList();

                string errorCode = num.Count > 0 ? num[0] : "Unknown";
                string errorMessage = num.Count > 1 ? num[1] : "No message provided";
                bool date;

                //DateTime tDate;
                //if (num.Count > 2)
                //{
                //    date = DateTime.TryParseExact(num[2], "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out  tDate);


                //}
                //DateTime transactionDate = tDate;

                return new ErrorRecord
                {
                    errorCode = errorCode,
                    errorMessage = errorMessage,
                    TransactionDate = DateTime.Now

                };
            }
        }

    }
