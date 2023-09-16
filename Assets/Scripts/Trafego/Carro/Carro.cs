using System;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    private Vector3 destino;
    //private Vector3 vetorVel;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Transform car;
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
        Rotacionar();
    }

    private void Update() {
        Mover();

        if(Math.Round((transform.position - destino).magnitude)==0)
        {
            if(idx == esquina.Count-1) idx=0;
            else idx += 1;
            destino = esquina[idx].position;
            Rotacionar();
        }
    }

    private void Mover()
    {
        transform.position += (destino - transform.position).normalized * Time.deltaTime;
    }

    private void Rotacionar()
    {
        var rotacao = Vector2.SignedAngle(Vector2.up,destino-transform.position);
        GetComponent<Rigidbody2D>().rotation = rotacao;
    }
}
