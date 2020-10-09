using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer.Teletubbies
{
    public enum TubbieCommands
    {
        Wakeup,
        Eatdinner,
        Watchtv,
        Byebye
    }
    public class Teletubbie : IObserver<TubbieCommands>

    {
        private IDisposable unsubscriber;
        private string _name;
        public Teletubbie(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return this._name; }
        }

        public virtual void Subscribe(IObservable<TubbieCommands> provider)
        {
            if (provider != null)
            {
                unsubscriber = provider.Subscribe(this);
            }
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("The big telephone has stopped commanding {0}", this.Name);
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("{0}: The command cannot be determined", this.Name);
        }

        public virtual void OnNext(TubbieCommands command)
        {
            Console.WriteLine("{0} is commanded to {1}",this.Name, command.ToString());
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
