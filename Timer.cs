using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Timer keeps time. That's it. It's gonna save you many lines of code

    How many times have you written the following pattern:
        void Update()
        if( currCooldown > maxCooldown ) currCooldown = 0; doSomething();
        else currCooldown += Time.deltaTime;

    NO MORE! USE THIS SCRIPT AND STOP REWRITING THE SAME THING
*/

public class Timer
{
    // MaxCount = maxDuration, count = currDuratino
    float maxCount;
    float count = 0f;
    
    // Constructor
    public Timer(float MaxCount)
    {
        maxCount = MaxCount;
    }

    public void setMax(float MaxCount)
    {
        maxCount = MaxCount;
    }

    public void reset()
    {
        count = 0f;
    }

    // Push the timeline forward f seconds
    public void push(float f)
    {
        count += f;
    }

    // This is where the magic lies! Pop is an atomic function with two uses:
    //  1. Determine and return whether the timer popped off
    //  2. UPDATE the timer's count variable.
    // BECAUSE OF #2, YOU MUST CALL POP ONCE NO MORE NO LESS IN THE MASTERS UPDATE LOOP
    public bool pop()
    {
        if(count >= maxCount)
        {
            count = 0f;
            return true;
        }
        else
        {
            count += Time.deltaTime;
            return false;
        }
    }
}
