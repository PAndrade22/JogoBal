using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveBall : MonoBehaviour {

private Rigidbody rb;

public Vector3 jump;

public float jumpforce = 2;

public bool isGrounded;

public float velocidade;

private int count = 0;

public Text winText;

public Text countText;


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



void Start () {
    rb = GetComponent<Rigidbody>();
    SetCountText();
    jump = new Vector3(0.0f, 2.0f, 0.0f);
}

void OnCollisionStay(){
    isGrounded = true;
}

void Update () {
float movimentoHorizontal = Input.GetAxis("Horizontal");
float movimentoVertical = Input.GetAxis("Vertical");
Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
rb.AddForce(movimento * velocidade);

 if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
        rb.AddForce(jump * jumpforce, ForceMode.Impulse);
        isGrounded = false;

}
}
}
