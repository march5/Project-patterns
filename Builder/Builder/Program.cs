using System;
using System.Collections.Generic;

namespace Builder
{
    class Program
    {

        public class Button
        {
            public string buttonName;
            public string buttonType;

            public Button(string n, string t)
            {
                buttonName = n;
                buttonType = t;
            }
            
        }

        public class FormBuilder
        {

            Form form;
            ButtonsBuilder buttonsBuilder;
            WelcomeMessageBuilder messageBuilder;

            public void constructForm()
            {
                this.form = new Form();

                this.form.buttons = buttonsBuilder.addButtons();

                this.form.welcomeMessage = messageBuilder.printVM();
                
            }
            
            public void setButtonsBuilder(ButtonsBuilder builder)
            {
                this.buttonsBuilder = builder;
            }

            public void setWMBuilder(WelcomeMessageBuilder builder)
            {
                this.messageBuilder = builder;
            }

            public Form getForm()
            {
                return form;
            }
        }

        public abstract class ButtonsBuilder
        {
            public abstract List<Button> addButtons();
        }

        public class StudentButtonsBuilder : ButtonsBuilder
        {
            public override List<Button> addButtons()
            {
                List<Button> buttons = new List<Button>();

                for(int i = 1; i <= 10; i++)
                {
                    buttons.Add(new Button("Button nr." + i, "normal"));
                }

                return buttons;
            }
        }

        public class AdminButtonsBuilder : ButtonsBuilder
        {
            public override List<Button> addButtons()
            {
                List<Button> buttons = new List<Button>();

                for (int i = 1; i <= 10; i++)
                {
                    buttons.Add(new Button("Button nr." + i, "admin"));
                }

                return buttons;
            }
        }

        public abstract class WelcomeMessageBuilder
        {
            public abstract string printVM();
        }

        public class StudentWMBuilder : WelcomeMessageBuilder
        {
            public override string printVM()
            {
                return "This is normal Welcome Message!";
            }
        }

        public class AdminWMBuilder : WelcomeMessageBuilder
        {
            public override string printVM()
            {
                return "This is admin Welcome Message";
            }
        }

        public class Form
        {
            public string welcomeMessage;

            public List<Button> buttons;

        }


        static void Main(string[] args)
        {
            FormBuilder fBuilder = new FormBuilder();
            StudentButtonsBuilder bBuilder = new StudentButtonsBuilder();
            StudentWMBuilder wmBuilder = new StudentWMBuilder();

            //AdminButtonsBuilder bBuilder = new AdminButtonsBuilder();
            //AdminWMBuilder wmBuilder = new AdminWMBuilder();

            fBuilder.setButtonsBuilder(bBuilder);
            fBuilder.setWMBuilder(wmBuilder);

            fBuilder.constructForm();

            Form form = fBuilder.getForm();

            Console.WriteLine(form.welcomeMessage);

            foreach(Button elem in form.buttons)
            {
                Console.WriteLine(elem.buttonName + " " + elem.buttonType);
            }
        }
    }
}
