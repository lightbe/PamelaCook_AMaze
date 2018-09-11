using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject keyPoofPrefab;
    public GameObject door;
    bool keyCollected;

    void Update()
    {
        //Not required, but for fun why not try adding a Key Floating Animation here :)
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (Mathf.Sin(Time.time * 5.0f) / 25), this.transform.position.z);
    }

    public void OnKeyClicked()
    {
        // Instatiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        Instantiate(keyPoofPrefab, this.transform.position, this.transform.rotation);
        // Call the Unlock() method on the Door - coinsCollected & keyCollected must be true to unlock the door
        GameObject.Find("Door").GetComponent<Door>().keyCollected = true;
        GameObject.Find("Door").GetComponent<Door>().Unlock();
        // Set the Key Collected Variable to true
        keyCollected = true;
        // Destroy the key. Check the Unity documentation on how to use Destroy
        Destroy(this.gameObject);
    }

}
