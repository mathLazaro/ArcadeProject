using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCliente : MonoBehaviour
{
    private InputMap input;
    [SerializeField] private GameObject cliente;
    [SerializeField] private GameObject supDir;
    [SerializeField] private GameObject infEsq;
    [SerializeField][Range(0,0.001f)] private float chanceSpawn = 0.1f; 
    private Vector3 vetorSpawn;
    private float controlSpawn;
    private bool firstTime;

    private void Awake() {
        input = new InputMap();
        firstTime = true;
        //Debug.Log(clientes.Count);
    }

    private void Update() {
        Rand();
    }
    
    private void Rand()
    {
        // Fazer com que se spwane somente perto do player
        if(!GameManager.Instance.GetCorrida && Random.value < chanceSpawn && (Time.time > controlSpawn || firstTime))
        {
            vetorSpawn = new Vector3(Random.Range(infEsq.transform.position.x,supDir.transform.position.x),Random.Range(infEsq.transform.position.y,supDir.transform.position.y),0f);
            Instantiate(cliente,vetorSpawn,new Quaternion(0f,0f,0f,0f));

            firstTime = false;

            controlSpawn = Time.time + ControladorCorrida.Instance.GetTempCliente;
        }
    }
}
