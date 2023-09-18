using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoy : MonoBehaviour
{
     
    private CharacterController character;
    private Animator animator;
    private Vector3 input;
    private int count = 0;
    public Text winText;
    public Text countText;

    [SerializeField]private float velocidade = 2f;


    void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "PickUp"){
        other.gameObject.SetActive(false);
        count = count + 1;
        SetCountText();
    }
}

void SetCountText() {
    countText.text = "Count: " + count.ToString();
    if (count >= 7) {
        winText.text = "YOU WIN!";
    }
}

    // Start is called before the first frame update
    void Start()
    {   
         rb = GetComponent<Rigidbody>();
         SetCountText();
         character = GetComponent<CharacterController>();
         animator = GetComponent<Animator>();
    }
    void OnCollisionStay(){
    isGrounded = true;
}

    // Update is called once per frame
    void Update()
    {
        input.Set(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        character.Move(input * Time.deltaTime * velocidade);
        character.Move(Vector3.down * Time.deltaTime);

        if (input != Vector3.zero){
            animator.SetBool("andando", true);
            transform.forward = Vector3.Slerp(transform.forward, input, Time.deltaTime * 10);
        } else{
            animator.SetBool("andando", false);
        }
    }
}
