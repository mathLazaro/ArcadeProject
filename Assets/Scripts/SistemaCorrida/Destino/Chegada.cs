using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chegada : MonoBehaviour
{
    [SerializeField] private float tempoGanho;
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player"))
        {
            GameManager.Instance.SetCorrida(false);
            GameManager.Instance.AddTimer(tempoGanho);
            Destroy(this.gameObject);
        }
    }
}
