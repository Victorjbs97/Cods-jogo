using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMov : MonoBehaviour
{
    public float Distancia; // Calcula a distancia entre o MC e os inimigos.
    public GameObject player;  // pega um objecto da unity, nesse caso eu peguei o player.

    public bool CanAtack;  // criar uma condição para verificar se pode cameçar a se mover e atacar
    public float speedEnemy; // velocidade de movimento do inimigo.


    void Start()
    {
        Distancia = 10;
        speedEnemy = -1;

    }

    // Update is called once per frame
    void Update()
    {

        //logica de calculo da distancia.
        float Dist = Vector2.Distance(transform.position, player.transform.position);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);

        // se a distancia for menor que Dist(Valor da distancia entre o mc e enemy) ele chama a função de enemyStart
        if (Dist <= Distancia)
        {
            
            EnemyStart();
            CanAtack = true;
            
        }

        //executa a animação e o ataque.
        void EnemyStart()
        {
            if (CanAtack == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(speedEnemy, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(speedEnemy, GetComponent<Rigidbody2D>().velocity.y);

            }
        }


   

    }
}
