using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McJump : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D Corpo; // pega o rigidbody player
    public float JumpFoce = 600f; // forca do pulo 
    public bool puloDuplo = true; // condição para o pulo
    public bool Chao; // verificação se player esta no chao
    public Transform ChaoPulo; // pega um componente no player chamado.
    public float chaoRaio = 0.1f; // raio para a colisão
    public LayerMask solo; // pega os itens da layer solo
    Animator Anim; // pega um animator
    public bool canFly; // verificação para planar
    public float moveSpeed; // velocidade de player (acho que nem era pra tar aqui)







    void Start()
    {
        Corpo = gameObject.GetComponent<Rigidbody2D>(); // corpo é rigidbody do player
        Anim = gameObject.GetComponent<Animator>(); // para pegar o animator do player
        moveSpeed = 2f; // velocidade de player

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Acho que verifica se player esta no chão e se  sim executa o if
        Chao = Physics2D.OverlapCircle(ChaoPulo.position,chaoRaio, solo);
        Anim.SetBool("Ground", Chao);

        //faz o pulo butão é space
        if (Input.GetButtonDown("Jump") && Chao == true)
        {
            Corpo.AddForce(new Vector2(0, JumpFoce));
            puloDuplo = true;
        }
        //pulo duplo
        if (Input.GetButtonDown("Jump") && Chao == false && puloDuplo == true)
        {
            Corpo.AddForce(new Vector2(0, JumpFoce));
            puloDuplo = false;

        }

        // daqui pra baixo e planar o butão é shift esquedo
        if (Chao == true)
        {
            canFly = false;
        }
        else
        {
            canFly = true;
        }
        if (canFly == true && Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Animator>().SetBool("flying", true);
            Corpo.velocity = new Vector2(Corpo.velocity.x, -0.5f);
        }
        else
        {
            GetComponent<Animator>().SetBool("flying", false);
        }
    }
}
