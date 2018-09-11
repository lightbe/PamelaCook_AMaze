using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    // Start the timer & destroy this object
    public void StartTheMaze()
    {
        GameObject.Find("Door").GetComponent<Timer>().startTheTimer = true;
        Destroy(this.gameObject);
    }
}
