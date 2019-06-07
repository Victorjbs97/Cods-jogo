using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mcmove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed; // Velocidade do MC
    bool LadoPlayer; // PARA espelhar o MC DPS
    Rigidbody2D Corpo; // RigidBody do MC
    Animator Anim; // animator do mc
    Coin  gm; // chama o cod de coin
    private float timeAttack; // tempo do ataque
    public float proximoAtaque; // tempo de espera do ataque
    PlayerAtack chamaAtack; //pega o cod playerAtack
    public float forcaHorizontal = 15; //não usado  ):
    public float forcaVertical = 10; //não usado    ):
    public float tempoDestruicao = 0.5f;//não usado ):
    public float forcaHorizontalPadrao;// não usado ):

    public GameObject LastCheck;



    void Start()
    {
        moveSpeed = 2f; // Velocidade do MC
        Corpo = gameObject.GetComponent<Rigidbody2D>(); // RigidBody do MC
        Anim = gameObject.GetComponent<Animator>(); // animator do mc
        gm = GameObject.Find("GameManager").GetComponent<Coin>(); // cria um game object e chama o cod coin
        timeAttack = 1; // tempo total do ataque
        forcaHorizontalPadrao = forcaHorizontal; // não usado ):

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()  // REcomendado Quando se usa o rigidBody
    {
        float move = Input.GetAxis("Horizontal");  //Pega o input na unity o colado em um float
        Anim.SetFloat("Speed",Mathf.Abs(move));
        Corpo.velocity = new Vector2(move * moveSpeed, Corpo.velocity.y); //Movimenta o personagem
        if (move > 0 && LadoPlayer == true) // Verifica o da do player 
        {
            Flip(); // Chama o Flip
        }
        if (move < 0 && LadoPlayer == false) // verifica o lado do Player
        {
            Flip();  // Chama o flip
        }
        
        //ataque do personagem 
        if (Input.GetKeyDown(KeyCode.W) && Time.time > timeAttack)
        {
            AtacandoEnemy();  //executa o void atacandoEnemy
            
        }


    } 

    void Flip() //troca o eixo do personagem(Espelha)
    {
        LadoPlayer = !LadoPlayer; // Troca o Bool do ladoPlayer

        Vector3 Scala = transform.localScale; // troca a escala na linha debaixo
        Scala.x *= -1; // multiplica por -1, inverte o lado do MC
        transform.localScale = Scala;
 
    }
    void OnCollisionEnter2D(Collision2D other) //Pega a moeda e destroy 
    {
        if (other.gameObject.tag == "Coins") 
        {
            gm.CoinCollected();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            gm.VD();
            
        }
        if (gm.quantvidas <= 0 )
        {
            transform.position = LastCheck.transform.position;
            gm.quantvidas = 1f;
        }
        if ( other.gameObject.CompareTag("limite"))
        {
            gm.VD();
            transform.position = LastCheck.transform.position;

        }

    }


    void AtacandoEnemy() // executa o ataque e animação do ataque tbm mata o inimigo.
    {


        GetComponent<Animator>().SetTrigger("PlayerAttack");
        timeAttack = Time.time + proximoAtaque;
        Collider2D[] colliders = new Collider2D[3];
        transform.Find("areaAttack").gameObject.GetComponent<Collider2D>()
            .OverlapCollider(new ContactFilter2D(), colliders);
        for (int i =0; i < colliders.Length;i++)
        {
            if (colliders[i]!=null && colliders[i].gameObject.CompareTag("Enemy"))
            {
               
                Destroy(colliders[i].gameObject);
                

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Checkpoint"))
        {
            LastCheck = collision2D.gameObject;
        }
        
    }
}
