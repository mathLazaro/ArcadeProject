using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCliente : MonoBehaviour
{
    private InputMap input;
    [SerializeField] private List<GameObject>  clientes;
    [SerializeField] private GameObject supDir;
    [SerializeField] private GameObject infEsq;
    private Vector3 vetorSpawn;
    private bool jaSpawnou;

    private void Awake() {
        input = new InputMap();
        jaSpawnou = false;
    }

    private void Update() {
        Rand();
    }
    
    private void Rand()
    {
        if(PlayerInput.teste!=0 && !jaSpawnou)
        {
            vetorSpawn = new Vector3(Random.Range(infEsq.transform.position.x,supDir.transform.position.x),Random.Range(infEsq.transform.position.y,supDir.transform.position.y),0f);
            Instantiate(clientes[Random.Range(0,clientes.Count -1)],vetorSpawn,new Quaternion(0f,0f,0f,0f));
            jaSpawnou = true;
        }
    }
}
