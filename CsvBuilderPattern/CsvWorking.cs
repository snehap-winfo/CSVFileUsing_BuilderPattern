using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvBuilderPattern.Models;
using System.IO;



namespace CsvBuilderPattern
{
    public class CsvWorking<T>
    {
        private ICsvBuilder<T> record;
        public CsvWorking(ICsvBuilder<T> record)
        {
            this.record = record;

        }
        public List<T> GetRecords(string filepath)
        {
            var records = new List<T>();
            foreach (var line in File.ReadAllLines(filepath).Skip(1))
            {
                var values = line.Split(',');
                var rec = record.Build(values);
                records.Add(rec);
            }
            return records;
        }
    }

}