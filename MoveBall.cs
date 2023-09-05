o# JogoBal
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveBall : MonoBehaviour {

private Rigidbody rb;

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
}
void Update () {
float movimentoHorizontal = Input.GetAxis("Horizontal");
float movimentoVertical = Input.GetAxis("Vertical");
Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
rb.AddForce(movimento * velocidade);
}
}
