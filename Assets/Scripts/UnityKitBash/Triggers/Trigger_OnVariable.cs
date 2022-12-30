using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_OnVariable : Trigger
{
    [System.Serializable] private enum Comparison { Equal, Less, LessEqual, Greater, GreaterEqual };

    [SerializeField] private Variable   variable;
    [SerializeField] private Comparison comparison;
    [SerializeField] private float      value;
    [SerializeField] private bool       percentageCompare = false;
    [SerializeField] private bool       negate;
    [SerializeField] private bool       singleTrigger = false;

    private bool firstTime = true;
    private bool prevValue = false;

    private void Update()
    {
        bool b = false;

        float currentValue = variable.currentValue;
        if (percentageCompare)
        {
            currentValue = 100 * (currentValue - variable.minValue) / (variable.maxValue - variable.minValue);
        }

        switch (comparison)
        {
            case Comparison.Equal:
                b = (currentValue == value);
                break;
            case Comparison.Less:
                b = (currentValue < value);
                break;
            case Comparison.LessEqual:
                b = (currentValue <= value);
                break;
            case Comparison.Greater:
                b = (currentValue > value);
                break;
            case Comparison.GreaterEqual:
                b = (currentValue >= value);
                break;
            default:
                break;
        }

        if (negate) b = !b;

        if (b) 
        {
            if (firstTime) ExecuteTrigger();
            else if (!prevValue) ExecuteTrigger();

            if (singleTrigger)
            {
                Destroy(this);
            }
        }

        prevValue = b;
        firstTime = false;
    }
}
