using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class XYMovement : Movement
{
    [SerializeField] 
    private Vector2 speed = new Vector2(100, 100);
    [SerializeField]
    private bool inputEnabled;
    [SerializeField, ShowIf("inputEnabled")]
    private string horizontalAxis = "Horizontal";
    [SerializeField, ShowIf("inputEnabled")]
    private string verticalAxis = "Vertical";

    Vector3     moveVector;

    public override Vector2 GetSpeed() => speed;
    public override void    SetSpeed(Vector2 speed) { this.speed = speed; }


    void FixedUpdate()
    {
        MoveDelta(moveVector * Time.fixedDeltaTime);
    }

    void Update()
    {
        moveVector = Vector3.zero;
        if (inputEnabled)
        {
            if (horizontalAxis != "") moveVector.x = Input.GetAxis(horizontalAxis) * speed.x;
            if (verticalAxis != "") moveVector.y = Input.GetAxis(verticalAxis) * speed.y;
        }
        else
        {
            moveVector = speed;
        }
    }
}
