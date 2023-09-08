using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAcelerar : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 vetor;
    public static bool isMoving;

    [SerializeField] private float aceleracao = 5f;
    [Range(1f,2.5f)] public float boost;

    private void Awake() {
        boost = 1f;
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
        
    }


    private void FixedUpdate() {
        Acelerar();
    
        if(rb.velocity.magnitude == 0) isMoving = false;
        else isMoving = true;
    }

    private void Acelerar()
    {
        vetor = Vector2.one * aceleracao * PlayerInput.inputAcelerar * boost;

        rb.AddRelativeForce(Vector2.up * vetor,ForceMode2D.Force);
    }
}