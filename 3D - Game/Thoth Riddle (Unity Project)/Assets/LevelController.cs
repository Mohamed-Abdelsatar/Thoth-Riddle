using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public AudioSource CoinSFX;
    

    public void Update()
    {
       GameObject Coin = GameObject.FindGameObjectWithTag("Coin");

        if(!Coin.activeSelf)
        CoinSFX.Play();
    }
}
