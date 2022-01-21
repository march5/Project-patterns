using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        public interface OutputFile
        {
            void WriteDate1(); //YYYYMMDD
            void WriteDate2(); //MMDDYYYY
            void WriteDate3(); //DDMMYY
        }

        public class XML : OutputFile
        {
            public void WriteDate1()
            {
                Console.WriteLine("XML representation");
                Console.WriteLine("2022-01-05");
            }
            public void WriteDate2()
            {
                Console.WriteLine("XML representation");
                Console.WriteLine("01-05-2022");
            }
            public void WriteDate3()
            {
                Console.WriteLine("XML representation");
                Console.WriteLine("05-01-22");
            }
        }

        public class CSV : OutputFile
        {
            public void WriteDate1()
            {
                Console.WriteLine("CSV representation");
                Console.WriteLine("2022-01-05");
            }
            public void WriteDate2()
            {
                Console.WriteLine("CSV representation");
                Console.WriteLine("01-05-2022");
            }
            public void WriteDate3()
            {
                Console.WriteLine("CSV representation");
                Console.WriteLine("05-01-22");
            }
        }

        public class FIXED : OutputFile
        {
            public void WriteDate1()
            {
                Console.WriteLine("FIXED representation");
                Console.WriteLine("2022-01-05");
            }
            public void WriteDate2()
            {
                Console.WriteLine("FIXED representation");
                Console.WriteLine("01-05-2022");
            }
            public void WriteDate3()
            {
                Console.WriteLine("FIXED representation");
                Console.WriteLine("05-01-22");
            }
        }

        public abstract class DateFormat
        {
            public string dateType;
            public OutputFile output;

            public DateFormat(OutputFile f)
            {
                output = f;
            }

            public abstract void write();

            public void writeDate1()
            {
                output.WriteDate1();
            }
            public void writeDate2()
            {
                output.WriteDate2();
            }
            public void writeDate3()
            {
                output.WriteDate3();
            }
        }

        public class Date1 : DateFormat
        {
            public Date1(OutputFile f)
                : base(f)
            {
                dateType = "YYYYMMDD";
            }
            public override void write()
            {
                base.writeDate1();
            }
        }
        public class Date2 : DateFormat
        {
            public Date2(OutputFile f)
                : base(f)
            {
                dateType = "MMDDYYYY";
            }
            public override void write()
            {
                base.writeDate2();
            }
        }
        public class Date3 : DateFormat
        {
            public Date3(OutputFile f)
                : base(f)
            {
                dateType = "DDMMYY";
            }
            public override void write()
            {
                base.writeDate3();
            }
        }

        static void Main(string[] args)
        {
            DateFormat f1 = new Date1(new XML());
            f1.write();
            DateFormat f2 = new Date2(new CSV());
            f2.write();
            DateFormat f3 = new Date3(new FIXED());
            f3.write();
            DateFormat f4 = new Date3(new XML());
            f4.write();
        }
    }
}
