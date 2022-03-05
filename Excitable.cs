using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Excitables represent a float value that tends towards a target.
    This version of excitables has two targets: baseValue and exciteValue.

    The entire point of this class is to help with smoothing over time. Rather than set volume from 0 to 1, smooth it through the excitable.
    Potential expansions include the use of easing functions. That's probably over-engineering.
*/


public class Excitable
{
    // Internally set
    float currValue;
    float targValue;

    // Externally set
    float baseValue;
    float exciteValue;
    float exciteRate;

    // Constructor
    public Excitable(float ExciteValue = 1f, float ExciteRate = 1f, float BaseValue = 0f)
    {
        baseValue = BaseValue;
        exciteValue = ExciteValue;
        exciteRate = ExciteRate;

        currValue = baseValue;
        targValue = baseValue;
    }

    // Magical atomic function. This is where the magic happens. Two things are done here:
    // 1. Update our current excitement level.
    // 2. Return our current excitement level.
    // It's fairly staightforward, but this saves many lines of code.
    public float pop()
    {
        if( currValue == targValue ) return currValue;
        if( currValue < targValue ) 
        {
            currValue += Time.deltaTime;
            if(currValue > targValue) currValue = targValue;
        }
        if( currValue > targValue )
        {
            currValue -= Time.deltaTime;
            if(currValue < targValue) currValue = targValue;
        }
        
        return currValue;
    }

    // Make the excitable tend towards it's high target (EG. 1f)
    // It also works for negative numbers. exciteValue could be -666 for all I care
    public void Activate()
    {
        targValue = exciteValue;
    }

    // Make the excitable tend towards its low target (USUALLY 0)
    // Works for any number, similar to exciteValue
    public void Deactivate()
    {
        targValue = baseValue;
    }
}
