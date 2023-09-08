using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 vetorDrift;
    private Vector2 vetorVelocidade;

    [SerializeField] private float desaceleracao = 1f;
    [SerializeField] private float centripeta = 50f;
    [SerializeField] private float velocidade = 5f;
    [Range(0.8f,1f)] public float drift = 0.9f;
    [Range(1f,2.5f)] public float boost = 1f;

    private float fatorDrift = 0.5f;
    private bool isDrifting;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        isDrifting = false;
    }

    private void FixedUpdate() {
        Mover();
        Frear();
        Derrapar();
    }

    private void Mover()
    {
        vetorVelocidade = transform.up * Vector2.Dot(rb.velocity, transform.up);
        vetorDrift = transform.right * Vector2.Dot(rb.velocity,transform.right);

        if(!isDrifting)
        {
            rb.velocity =  vetorVelocidade + vetorDrift * fatorDrift;

            rb.AddForce(boost * transform.up * velocidade * PlayerInput.acelerar ,ForceMode2D.Force);
        }

        rb.MoveRotation(rb.rotation + centripeta * - PlayerInput.virar.x * Time.deltaTime * rb.velocity.magnitude);
    }

    private void Frear()
    {
        rb.velocity -= vetorVelocidade * PlayerInput.frear * Time.deltaTime * desaceleracao;
    }

    private void Derrapar()
    {
        if(PlayerInput.derrapar != 0) isDrifting = true;
        else isDrifting = false;
        
        if(isDrifting)
        {
            rb.velocity =  (vetorVelocidade + vetorDrift) * drift;
        }
    }
}