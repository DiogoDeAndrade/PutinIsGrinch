using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_OnCollisionExit : Trigger
{
    [SerializeField]
    private bool        isCollisionTrigger = true;
    [SerializeField] 
    private LayerMask   layers;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isCollisionTrigger) return;

        if ((LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) & layers.value) == 0) return;

        //Debug.Log($"Object {name} collided with {collision.name} (Layers {gameObject.layer}/{collision.gameObject.layer})");

        ExecuteTrigger();
    }
}
