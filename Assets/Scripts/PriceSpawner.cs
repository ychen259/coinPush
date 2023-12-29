
using UnityEngine;
using System.Collections;

public class PriceSpawner : MonoBehaviour
{
    public Transform Price01;
    public Transform Price02;
    public Transform Price03;
    public Transform clone;

    private float durationBetweenTwoPrice = 50f;

    public void Start()
    {
        //spawn the price
        SpawnPrice01();
        //wait 50 seconds and spawn price02
        StartCoroutine(waitForASecondForPrice02(durationBetweenTwoPrice));
    }

    IEnumerator waitForASecondForPrice02(float second)
    {
        yield return new WaitForSeconds(second);
        SpawnPrice02();

        //wait 70 seconds and spawn price03
        StartCoroutine(waitForASecondForPrice03(durationBetweenTwoPrice));
    }

    IEnumerator waitForASecondForPrice03(float second)
    {
        yield return new WaitForSeconds(second);
        SpawnPrice03();
    }

    //Spawn price01
    void SpawnPrice01()
    {
        clone = Instantiate(Price01, new Vector3(Random.Range(-1, 3), 2, -7), Quaternion.identity);
        clone.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, -1), Random.Range(-7, -10));
        //Wait to repeat this and spawn the next Price01 
        Invoke("SpawnPrice01", 3 * durationBetweenTwoPrice);
    }

    //Spawn price02
    void SpawnPrice02()
    {
        clone = Instantiate(Price02, new Vector3(Random.Range(-1, 3), 2, -7), Quaternion.identity);
        clone.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, -1), Random.Range(-4, -5));
        //Wait to repeat this and spawn the next Price02
        Invoke("SpawnPrice02", 3 * durationBetweenTwoPrice);
    }

    //Spawn price03
    void SpawnPrice03()
    {
        clone = Instantiate(Price03, new Vector3(Random.Range(-1, 3), 2, -7), Quaternion.identity);
        clone.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, -1), Random.Range(-2, -3));
        //Wait to repeat this and spawn the next Price03
        Invoke("SpawnPrice03", 3 * durationBetweenTwoPrice);
    }


}