using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueDisplay_Progress : MonoBehaviour
{
    [SerializeField] private Variable       variable;
    [SerializeField] private RectTransform  fill;

    // Update is called once per frame
    void Update()
    {
        float t = (variable.currentValue - variable.minValue) / (variable.maxValue - variable.minValue);

        fill.localScale = new Vector2(t, 1.0f);
    }
}
