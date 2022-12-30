using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

[CreateAssetMenu(menuName = "KitBash/Variable")]
public class Variable : ScriptableObject
{
    [SerializeField]
    public float  currentValue = 0;
    [SerializeField]
    public float  defaultValue = 0;
    [SerializeField] 
    private bool  hasLimits = true;
    [SerializeField, ShowIf("hasLimits")] 
    public  float minValue = -float.MaxValue;
    [SerializeField, ShowIf("hasLimits")] 
    public  float maxValue = float.MaxValue;

    public void SetValue(float value)
    {
        currentValue = (hasLimits) ? (Mathf.Clamp(value, minValue, maxValue)) : (value);
    }

    public void ChangeValue(float value)
    {
        currentValue = (hasLimits) ? (Mathf.Clamp(currentValue + value, minValue, maxValue)) : (value);
    }

    public void ResetValue()
    {
        currentValue = defaultValue;
    }

    public void SetProperties(float currentValue, float defaultValue, bool hasLimits, float minValue, float maxValue)
    {
        this.currentValue = currentValue;
        this.defaultValue = defaultValue;
        this.hasLimits = hasLimits;
        this.minValue = minValue;
        this.maxValue = maxValue;
    }
}
