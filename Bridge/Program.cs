using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        public interface DateFormat
        {
            string write();
            string GetFormat();
        }
        public class YYYYMMDD : DateFormat
        {
            string date = "20220105";
            public string write()
            {
                return date;
            }
            public string GetFormat()
            {
                return "YYYYMMDD";
            }
        }
        public class MMDDYYYY : DateFormat
        {
            string date = "01052022";
            public string write()
            {
                return date;
            }
            public string GetFormat()
            {
                return "MMDDYYYY";
            }
        }

        class OutputFile
        {
            protected DateFormat date;

            public OutputFile(DateFormat date)
            {
                this.date = date;
            }

            public virtual string WriteXML()
            {
                return "Writing " + date.write() + " to XML";
            }
            public virtual string WriteCSV()
            {
                return "Writing " + date.write() + " to CSV";
            }
            public virtual string WriteFixed()
            {
                return "Writing " + date.write() + " to FIXED";
            }
        }

        static void Main(string[] args)
        {
            OutputFile output;

            output = new OutputFile(new YYYYMMDD());
            Console.WriteLine(output.WriteXML());

            output = new OutputFile(new MMDDYYYY());
            Console.WriteLine(output.WriteCSV());
        }
    }
}
