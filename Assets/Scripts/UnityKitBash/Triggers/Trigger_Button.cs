using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Trigger_Button : Trigger
{
    [SerializeField]
    private string  buttonName;
    [SerializeField]
    private bool    continuous = true;
    [SerializeField]
    private bool    useCooldown = false;
    [SerializeField, ShowIf("useCooldown")]
    private float   cooldown = 1.0f;

    float cooldownTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer >= 0.0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        bool isTrigger = (continuous) ? (Input.GetButton(buttonName)) : (Input.GetButtonDown(buttonName));

        if (isTrigger)
        {
            if ((!useCooldown) || (cooldownTimer <= 0.0f))
            {
                if (useCooldown) cooldownTimer = cooldown;

                ExecuteTrigger();
            }
        }
    }
}
