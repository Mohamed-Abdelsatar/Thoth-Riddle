using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollactableControll : MonoBehaviour
{

    public static int CoinCount;
    public GameObject CoinCountDispaly;
    public GameObject CoinCountDeathDispaly;

    void Update()
    {

        CoinCountDispaly.GetComponent<Text>().text = "" + CoinCount;
        CoinCountDeathDispaly.GetComponent<Text>().text = "" + CoinCount;

    }
}
