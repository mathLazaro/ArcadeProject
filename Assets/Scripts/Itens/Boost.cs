using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private float tempoBoost;

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player"))
        {
            if(GameManager.Instance.GetIsBoosting) // Aumentar tempo de boosting
            {
                GameManager.Instance.AddTempoBoosting(tempoBoost);
            }
            else // Setar isBoosting para true e aumentar tempo de boosting
            {
                GameManager.Instance.InicioBoost();
                GameManager.Instance.AddTempoBoosting(tempoBoost);
            }
            Destroy(this.gameObject);
        }
    }
    private void Update() {
    }
}
