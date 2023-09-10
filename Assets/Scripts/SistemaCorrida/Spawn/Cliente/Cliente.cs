using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class Cliente : MonoBehaviour
{
    private void Start() {
        Destroy(transform.parent.gameObject,ControladorCorrida.Instance.GetTempCliente);
    }
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if(collider2D.CompareTag("Player"))
        {
            GameManager.Instance.RedVida();
            Destroy(transform.parent.gameObject);
        }
    }
}
