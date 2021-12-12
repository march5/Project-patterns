using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandAndMemento
{
    class Program
    {

        public interface ICommand
        {
            void Execute(Receiver receiver);
        }

        public class Receiver
        {
            public void DoSomething(string text)
            {
                Console.WriteLine(text);
            }
        }

        public class Refresh : ICommand
        { 
            public void Execute(Receiver receiver)
            {
                receiver.DoSomething("Refreshing window");
            }
        }

        public class Minimize : ICommand
        {
            public void Execute(Receiver receiver)
            {
                receiver.DoSomething("Minimizing window");
            }
        }

        public class Maximize : ICommand
        {
            public void  Execute(Receiver receiver)
            {
                receiver.DoSomething("Maximizing window");
            }
        }

        public class InvokerOriginator
        {
            Receiver receiver;

            ICommand refresh;
            ICommand minimize;
            ICommand maximize;

            private string state;

            public InvokerOriginator(string state)
            {
                this.state = state;
            }

            public void SetReceiver(Receiver receiver)
            {
                this.receiver = receiver;
            }

            public void SetRefresh(ICommand command)
            {
                this.refresh = command;
            }

            public void SetMinimize(ICommand command)
            {
                this.minimize = command;
                
            }

            public void SetMaximize(ICommand command)
            {
                this.maximize = command;
                
            }

            public void MinimizeWindow()
            {
                Console.WriteLine("Invoker minimizing window...");
                minimize.Execute(this.receiver);
                this.state = "minimized";
            }

            public void RefreshAndMaximize()
            {
                Console.WriteLine("Invoker refreshing and maximizing window");
                refresh.Execute(this.receiver);
                maximize.Execute(this.receiver);
                this.state = "maximized";
            }

            public IMemento save()
            {
                return new Memento(this.state);
            }

            public void Restore(IMemento memento)
            {
                if(!(memento is Memento))
                {
                    throw new Exception("Unknown memento class");
                }

                this.state = memento.GetState();
                Console.WriteLine("Originator state changed to " + this.state);
            }

            


        }
public interface IMemento
            {
                string GetName();
                string GetState();
                DateTime GetDate();
            }

            public class Memento : IMemento
            {
                private string state;

                private DateTime date;

                public Memento(string state)
                {
                    this.state = state;
                    this.date = DateTime.Now;
                }

                public string GetState()
                {
                    return this.state;
                }

                public string GetName()
                {
                    return $"{this.date} / ({this.state.Substring(0, 9)})...";
                }

                public DateTime GetDate()
                {
                    return this.date;
                }
            }

            public class Caretaker
            {
                private List<IMemento> mementos = new List<IMemento>();

                private InvokerOriginator originator = null;

                public Caretaker(InvokerOriginator originator)
                {
                    this.originator = originator;
                }

                public void Backup()
                {
                    Console.WriteLine("Saving originator state");
                    this.mementos.Add(this.originator.save());
                }

                public void Undo()
                {
                    if(this.mementos.Count == 0)
                    {
                        return;
                    }

                    var memento = this.mementos.Last();
                    this.mementos.Remove(memento);

                    Console.WriteLine("Restoring state to: " + memento.GetName());

                    try
                    {
                        this.originator.Restore(memento);
                    }
                    catch (Exception)
                    {
                        this.Undo();
                    }

                }

                public void ShowHistory()
                {
                    Console.WriteLine("History: ");

                    foreach(var memento in this.mementos)
                    {
                        Console.WriteLine(memento.GetName());
                    }
                }
            }

        static void Main(string[] args)
        {
            InvokerOriginator invoker = new InvokerOriginator("Initial state");
            Caretaker caretaker = new Caretaker(invoker);
            Receiver receiver = new Receiver();

            invoker.SetReceiver(receiver);
            invoker.SetRefresh(new Refresh());
            invoker.SetMinimize(new Minimize());
            invoker.SetMaximize(new Maximize());

            caretaker.Backup();
            invoker.MinimizeWindow();
            caretaker.Backup();
            Console.WriteLine();
            caretaker.Backup();
            invoker.RefreshAndMaximize();
            caretaker.Backup();

            Console.WriteLine();
            caretaker.ShowHistory();

            caretaker.Undo();

        }
    }
}
