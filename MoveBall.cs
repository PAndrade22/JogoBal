using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;
    public Vector3 jump;
    public bool isGrounded;
    public float jumpforce = 30;
    public Animator animato;
    private Vector3 facingRight;
    private Vector3 facingleft;
    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask  oQueEChao;
    public int puloExtra = 1;
    // Start is called before the first frame update
    void Start()
    {
        facingleft = transform.localScale;
        facingRight = transform.localScale;
        facingleft.x = facingleft.x * -1;
        rb = GetComponent<Rigidbody2D>();
        animato = GetComponent<Animator>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

       void OnCollisionStay(){
        isGrounded = true;
        }
   
    void Update(){

      if (Input.GetAxis("Horizontal") !=0){
       //Tá correndo 
       animato.SetBool("taAndando", true);
      }

      else{
       //Tá parado
       animato.SetBool("taAndando", false);
      }
    
       direction = Input.GetAxis("Horizontal");

      if(direction > 0){ 
        //olhando para a direita
        transform.localScale = facingRight;
      }

      if (direction < 0){
        //olhando para a esquerda
        transform.localScale = facingleft;
      }

       rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);   
       taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.1f, oQueEChao);

                  if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
                     rb.AddForce(jump * jumpforce, ForceMode2D.Impulse);
                     isGrounded = false;
                  }

                  if (Input.GetButtonDown("Jump") && taNoChao == true){
                    rb.velocity = Vector2.up * 13;
                    animato.SetBool("taPulando", true);
                  }
                  if (Input.GetButtonDown("Jump") && taNoChao == false && puloExtra > 0){
                    rb.velocity = Vector2.up * 13;
                    animato.SetBool("doublePulo", true);
                    puloExtra --;
                  }

                  if (taNoChao && rb.velocity.y == 0){
                   puloExtra = 1;
                   animato.SetBool("taPulando", false);
                   animato.SetBool("doublePulo", false);
                  }
    }
 }
