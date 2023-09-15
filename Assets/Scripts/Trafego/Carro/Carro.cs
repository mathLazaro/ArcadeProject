using System;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    private Vector3 destino;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Transform referencia;
    [SerializeField] private Transform car;
    private float rotacao;
    private List<Transform> esquina;
    private int idx;
    //private Rigidbody2D rb;
    public void Iniciar(List<Transform> esquina,int idx) 
    { 
        destino = esquina[idx].position;
        this.esquina = esquina;
        this.idx = idx;
    }

    private void Start() {
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0,sprites.Count)];
        //rb.GetComponentInChildren<Rigidbody2D>();
    }

    private void Update() {
        Mover();

        if(Math.Round((transform.position - destino).magnitude)==0)
        {
            if(idx == esquina.Count-1) idx=0;
            else idx += 1;
            destino = esquina[idx].position;
        }
    }

    private void Mover()
    {
        transform.position += (destino - transform.position).normalized * Time.deltaTime;

        rotacao = Vector2.SignedAngle(referencia.localPosition,gameObject.GetComponentInChildren<Rigidbody2D>().velocity);

        car.transform.eulerAngles = new Vector3(0,0,rotacao);

    }
}
