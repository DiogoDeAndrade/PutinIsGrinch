using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Pulse : Trigger
{
    [SerializeField] public string pulseString = "1111111";
    [SerializeField] public float  pulseDuration = 0.1f;

    public override void ExecuteTrigger()
    {
        StartCoroutine(ExecuteTriggerCR());
    }

    IEnumerator ExecuteTriggerCR()
    { 
        for (int i = 0; i < pulseString.Length; i++)
        {
            if ((pulseString[i] == '1') || (pulseString[i] == 'x'))
            {
                base.ExecuteTrigger();
            }
            yield return new WaitForSeconds(pulseDuration);
        }
    }
}
