using System;

namespace Factory
{

    public abstract class Tax
    {
        public int threshold;

        public void calculate(double amountToTax)
        {
            double result = (amountToTax * threshold) / 100;
            Console.WriteLine("Tax: \n" + "Podstawa naliczenia: " + amountToTax + "\nProcent = " + threshold + "\nObliczona kwota = " + result);
        }
    }

    public class PolandTax : Tax
    {
        public PolandTax(string th)
        {
            if (th == "lower") threshold = 18;
            else threshold = 32;
        }
    }

    public class USATax : Tax
    {
        public USATax(string th)
        {
            if (th == "lower") threshold = 15;
            else threshold = 20;
        }
    }

    public class GermanyTax : Tax
    {
        public GermanyTax(string th)
        {
            if (th == "lower") threshold = 15;
            else threshold = 25;
        }
    }

    public abstract class SupplementaryPayment
    {
        public int threshold;
        public double calculate(double baseAmount)
        {
            double result = (baseAmount * threshold) / 100;
            Console.WriteLine("Supplementary Payment: \n" + "Podstawa naliczenia: " + baseAmount + "\nProcent = " + threshold + "\nObliczona kwota = " + result + "\n");
            return result;
        }
    }

    public class PolandSP : SupplementaryPayment 
    {
        public PolandSP(string th)
        {
            if (th == "lower") threshold = 28;
            else threshold = 42;
        }
    }

    public class USASP : SupplementaryPayment
    {
        public USASP(string th)
        {
            if (th == "lower") threshold = 20;
            else threshold = 40;
        }
    }

    public class GermanySP : SupplementaryPayment
    {
        public GermanySP(string th)
        {
            if (th == "lower") threshold = 25;
            else threshold = 45;
        }
    }

    public abstract class Factory
    {
        public string country;
        public string threshold;
        public static Factory get()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Admin\Desktop\Studia\wzorce projektowe\Project-patterns\Factory\config.txt");

            string c = lines[0].Substring(9);
            string t = lines[1].Substring(11);

            if (c == "Poland") return new PolandFactory(t);
            else if (c == "USA") return new USAFactory(t);
            else return new GermanyFacotry(t);
        }

        public abstract SupplementaryPayment createSP();

        public abstract Tax createTax();
    }

    public class PolandFactory : Factory 
    {
        public PolandFactory(string th)
        {
            country = "Poland";
            threshold = th;
        }

        public override SupplementaryPayment createSP()
        {
            return new PolandSP(threshold);
        }

        public override Tax createTax()
        {
            return new PolandTax(threshold);
        }
    }

    public class USAFactory : Factory
    {
        public USAFactory(string th)
        {
            country = "USA";
            threshold = th;
        }

        public override SupplementaryPayment createSP()
        {
            return new USASP(threshold);
        }

        public override Tax createTax()
        {
            return new USATax(threshold);
        }
    }

    public class GermanyFacotry : Factory
    {
        public GermanyFacotry(string th)
        {
            country = "Germany";
            threshold = th;
        }

        public override SupplementaryPayment createSP()
        {
            return new GermanySP(threshold);
        }

        public override Tax createTax()
        {
            return new GermanyTax(threshold);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            double baseAmount = 100000;

            Factory fact = Factory.get();
            SupplementaryPayment sp = fact.createSP();
            Double amountToTax = sp.calculate(baseAmount);
            Tax tax = fact.createTax();
            tax.calculate(amountToTax);
        }
    }
}
