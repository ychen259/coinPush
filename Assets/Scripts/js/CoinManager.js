#pragma strict

var coins: float = 20;
var numberCoin : UI.Text;
var timeForNextCoin : UI.Text;
var coinSpawner : CoinSpawner;
//show the total coins in the guiText
function Update () 
{
       //numberCoin.text = String.Format("<color=#FF7B40FF><b>Coins: </b></color>" + "<color=#5AFF1AFF>{0}</color>", coins);
	   numberCoin.text = coins.ToString();
	   timeForNextCoin.text = String.Format("<b>Next in: </b>") + Mathf.Floor(coinSpawner.CoinTimer).ToString() + "s";
}

