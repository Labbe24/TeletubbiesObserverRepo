using System;
using System.Collections.Generic;

namespace DesignPatterns.Observer.Teletubbies
{
    public class BigTelephone : IObservable<TubbieCommands>
    {
        public BigTelephone()
        {
            observers = new List<IObserver<TubbieCommands>>();
        }

        private List<IObserver<TubbieCommands>> observers;

        public IDisposable Subscribe(IObserver<TubbieCommands> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<TubbieCommands>> _observers;
            private IObserver<TubbieCommands> _observer;

            public Unsubscriber(List<IObserver<TubbieCommands>> observers, IObserver<TubbieCommands> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }

        public void Notify(TubbieCommands command)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(command);
            }
        }

        public void EndCommanding()
        {
            foreach (var observer in observers)
            {
                if (observers.Contains(observer))
                {
                    observer.OnCompleted();
                }
            }
            observers.Clear();
        }
    }
}