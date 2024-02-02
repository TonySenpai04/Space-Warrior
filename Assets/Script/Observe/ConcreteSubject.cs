using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteSubject :ISubject
{
    public ConcreteSubject() { }
    private Dictionary<string, IObserver> observers = new Dictionary<string, IObserver>();

    public void Attach(IObserver observer, string key)
    {
        observers[key] = observer;
    }

    public void Detach(string key)
    {
        if (observers.ContainsKey(key))
        {
            observers.Remove(key);
        }
    }

    public void NotifyObserver(string key)
    {
        if (observers.ContainsKey(key))
        {
            observers[key].Update();
        }
    }
}
