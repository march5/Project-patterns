using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {

        public class Order
        {
            public string state;
            public Order()
            {
                this.state = "Created";
            }
        }

        public interface IMediator
        {
            void Notify(Order target, object sender, string ev);
        }

        public class ConcreteMediator : IMediator
        {
            private Receive receive;
            private Verify verify;
            private Execute execute;
            private LogToFile logToFile;
            private LogToBase logToBase;

            public ConcreteMediator(Receive rec, Verify ver, Execute exe, LogToFile log1, LogToBase log2)
            {
                this.receive = rec;
                this.receive.setMediator(this);
                this.verify = ver;
                this.verify.setMediator(this);
                this.execute = exe;
                this.execute.setMediator(this);
                this.logToFile = log1;
                this.logToFile.setMediator(this);
                this.logToBase = log2;
                this.logToBase.setMediator(this);
            }

            public void Notify(Order target, object sender, string ev)
            {
                if(ev == "Received")
                {
                    Console.WriteLine("Mediator reacts on Receive and triggers next operations...");

                    this.logToFile.Log("Order Received");
                    this.logToBase.Log();

                    this.verify.VerifyOrder(target);
                }
                if(ev == "Verified")
                {
                    Console.WriteLine("Mediator reacts on Receive and triggers next operations...");

                    this.logToFile.Log("Order Verified");
                    this.logToBase.Log();

                    this.execute.ExecuteOrder(target);
                }
                if(ev == "Completed")
                {
                    Console.WriteLine("Mediator reacts on Execute and triggers next operations...");

                    this.logToFile.Log("Order Completed");
                    this.logToBase.Log();
                }
            }
        }

        public class Component
        {
            protected IMediator mediator;

            public Component(IMediator mediator = null)
            {
                this.mediator = null;
            }

            public void setMediator(IMediator mediator)
            {
                this.mediator = mediator;
            }
        }

        public class Receive : Component
        {
            public void ReceiveOrder(Order target)
            {
                target.state = "Received";
                Console.WriteLine("Receive class processing Order");

                this.mediator.Notify(target, this, "Received");
            }
        }

        public class Verify : Component
        {
            public void VerifyOrder(Order target)
            {
                target.state = "Verified";
                Console.WriteLine("Verify class processing Order");

                this.mediator.Notify(target, this, "Verified");
            }
        }

        public class Execute : Component
        {
            public void ExecuteOrder(Order target)
            {
                target.state = "Completed";
                Console.WriteLine("Execute class completing Order");

                this.mediator.Notify(target, this, "Completed");
            }
        }

        public class LogToFile : Component
        {

            public void Log(string logs)
            { 
                Console.WriteLine("Writing logs to file");
            }
        }

        public class LogToBase : Component
        {
            public void Log()
            {
                Console.WriteLine("Writing logs to base");
            }
        }


        static void Main(string[] args)
        {
            Receive receive = new Receive();
            Verify verify = new Verify();
            Execute execute = new Execute();
            LogToFile logToFile = new LogToFile();
            LogToBase logToBase = new LogToBase();

            new ConcreteMediator(receive, verify, execute, logToFile, logToBase);

            Order target = new Order();

            receive.ReceiveOrder(target);
        }
    }
}
