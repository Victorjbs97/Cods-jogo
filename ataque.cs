using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque : MonoBehaviour
{
    public float Distancia;// Calcula a distancia entre o MC e os inimigos.
    public GameObject player;  // pega um objecto da unity, nesse caso eu peguei o player

    public bool CanAtack;

    void Start()
    {
        Distancia = 3;

    }

    // Update is called once per frame
    void Update()
    {
        //distancia entre inimigo e player.
        float Dist = Vector2.Distance(transform.position, player.transform.position);
        if (Dist <= Distancia)
        {
            CanAtack = true;
            Atack();
        }
        else
        {
            CanAtack = false;
            Atack();
        }


        //executa o ataque e animação;
        void Atack()
        {
            if (CanAtack == true)
            {
                GetComponent<Animator>().SetBool("dif", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("dif", false);

            }

        }
    }


}
