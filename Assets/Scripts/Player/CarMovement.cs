using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
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
    //private int re;
    private bool isMovingBack;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        isDrifting = false;
        isMovingBack = false;
        //re = 1;
    }

    private void FixedUpdate() {
        MoverFrente();
        MoverTras();
        Derrapar();
        //GameManager.Instance.SetVetorRot(new Vector3(0f,0f,rb.rotation));
    }

    private void MoverFrente()
    {
        if(!isMovingBack&&!GameManager.Instance.GetAnimating)
        {
            // Andar pra frente

            vetorVelocidade = transform.up * Vector2.Dot(rb.velocity, transform.up);
            vetorDrift = transform.right * Vector2.Dot(rb.velocity,transform.right);

            if(!isDrifting)
            {
                rb.velocity =  vetorVelocidade + vetorDrift * fatorDrift;

                rb.AddForce(boost * transform.up * velocidade * PlayerInput.acelerar ,ForceMode2D.Force);
            }

            rb.MoveRotation(rb.rotation + centripeta * - PlayerInput.virar.x * Time.deltaTime * rb.velocity.magnitude);

            // Frear
            rb.velocity -= vetorVelocidade * PlayerInput.frear * Time.deltaTime * desaceleracao;

            if(rb.velocity.magnitude <= 0.5f && Math.Sign(Vector2.Dot(rb.velocity,transform.up)) > 0 && PlayerInput.frear != 0) isMovingBack = true;
        }
        
    }

    private void MoverTras()
    {
        if(isMovingBack&&!GameManager.Instance.GetAnimating)
        {
            // Andar pra trás
            vetorVelocidade = transform.up * Vector2.Dot(rb.velocity, transform.up);
            vetorDrift = transform.right * Vector2.Dot(rb.velocity,transform.right);

            if(!isDrifting)
            {
                rb.velocity =  vetorVelocidade + vetorDrift * fatorDrift;

                rb.AddForce(boost * transform.up * - velocidade * 0.25f * PlayerInput.frear ,ForceMode2D.Force);
            }

            rb.MoveRotation(rb.rotation + centripeta * - PlayerInput.virar.x * Time.deltaTime * rb.velocity.magnitude);

            // Frear
            rb.velocity -= vetorVelocidade * PlayerInput.acelerar * Time.deltaTime * desaceleracao;

            if(rb.velocity.magnitude <= 0.5f && Math.Sign(Vector2.Dot(rb.velocity,transform.up)) < 0 && PlayerInput.acelerar != 0) isMovingBack = false;
        
        }
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