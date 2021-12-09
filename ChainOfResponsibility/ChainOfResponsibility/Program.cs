using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {

        public interface IHandler
        {
            IHandler SetNext(IHandler handler);

            object Handle(object request);
        }

        abstract class AbstractHandler : IHandler
        {
            private IHandler nextHandler;

            public IHandler SetNext(IHandler handler)
            {
                this.nextHandler = handler;
                return handler;
            }

            public virtual object Handle(object request)
            {
                if (this.nextHandler != null)
                    return this.nextHandler.Handle(request);
                else return null;
            }
        }

        class UnderPanel : AbstractHandler
        {
            public override object Handle(object request)
            {
                if((request as string) == "pic")
                {
                    Console.WriteLine("UnderPanel displays a picture clicked");
                }

                return base.Handle(request);
            }
        }

        class Panel : AbstractHandler
        {
            public override object Handle(object request)
            {
                if ((request as string) == "text")
                    Console.WriteLine("Panel displays text clicked");
                return base.Handle(request);
            }
        }

        class Window : AbstractHandler
        {
            public override object Handle(object request)
            {
                Console.WriteLine("Window displays button after click");
                return base.Handle(request);
            }
        }

        class OnClick
        {
            public static void Click(AbstractHandler handler)
            {
                foreach(var click in new List<string>{"pic", "text" })
                {
                    Console.WriteLine("Client clicked on " + click);

                    var result = handler.Handle(click);
                }
            }
        }

        static void Main(string[] args)
        {
            UnderPanel underPanel = new UnderPanel();
            Panel panel = new Panel();
            Window window = new Window();

            underPanel.SetNext(panel).SetNext(window);

            OnClick.Click(underPanel);
            Console.WriteLine();
        }
    }
}
