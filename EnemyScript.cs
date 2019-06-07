using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float Distancia ;
    public GameObject player;

    public bool CanAtack ;

    void Start()
    {
        Distancia = 3;

    }

    // Update is called once per frame
    void Update()
    {
        float Dist = Vector2.Distance(transform.position, player.transform.position);
        if (Dist >= Distancia)
        {
            CanAtack = true;
        }
        else
        {
            CanAtack = false;
        }

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
