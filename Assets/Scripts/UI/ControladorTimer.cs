using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI minutos;
    [SerializeField] private TextMeshProUGUI segundos;

    private void Update() {
        minutos.text = ((int)GameManager.Instance.GetTimer/60).ToString("00");
        segundos.text = ((int)GameManager.Instance.GetTimer%60).ToString("00");
    }
}
