using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveBall : MonoBehaviour {

private Rigidbody rb;

public Vector3 jump;

public float jumpforce = 2;

public bool isGrounded;

public Text winText;

public float velocidade;

private int count = 0;

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
if (count >= 5){
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
    float movimentoHorizontal = 0.0f;
    float movimentoVertical = 0.0f;

    if (usarTeclasWSAD) {
        movimentoHorizontal = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
        movimentoVertical = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;
    } else {
        movimentoHorizontal = Input.GetAxis("Horizontal");
        movimentoVertical = Input.GetAxis("Vertical");
    }

    Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
    rb.AddForce(movimento * velocidade);

 if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
        rb.AddForce(jump * jumpforce, ForceMode.Impulse);
        isGrounded = false;

}
}
}
