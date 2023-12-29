public var Price01:Transform;
public var Price02:Transform;
public var Price03:Transform;
public var clone:Transform;

	function Start () 
	
		{
			//spawn the price
			SpawnPrice01();
			//wait 50 seconds and spawn price02
			yield WaitForSeconds (50);
			SpawnPrice02();
			//wait 70 seconds and spawn price03
			yield WaitForSeconds (70);
			SpawnPrice03();
		}

	//Spawn price01
	function SpawnPrice01()
		{
			clone = Instantiate(Price01, Vector3(Random.Range(-1,3),2,-7), Quaternion.identity); 
			clone.GetComponent.<Rigidbody>().angularVelocity = Vector3(Random.Range(-1,1),Random.Range(-1,-1),Random.Range(-7,-10));
			//Wait to repeat this and spawn the next Price01 
			Invoke("SpawnPrice01", 100); 
		}

	//Spawn price02
	function SpawnPrice02()
		{
			clone = Instantiate(Price02, Vector3(Random.Range(-1,3),2,-7), Quaternion.identity); 
			clone.GetComponent.<Rigidbody>().angularVelocity = Vector3(Random.Range(-1,1),Random.Range(-1,-1),Random.Range(-4,-5));
			//Wait to repeat this and spawn the next Price02
			Invoke("SpawnPrice02", 200); 
		}

	//Spawn price03
	function SpawnPrice03()
		{
			clone = Instantiate(Price03, Vector3(Random.Range(-1,3),2,-7), Quaternion.identity); 
			clone.GetComponent.<Rigidbody>().angularVelocity = Vector3(Random.Range(-1,1),Random.Range(-1,-1),Random.Range(-2,-3));
			//Wait to repeat this and spawn the next Price03
			Invoke("SpawnPrice03", 300); 
		}

