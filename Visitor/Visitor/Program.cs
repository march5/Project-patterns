using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {

        public interface AutoPart
        {
            void Accept(IVisitor visitior);
            int FabricationCost();
            int FabricationTime();
            int AvgUsageTime();
            int YearlyCost();
        }

        public class ElectricalPart : AutoPart
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
            public int FabricationCost()
            {
                return 100;
            }

            public int FabricationTime()
            {
                return 10;
            }
            public int AvgUsageTime()
            {
                return 12;
            }
            public int YearlyCost()
            {
                return 50;
            }
        }

        public class SuspensionPart : AutoPart
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
            public int FabricationCost()
            {
                return 75;
            }
            public int FabricationTime()
            {
                return 6;
            }
            public int AvgUsageTime()
            {
                return 8;
            }
            public int YearlyCost()
            {
                return 60;
            }
        }

        public class BodyPart : AutoPart
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
            public int FabricationCost()
            {
                return 50;
            }
            public int FabricationTime()
            {
                return 4;
            }
            public int AvgUsageTime()
            {
                return 24;
            }
            public int YearlyCost()
            {
                return 75;
            }
        }

        public interface IVisitor
        {
            void Visit(ElectricalPart part);
            void Visit(SuspensionPart part);
            void Visit(BodyPart part);
        }

        public class FabCostVisitor : IVisitor
        {
            public void Visit(ElectricalPart part)
            {
                Console.WriteLine("Fabrication cost of electrical part is " + part.FabricationCost());
            }

            public void Visit(SuspensionPart part)
            {
                Console.WriteLine("Fabrication cost of suspension part is " + part.FabricationCost());
            }
            public void Visit(BodyPart part)
            {
                Console.WriteLine("Fabrication cost of body part is " + part.FabricationCost());
            }
        }

        public class FabTimeVisitor : IVisitor
        {
            public void Visit(ElectricalPart part)
            {
                Console.WriteLine("Fabrication time of electrical part is " + part.FabricationTime());
            }

            public void Visit(SuspensionPart part)
            {
                Console.WriteLine("Fabrication time of suspension part is " + part.FabricationTime());
            }
            public void Visit(BodyPart part)
            {
                Console.WriteLine("Fabrication time of body part is " + part.FabricationTime());
            }
        }

        public class AvgUsageVisitor : IVisitor
        {
            public void Visit(ElectricalPart part)
            {
                Console.WriteLine("Average usage time of electrical part is " + part.AvgUsageTime());
            }

            public void Visit(SuspensionPart part)
            {
                Console.WriteLine("Average usage time of suspension part is " + part.AvgUsageTime());
            }
            public void Visit(BodyPart part)
            {
                Console.WriteLine("Average usage time of body part is " + part.AvgUsageTime());
            }
        }

        public class YearlyCOstVisitor : IVisitor
        {
            public void Visit(ElectricalPart part)
            {
                Console.WriteLine("Yearly cost of electrical part is " + part.YearlyCost());
            }

            public void Visit(SuspensionPart part)
            {
                Console.WriteLine("Yearly cost time of suspension part is " + part.YearlyCost());
            }
            public void Visit(BodyPart part)
            {
                Console.WriteLine("Yearly cost time of body part is " + part.YearlyCost());
            }
        }

        public class Client
        {
            public static void ClientCode(List<AutoPart> parts,IVisitor visitor)
            {
                foreach(var part in parts)
                {
                    part.Accept(visitor);
                }
            }
        }

        static void Main(string[] args)
        {
            List<AutoPart> parts = new List<AutoPart>
            {
                new ElectricalPart(),
                new SuspensionPart(),
                new BodyPart()
            };

            var Visitor1 = new FabCostVisitor();
            var Visitor2 = new FabTimeVisitor();
            var Visitor3 = new AvgUsageVisitor();
            var Visitor4 = new YearlyCOstVisitor();

            Client.ClientCode(parts, Visitor1);
            Console.WriteLine();

            Client.ClientCode(parts, Visitor2);
            Console.WriteLine();

            Client.ClientCode(parts, Visitor3);
            Console.WriteLine();

            Client.ClientCode(parts, Visitor4);
            Console.WriteLine();
        }
    }
}
