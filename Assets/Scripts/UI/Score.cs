using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private static Score _instance;
    public static Score Instance => _instance;
    [SerializeField] private TextMeshProUGUI minutosOver;
    [SerializeField] private TextMeshProUGUI segundosOver;
    [SerializeField] private TextMeshProUGUI minutosPause;
    [SerializeField] private TextMeshProUGUI segundosPause;

    private void Awake() {
        if(_instance == null) _instance = this;
        else Destroy(this);
    }  

    public void MudarScoreOver() {
        minutosOver.text = ((int)Time.time/60).ToString("00");
        segundosOver.text = ((int)Time.time%60).ToString("00");
    }

    public void MudarScorePause() {
        minutosPause.text = ((int)Time.time/60).ToString("00");
        segundosPause.text = ((int)Time.time%60).ToString("00");
    }
}
