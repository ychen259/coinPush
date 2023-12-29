var Coin : Transform;
var CoinTimer: float = 20;
var CoinSpawnTimer: float = 0;
var CoinManager : CoinManager;

	
function Update() 
	{	
		//check if the timer for a new coin is 0
		 if	(CoinTimer <= 0)
		{
			//set time on 20seconds again and add 1 coin to the total coins
			CoinTimer = 20;
			CoinManager.coins += 1;
		}
		
		else
		{
			CoinTimer -= Time.deltaTime;
		}
	}

//check if the mouse is hovering over the spawner area
function OnMouseOver()
{

	var mousex = Input.mousePosition.x;
	var mousey = Input.mousePosition.y;
	var ray = GetComponent.<Camera>().main.ScreenPointToRay (Vector3(mousex,mousey,0));

	var hittest : RaycastHit;

		if (Physics.Raycast (ray, hittest, 200)) {
	
		}

		//check if the mouse is down and if you have enough coins and the reload time is 0
		if ( Input.GetMouseButtonDown(0) && CoinManager.coins >= 1 && CoinSpawnTimer <= 0)
		{	
			//spawn the coin
			var create = Instantiate(Coin, hittest.point, Quaternion.identity);
			//remove 1 coin from the total amount of coins
			CoinManager.coins -= 1;
			//set reload time to 0.5seconds
			CoinSpawnTimer = 0.5;

		}
			else
			{
				CoinSpawnTimer -= Time.deltaTime;
			}
}


