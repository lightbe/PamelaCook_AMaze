using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    bool stopTheTimer;
    float minutes, seconds;
    string elapsedTime, coinInfo, keyInfo;

    public Text gameInfo;
    public bool startTheTimer;
    public int coinCount = 0;
    public int coinMaxCount = 7;

    void Start()
    {
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);
    }

    void Update()
    {
        if (stopTheTimer)
        {
            displayInfo();
        }
        else if (startTheTimer)
        {
            minutes = (int)((Time.timeSinceLevelLoad) / 60f);
            seconds = (int)((Time.timeSinceLevelLoad) % 60f);
            displayInfo();
        }
    }

    void displayInfo()
    {
        elapsedTime = "Elapsed Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        if (coinCount == coinMaxCount)
        {
            coinInfo = "\nAll Coins Collected!";
            // Call the Unlock() method on the Door - coinsCollected & keyCollected must be true to unlock the door
            GameObject.Find("Door").GetComponent<Door>().coinsCollected = true;
            //GameObject.Find("Door").GetComponent<Door>().Unlock();
        }
        else
        {
            coinInfo = "\nCoins Collected: " + coinCount.ToString("0");
        }
        if (GameObject.Find("Door").GetComponent<Door>().keyCollected == true)
        {
            keyInfo = "\nKey Collected!";
        }
        gameInfo.text = elapsedTime + coinInfo + keyInfo;
    }

    public void StopTimer()
    {
        stopTheTimer = true;
    }
}
