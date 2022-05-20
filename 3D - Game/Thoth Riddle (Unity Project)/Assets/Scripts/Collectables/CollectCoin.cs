using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        CollactableControll.CoinCount += 1;

        GameObject CoinSfX = GameObject.FindGameObjectWithTag("Coin");

        CoinSfX.GetComponent<AudioSource>().Play();
        
        this.gameObject.SetActive(false);       
    }

}
