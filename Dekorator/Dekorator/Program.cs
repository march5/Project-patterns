using System;

namespace Dekorator
{
    class Program
    {

        public abstract class Bike
        {
            public abstract string operation();
        }

        public class RealBike : Bike
        {
            public override string operation()
            {
                return "bike";
            }
        }

        public abstract class BikeDecorator : Bike
        {
            protected Bike _bike;

            public BikeDecorator(Bike bike)
            {
                this._bike = bike;
            }

            public void setComponent(Bike bike)
            {
                this._bike = bike;
            }

            public override string operation()
            {
                if (this._bike != null)
                    return this._bike.operation();
                else
                    return string.Empty;
            }
        }

        public class RedBikeDecorator : BikeDecorator
        {
            public RedBikeDecorator(Bike bike) : base(bike)
            {
                
            }

            public override string operation()
            {
                return $"Red {base.operation()} ";
            }
        } 

        public class CheapBikeDecorator : BikeDecorator
        {
            public CheapBikeDecorator(Bike bike) : base(bike)
            {

            }

            public override string operation()
            {
                return $"Cheap {base.operation()} ";
            }
        }



        static void Main(string[] args)
        {
            CheapBikeDecorator cheap = new CheapBikeDecorator(new RealBike());
            RedBikeDecorator red = new RedBikeDecorator(new RealBike());
            CheapBikeDecorator cheapRed = new CheapBikeDecorator(new RedBikeDecorator(new RealBike()));



            Console.WriteLine(cheap.operation());
            Console.WriteLine(red.operation());
            Console.WriteLine(cheapRed.operation());


        }
    }
}
