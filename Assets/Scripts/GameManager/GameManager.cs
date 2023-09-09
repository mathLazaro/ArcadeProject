using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timerJogo = 10f; // segundos
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    
    // Vetor de referencia para animação
    //private Vector3 vetorRotacaoPlayer; 
    private bool gameOver;
    private bool isAnimating;
    private float timerCena;

    private void Awake() {
        if(_instance == null) _instance = this;
        else Destroy(this);

        gameOver = false;
    }

    private void Update() {
        timerCena = Time.timeSinceLevelLoad;
        //Debug.Log(timerCena);

        Temporizador();
    }

    private void Temporizador()
    {
        if(!gameOver)
        {
            if(timerJogo > 0) timerJogo -= Time.deltaTime;
            else
            {
                timerJogo = 0f;
                gameOver = true;
            }
        }
    }

    public float GetTimer => timerJogo;
    public void AddTimer(float add) {timerJogo += add;}
    //public Vector3 GetVetorRot => vetorRotacaoPlayer;
    //public void SetVetorRot(Vector3 vetor) {vetorRotacaoPlayer = vetor;}
    public bool GetAnimating => isAnimating;
    public void SetAnimating(bool a) {isAnimating = a;}
}
