using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyBus : LogBehaviour
{
    Dictionary<string, List<Action>> listeners = new Dictionary<string, List<Action>>();

    // Register event which doesn't require parameters
    public void register(string keyword, Action callback)
    {
        if(!listeners.ContainsKey(keyword)) 
        {
            listeners.Add(keyword, new List<Action>());
            LogInfo("created new event: " + keyword);
        }
        listeners[keyword].Add(callback);
        LogDebug("registered new callback to event: " + keyword);
    }

    // Invoke event which doesn't require parameters
    public void invoke(string keyword)
    {
        LogInfo( "invoked: " + keyword );
        if(listeners.ContainsKey(keyword))
        {
            foreach( Action callback in listeners[keyword] )
            {
                LogDebug( "invoked: " + keyword );
                callback.Invoke();
            }
        }
        else LogWarning( "failed to invoke: "+keyword );
    }
    
// The following code enables the usage of a Global LazyBus, in case I'm feeling extra lazy.
// All functionality is the same as an ordinary LazyBus. But you register/invoke using base class instead of an instantiated object.
#region globalBus
    static LazyBus _globalBus;
    static LazyBus globalBus
    {
        get
        {
            if(_globalBus == null)
            {
                GameObject instance = new GameObject("GlobalBus");
                instance.AddComponent<LazyBus>();
                _globalBus = instance.GetComponent<LazyBus>();
            }

            return _globalBus;
        }
    }

    public static void Register(string keyword, Action callback)
    {
        globalBus.register(keyword, callback);
    }

    public static void Invoke(string keyword)
    {
        globalBus.invoke(keyword);
    }
#endregion
}
