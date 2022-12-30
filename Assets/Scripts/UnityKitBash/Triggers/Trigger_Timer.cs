using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Trigger_Timer : Trigger
{
    [SerializeField, MinMaxSlider(1, 10)]
    private Vector2Int      triggerCount = new Vector2Int(1,1);
    [SerializeField, MinMaxSlider(0.0f, 10.0f)]
    private Vector2         timeInterval = new Vector2(5.0f, 5.0f);

    private float timer;

    void Start()
    {
        timer = Random.Range(timeInterval.x, timeInterval.y);        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            int n = Random.Range(triggerCount.x, triggerCount.y);
            for (int i = 0; i < n; i++)
            {
                ExecuteTrigger();
            }

            timer += Random.Range(timeInterval.x, timeInterval.y);
        }
    }
}
