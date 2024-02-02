using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject 
{
    void Attach(IObserver observer, string key);
    void Detach(string key);
    void NotifyObserver(string key);
}

