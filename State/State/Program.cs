using System;

namespace State
{
    class Program
    {

        public abstract class State
        {
            protected Context context;

            public void SetContext(Context context)
            {
                this.context = context;
            }

            public abstract void Validate();

            public abstract void Invalidate();

            public abstract void Replace();

            public abstract void IsIncluded();

            public abstract void IsInvalid();

            public abstract void Mine();

            public abstract void Commit();
        }

        public class Context
        {
            public State state = null;
            public Item item = new Item();

            public Context(State state)
            {
                this.Transition(state);
            }

            public void Transition(State state)
            {
                Console.WriteLine($"Transition to {state.GetType().Name}");
                this.state = state;
                this.state.SetContext(this);
            }

        }

        public class Created : State
        {
            public override void Validate()
            {
                this.context.item.text += "item validated";
                Console.WriteLine("Created item being validated");
                this.context.Transition(new Valid());
            }

            public override void Invalidate()
            {
                this.context.item.text += "item not validated";
                Console.WriteLine("Created item is not being validated");
                Console.WriteLine("Created state changing state context");
                this.context.Transition(new Invalid());
            }

            public override void IsIncluded()
            {
                throw new NotImplementedException();
            }

            public override void IsInvalid()
            {
                throw new NotImplementedException();
            }

            public override void Mine()
            {
                throw new NotImplementedException();
            }

            public override void Replace()
            {
                throw new NotImplementedException();
            }

            public override void Commit()
            {
                throw new NotImplementedException();
            }
        }

        public class Valid : State
        {
            public override void Validate()
            {
                throw new NotImplementedException();
            }

            public override void Invalidate()
            {
                throw new NotImplementedException();
            }

            public override void IsIncluded()
            {
                Console.WriteLine("Included in new block");
                this.context.item.text += "in block";
                this.context.Transition(new Mined());
            }

            public override void Replace()
            {
                Console.WriteLine("Branch replaced");
                this.context.Transition(new Invalid());
            }

            public override void IsInvalid()
            {
                throw new NotImplementedException();
            }

            public override void Mine()
            {
                throw new NotImplementedException();
            }

            public override void Commit()
            {
                throw new NotImplementedException();
            }
        }

        public class Invalid : State
        {
            public override void Validate()
            {
                throw new NotImplementedException();
            }

            public override void Invalidate()
            {
                throw new NotImplementedException();
            }

            public override void IsIncluded()
            {
                throw new NotImplementedException();
            }

            public override void IsInvalid()
            {
                Console.WriteLine("Invalid item");
            }

            public override void Mine()
            {
                throw new NotImplementedException();
            }

            public override void Replace()
            {
                throw new NotImplementedException();
            }

            public override void Commit()
            {
                throw new NotImplementedException();
            }
        }

        public class Mined : State
        {
            public override void Validate()
            {
                throw new NotImplementedException();
            }
            public override void Invalidate()
            {
                throw new NotImplementedException();
            }
            public override void IsIncluded()
            {
                throw new NotImplementedException();
            }
            public override void IsInvalid()
            {
                throw new NotImplementedException();
            }
            public override void Mine()
            {
                Console.WriteLine("Building new block");
                this.context.item.minedCount++;
                this.context.item.text += " [block]";
                Console.WriteLine(context.item.minedCount + " block mined");
            }
            public override void Replace()
            {
                throw new NotImplementedException();
            }
            public override void Commit()
            {
                Console.WriteLine("Commiting block");
                this.context.Transition(new Commited());
            }
        }

        public class Commited : State
        {
            public override void Commit()
            {
                throw new NotImplementedException();
            }
            public override void Invalidate()
            {
                throw new NotImplementedException();
            }
            public override void IsIncluded()
            {
                throw new NotImplementedException();
            }
            public override void IsInvalid()
            {
                throw new NotImplementedException();
            }
            public override void Mine()
            {
                throw new NotImplementedException();
            }
            public override void Replace()
            {
                throw new NotImplementedException();
            }
            public override void Validate()
            {
                throw new NotImplementedException();
            }
        }

        public class Item
        {
            public string text = "";
            public int minedCount = 0;
        }

        static void Main(string[] args)
        {
            var context = new Context(new Created());
            context.state.Validate();
            context.state.IsIncluded();
            context.state.Mine();
            context.state.Commit();

            Console.WriteLine();

            context = new Context(new Created());
            context.state.Invalidate();

            Console.WriteLine();

            context = new Context(new Created());
            context.state.Validate();
            context.state.Replace();
        }
    }
}
