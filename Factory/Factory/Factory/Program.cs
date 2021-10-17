using System;

namespace Factory
{

    public abstract class Tax
    {

    }

    public abstract class SupplementaryPayment
    {
        public abstract void calculate();
    }

    public abstract class Factory
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            double baseAmount = 100000;

            /*Factory fact = Factory.get();
            SupplementPayment sp = fact.createSP();
            Double amountToTax = sp.calculate(baseAmount);
            Tax tax = fact.createTax();
            tax.calculate(amountToTax);*/
        }
    }
}
