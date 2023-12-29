// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour
{
    public CoinManager CoinManager;
    public PriceManager PriceManager;

    public Transform coins;
    private Transform clone;

    private float ExperiencePerCoinCollect = 500f;
    private float ExperiencePerPriceCollect = 5000f;

    //check for collision
    void OnTriggerEnter(Collider other)
    {
        //Is it a coin add 1 coin to the total coins
        if (other.CompareTag("Coin"))
        {
            Setting.Instance.Coins += 1;

            Levels.Instance.CurrentExperience += ExperiencePerCoinCollect;

            SoundManager.Instance.PlaySFX("bonus");
        }

        //Is it a price taged object than add 1 to the total price score
        if (other.CompareTag("Price"))
        {
            //Setting.Instance.Coins += 20;
            //PriceManager.price += 1;

            Levels.Instance.CurrentExperience += ExperiencePerPriceCollect;

            for (int i = 0; i < 5; i++)
            {
                clone = Instantiate(coins, new Vector3(Random.Range(-1.5f, 1.5f), 5, Random.Range(-9, -6)), Quaternion.identity);
                clone.GetChild(0).GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, -1), Random.Range(-7, -10));
            }

            SoundManager.Instance.PlaySFX("bonus-drop");
        }
    }




}