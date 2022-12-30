using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class ValueHandler : MonoBehaviour
{
    [SerializeField] 
    private Variable    value;
    [SerializeField, ShowIf("hasInternalValue")]
    public float currentValue = 0;
    [SerializeField, ShowIf("hasInternalValue")]
    public float defaultValue = 0;
    [SerializeField, ShowIf("hasInternalValue")]
    private bool hasLimits = true;
    [SerializeField, ShowIf("hasLimitsAndInternalValue")]
    private float minValue = -float.MaxValue;
    [SerializeField, ShowIf("hasLimitsAndInternalValue")]
    private float maxValue = float.MaxValue;
    [SerializeField]
    private UnityEvent  onChange;
    [SerializeField]
    private UnityEvent  onIncrease;
    [SerializeField]
    private UnityEvent  onDecrease;

    private bool hasInternalValue => value == null;
    private bool hasLimitsAndInternalValue => hasLimits && value == null;


    void Start()
    {
        if (value == null)
        {
            value = ScriptableObject.CreateInstance<Variable>();
            value.SetProperties(currentValue, defaultValue, hasLimits, minValue, maxValue);
        }
    }

    public void SetValue(float value)
    {
        float delta = value - this.value.currentValue;
        ChangeValue(value);
    }

    public void ChangeValue(float value)
    {
        //Debug.Log($"Change value {name}: Old = {this.value.currentValue}, New = {this.value.currentValue + value}");

        float prevValue = this.value.currentValue;

        this.value.ChangeValue(value);

        if (prevValue != this.value.currentValue)
        {
            onChange?.Invoke();
            if (value > 0) onIncrease?.Invoke();
            else if (value < 0) onDecrease?.Invoke();
        }
    }
}
