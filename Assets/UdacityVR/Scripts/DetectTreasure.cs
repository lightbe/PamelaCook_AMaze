using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTreasure : MonoBehaviour
{
    [Tooltip("The name of the Animator trigger parameter")]
    public string animationName;
    [Tooltip("The Animator component on this gameobject")]
    public Animator stateMachine;
    [Tooltip("Raycast Distance")]
    public float raycastDistance = 15;

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, raycastDistance) && Input.GetMouseButtonDown(0))
        {
            print("There is something in front of the object!");
            stateMachine.SetTrigger(animationName);

        }
    }

}
