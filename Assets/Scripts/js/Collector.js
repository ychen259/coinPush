var CoinManager : CoinManager;
var PriceManager : PriceManager;

//check for collision
function OnTriggerEnter (other : Collider) 
	{
		//Is it a coin add 1 coin to the total coins
		if (other.CompareTag ("Coin")) 
		{
			CoinManager.coins += 1;
		}
		
		//Is it a price taged object than add 1 to the total price score
		if (other.CompareTag ("Price")) 
		{
			PriceManager.price += 1;
		}
	}



