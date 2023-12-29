using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public Transform Coin;
    public float CoinTimer = 20;
    public float CoinSpawnTimer = 0;
    public CoinManager CoinManager;

    private float coinExperience = 20;

    void Update()
    {
        //check if the timer for a new coin is 0
        if (CoinTimer <= 0)
        {
            //set time on 20seconds again and add 1 coin to the total coins
            CoinTimer = 20;
            Setting.Instance.Coins += 1;
        }

        else
        {
            CoinTimer -= Time.deltaTime;
        }
    }

    //check if the mouse is hovering over the spawner area
    void OnMouseOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hittest = new RaycastHit();


        if (Physics.Raycast(ray, out hittest, 200))
        {
        }

        //check if the mouse is down and if you have enough coins and the reload time is 0
        if (Input.GetMouseButtonDown(0) && Setting.Instance.Coins >= 1 && CoinSpawnTimer <= 0)
        {
            SoundManager.Instance.PlaySFX("dropCoin");
            //spawn the coin
            var create = Instantiate(Coin, hittest.point, Quaternion.identity);
            //remove 1 coin from the total amount of coins
            Setting.Instance.Coins -= 1;
            //set reload time to 0.5fseconds
            CoinSpawnTimer = 0.2f;

            Levels.Instance.CurrentExperience += coinExperience;
        }
        else
        {
            CoinSpawnTimer -= Time.deltaTime;
        }
    }



}