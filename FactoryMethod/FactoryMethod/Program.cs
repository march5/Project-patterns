using System;

namespace FactoryMethod
{
    class Program
    {
        public class Shape
        {
            public int a;
            public Shape()
            {
                a = 0;
            }

            public virtual void draw()
            {
                Console.WriteLine("*****");
            }

        }

        public class Square : Shape
        {
            public Square(int r)
            {
                a = r;
            }

            public override void draw()
            {
                int i = 0;
                while(i <= a)
                {
                    for (int j = a - i; j > 0; j--)
                        Console.Write(" ");
                    Console.WriteLine("*");
                    i++;
                }
                while(i <= a * 2)
                {
                    for (int j = 0; j < i - a; j++)
                        Console.Write(" ");
                    Console.WriteLine("*");
                    i++;
                }
            }
        }

        public class Rectangle : Shape
        {
            public Rectangle(int x)
            {
                a = x;
            }

            public override void draw()
            {
                for (int i = 0; i < a; i++) Console.Write("#");
                Console.WriteLine();
                for(int i = 0; i < a - 2; i++)
                {
                    Console.Write("#");
                    for (int j = 0; j < a - 2; j++) Console.Write(" ");
                    Console.WriteLine("#");
                }
                for (int i = 0; i < a; i++) Console.Write("#");
                Console.WriteLine();
            }
        }

        public class Triangle : Shape { 
            public Triangle(int h)
            {
                a = h;
            }

            public override void draw()
            {
                for (int i = 0; i < a / 2; i++) Console.Write(" ");
                Console.WriteLine("^");
                for (int i = 0; i < a; i++) Console.WriteLine();
                Console.Write("^");
                for (int i = 0; i <= a - 2; i++) Console.Write(" ");
                Console.WriteLine("^");
            }
        }

        public class ShapeCreator
        {
            public virtual Shape factory(int x)
            {
                return new Shape();
            }
        }

        public class SquareCreator : ShapeCreator
        {
            public override Square factory(int x)
            {
                return new Square(x);
            }
        }

        public class RectangleCreator : ShapeCreator
        {
            public override Rectangle factory(int x)
            {
                return new Rectangle(x);
            }
        }

        public class TriangleCreator: ShapeCreator
        {
            public override Triangle factory(int x)
            {
                return new Triangle(x);
            }
        }

        static void Main(string[] args)
        {
            RectangleCreator recCreate = new RectangleCreator();
            TriangleCreator trCreate = new TriangleCreator();

            Rectangle rec1 = recCreate.factory(4);
            Rectangle rec2 = recCreate.factory(5);
            Rectangle rec3 = recCreate.factory(6);

            Triangle tr1 = trCreate.factory(4);
            Triangle tr2 = trCreate.factory(5);
            Triangle tr3 = trCreate.factory(6);

            rec1.draw();
            rec2.draw();
            rec3.draw();
            tr1.draw();
            tr2.draw();
            tr3.draw();
        }
    }
}
