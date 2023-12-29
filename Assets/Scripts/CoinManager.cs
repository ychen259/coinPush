using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinManager : singleTon<CoinManager>
{
    //public float coins;
    public Text numberCoin;
    public Text timeForNextCoin;
    public CoinSpawner coinSpawner;
    //show the total coins in the guiText
    void Update()
    {
        //numberCoin.text = String.Format("<color=#FF7B40FF><b>Coins: </b></color>" + "<color=#5AFF1AFF>{0}</color>", coins);
        numberCoin.text = Setting.Instance.Coins.ToString();
        timeForNextCoin.text = string.Format("<b>Next in: </b>") + Mathf.Floor(coinSpawner.CoinTimer).ToString() + "s";
    }


}