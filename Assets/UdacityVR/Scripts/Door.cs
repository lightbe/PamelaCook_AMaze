using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    bool locked = true;
    // Create a boolean value called "opening" that can be checked in Update() 
    bool opening;

    int frameCount = 0;
    int animFrameCount = 0;

    // Create a boolean to display message when door is locked 
    bool displayMessage;

    // Get the LockedMsg GameObject in front of the door
    public GameObject lockedMessage;

    // Create an audio list of sounds
    [Header("Door Audio Clips - Locked, Unlocked")]
    public AudioClip[] soundFiles;
    public AudioSource soundSource;

    // Create a boolean value called "opening" that can be checked in Update()
    public float doorHeight = 8;

    [Header("Frames For Locked Msg (32fps)")]
    public int frameCountMax = 64; // based on 32fps

    // These are used to animate the opening of the chest top
    [Tooltip("The name of the Animator bool parameter")]
    public string animationName = "OpenChestTop";
    [Tooltip("The Animator component on this gameobject")]
    public Animator stateMachine;
    public int animFrameCountMax = 128; // based on 32fps

    [Header("Used When Key & Coins Are Required")]
    public bool coinsCollected, keyCollected;

    void Start()
    {
        lockedMessage.SetActive(false); // disable LockedMsg in front of the door
    }

    void Update()
    {
        // When frame count = max frame count disable LockedMsg in front of the door
        if (displayMessage)
        {
            if (frameCount < frameCountMax)
            {
                frameCount += 1;
            }
            else
            {
                lockedMessage.SetActive(false);
            }
        }

        // If the door is opening and it is not fully raised
        // Animate the door raising up
        if (opening && !locked)
        {
            if (transform.position.y < doorHeight) // raise the door
            {
                transform.Translate(0, 2f * Time.deltaTime, 0, Space.World);
            }

            else
            {
                this.GetComponent<Timer>().StopTimer(); // The Door is raised up. Stop the timer.
            }

            // Set the animation bool to true to open the chest
            if (animFrameCount < animFrameCountMax)
            {
                if (animFrameCount == 0)
                {
                    stateMachine.SetBool(animationName, true);
                }
                animFrameCount += 1;
            }
            else if (animFrameCount == animFrameCountMax)
            {
                stateMachine.SetBool(animationName, false);
            }
        }
    }

    public void OnDoorClicked()
    {
        // If the door is clicked and unlocked
        // Set the "opening" boolean to true
        // (optionally) Else
        // Play a sound to indicate the door is locked
        if (!locked)
        {
            opening = true;
            soundSource.clip = soundFiles[1];
        }
        else
        {
            // play a sound & display message
            soundSource.clip = soundFiles[0];
            displayMessage = true;
            lockedMessage.SetActive(true); // enable LockedMsg in front of the door to view the message when a locked door is clicked
            frameCount = 0;
        }
        soundSource.Play();
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
        locked = false;
        //if (coinsCollected && keyCollected)
        //{
        //    locked = false;
        //}
    }

}