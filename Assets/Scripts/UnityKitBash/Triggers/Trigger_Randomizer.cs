using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Randomizer : Trigger
{
    [SerializeField] Trigger[]  choiceTriggers;

    public override void ExecuteTrigger()
    {
        base.ExecuteTrigger();

        List<Trigger> availableTriggers = new List<Trigger>(choiceTriggers);
        availableTriggers.RemoveAll((t) => !t.enableTrigger);

        if (availableTriggers.Count == 0) return;

        // Select one of the triggers
        int r = Random.Range(0, availableTriggers.Count);

        availableTriggers[r].ExecuteTrigger();
    }
}
