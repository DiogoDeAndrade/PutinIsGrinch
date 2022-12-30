using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueDisplay_Image : MonoBehaviour
{
    [SerializeField] private Variable variable;

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(i < variable.currentValue);
            i++;
        }
    }
}
