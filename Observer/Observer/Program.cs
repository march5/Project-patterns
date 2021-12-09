using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {

        public interface IObserver
        {
            void Update(ISubject subject);
        }

        public interface ISubject
        {
            void Attach(IObserver observer);

            void Detach(IObserver observer);

            void Notify();
        }

        public class OnClick : ISubject
        {
            public int State { get; set; } = -0;

            private List<IObserver> observers = new List<IObserver>();

            public void Attach(IObserver observer)
            {
                this.observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                this.observers.Remove(observer);
            }

            public void Notify()
            {
                Console.WriteLine("OnClick notifying observers on client click");

                foreach (var observer in observers)
                {
                    observer.Update(this);
                }
            }

            public void Click(string target)
            {
                Console.WriteLine("Client just clicked on " + target);
                if (target == "pic") this.State = 1;
                else this.State = 2;

                Console.WriteLine("OnClick state just changed to: " + this.State);
                this.Notify();
            }
        }
        public class UnderPanel : IObserver
        {
            public void Update(ISubject subject)
            {
                if ((subject as OnClick).State == 1)
                {
                    Console.WriteLine("UnderPanel displays a picture clicked");
                }
            }
        }

        public class Panel : IObserver
        {
            public void Update(ISubject subject)
            {
                if ((subject as OnClick).State == 2)
                {
                    Console.WriteLine("Panel displays text clicked");
                }
            }
        }

        public class Window : IObserver
        {
            public void Update(ISubject subject)
            {
                Console.WriteLine("Window displays button after click");
            }
        }
        static void Main(string[] args)
        {
            OnClick onClick = new OnClick();
            UnderPanel underPanel = new UnderPanel();
            onClick.Attach(underPanel);

            Panel panel = new Panel();
            onClick.Attach(panel);

            Window window = new Window();
            onClick.Attach(window);

            onClick.Click("pic");
            Console.WriteLine();

            onClick.Click("text");
            Console.WriteLine();
        }
    }
}
