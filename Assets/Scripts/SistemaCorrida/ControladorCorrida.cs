using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCorrida : MonoBehaviour
{
    private static ControladorCorrida _instance;
    public static ControladorCorrida Instance => _instance;
    [SerializeField] private List<Transform> chegada;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float tempoVidaCliente = 10f;
    [SerializeField] private float tempoGanho;
    //public float GetTempoGanho => tempoGanho;
    public float GetTempCliente => tempoVidaCliente;
    private Transform vetorCorrida;

    private void Awake() {
        if(_instance == null) _instance = this;
        else Destroy(this);
        
    }

    public void GerarPontoChegada()
    {
        vetorCorrida = chegada[Random.Range(0,chegada.Count)];
        Instantiate(prefab,vetorCorrida);
    }

}
