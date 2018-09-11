using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Create a reference to the CoinPoofPrefab
    public GameObject coinPoofPrefab;

    public void OnCoinClicked()
    {
        // Instantiate the CoinPoof Prefab where this coin is located
        // Make sure the poof animates vertically
        Instantiate(coinPoofPrefab, this.transform.position, this.transform.rotation);
        // Increment the coin count - displayed in Timer script
        GameObject.Find("Door").GetComponent<Timer>().coinCount += 1;
        // Destroy this coin. Check the Unity documentation on how to use Destroy
        Destroy(this.gameObject);
    }

}