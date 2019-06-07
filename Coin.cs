using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    // Start is called before the first frame update
    public Text textocoin; // pega o texto da unity
    public Image lives;
    public Text vidas;

    public float money =0 ; // valor inicial de moeda
    public float quantvidas =3;
    void Start()
    {
        
    }

    // Update is called once per frame
    // adiona valor a nomey
    void Update()
    {
        textocoin.text = "" + money;
        vidas.text = "" + quantvidas;

        if (money >= 10)
        {
            quantvidas += 1;
            money = 0;
        }
    }

    // verifica se a moeda foi coletada
    public void CoinCollected() 
    {
        money += 1;


    }

    public void VD()
    {
        quantvidas--;
    }

}
