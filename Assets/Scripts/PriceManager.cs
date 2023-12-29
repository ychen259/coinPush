using UnityEngine;
using System.Collections;

public class PriceManager : MonoBehaviour
{
    public float price = 0;

    //show the total prices in the guiText
    void Update()
    {
        GetComponent<GUIText>().text = price.ToString();
    }


}