using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger_OnCollisionEnter : Trigger
{
    [SerializeField]
    private bool        isCollisionTrigger = true;
    [SerializeField] 
    private LayerMask   layers;
    [SerializeField]
    private float       invulnerabilityDuration = 0.0f;
    [SerializeField]
    private UnityEvent  onInvulnerabilityStart;
    [SerializeField]
    private UnityEvent  onInvulnerabilityEnd;

    private float invulnerabilityTimer;

    private void Start()
    {
        SetInvulnerable(invulnerabilityDuration);
    }

    private void Update()
    {
        if (invulnerabilityTimer > 0.0f)
        {
            invulnerabilityTimer-= Time.deltaTime;

            if (invulnerabilityTimer <= 0.0f)
            {
                invulnerabilityTimer = 0.0f;
                onInvulnerabilityEnd?.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollisionTrigger) return;
        if (invulnerabilityTimer > 0.0f) return;

        //Debug.Log($"Triggers {name} collided with {collision.name} (Layers {gameObject.layer}/{collision.gameObject.layer})");

        if ((LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) & layers.value) == 0) return;

        ExecuteTrigger();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isCollisionTrigger) return;
        if (invulnerabilityTimer > 0.0f) return;

        //Debug.Log($"Colliders {name} collided with {collision.otherCollider.name} (Layers {gameObject.layer}/{collision.otherCollider.gameObject.layer})");

        if ((LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) & layers.value) == 0) return;

        ExecuteTrigger();
    }

    public void SetInvulnerable(float duration)
    {
        invulnerabilityDuration = duration;
        invulnerabilityTimer = duration;
        if (duration > 0)
        {
            onInvulnerabilityStart?.Invoke();
        }
    }
}
