using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirecao : MonoBehaviour
{
    private Vector2 vetor;
    private Rigidbody2D rb;
    private float fatorRot;

    [SerializeField] private float centripeta;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate() {
        Virar();
    }

    private void Virar()
    {
        //fatorRot = centripeta * - PlayerInput.inputVirar.x * rb.velocity.magnitude / PlayerAcelerar.Instance.boost;
        transform.Rotate(0f,0f,centripeta * - PlayerInput.inputVirar.x * rb.velocity.magnitude, Space.Self);

        // vetor de força anti derrapagem
        vetor =  - Vector2.right * rb.velocity.magnitude * -PlayerInput.inputVirar.x/1.5f;

        Debug.Log(vetor);

        rb.AddRelativeForce(vetor);
    }
}
