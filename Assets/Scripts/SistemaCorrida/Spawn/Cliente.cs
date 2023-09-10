using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class Cliente : MonoBehaviour
{
    private Collider2D colMorte;
    private Collider2D colCorrida;

    private void Awake() {
        colMorte = GetComponent<Collider2D>();
        colCorrida = GetComponentInChildren<Collider2D>();
    }
    private void Start() {
        Destroy(this.gameObject,ControladorCorrida.Instance.GetTempCliente);
    }
    private void Update() {
        
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(colMorte.CompareTag("Player")) GameManager.Instance.RedVida();
    }

    
}
