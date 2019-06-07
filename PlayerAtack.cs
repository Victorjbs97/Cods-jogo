using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{

    //Desconciderar esse codigo
    public float forcaHorizontal = 15;
    public float forcaVertical = 10;
    public float tempoDestruicao = 1.5f;
    public float forcaHorizontalPadrao;
    // Start is called before the first frame update
    void Start()
    {
        forcaHorizontalPadrao = forcaHorizontal;
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<enemyMov>().enabled = false;
        }

        BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D box in boxes)
        {
            box.enabled = false;
            if (other.transform.position.x < transform.position.x)


            Destroy(other.gameObject);


        }



    }
}
