using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region var
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    // Variáveis de controle
    private Vector2 vetorVelocidade;
    private bool gameOver;
    private bool isAnimating;
    //private float timerCena;
    private float velocidade;
    private bool corrida;

    [SerializeField] private int vida = 5; 
    [SerializeField] private float timerJogo = 10f; // segundos

    #endregion

    #region unity

    private void Awake() {
        if(_instance == null) _instance = this;
        else Destroy(this);

        corrida = false;
        gameOver = false;
    }

    private void Update() {
        Temporizador();
        if(vida <= 0) gameOver = true;
        Debug.Log(vida);
    }
    #endregion

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

    #region getSet

    public void AddTimer(float add) {timerJogo += add;}
    public void SetAnimating(bool a) {isAnimating = a;}
    public void SetVelocidade(float vel) {velocidade = vel;}
    public float GetTimer => timerJogo;
    public bool GetAnimating => isAnimating;
    public float GetVelocidade => velocidade;
    public Vector2 GetVetVel => vetorVelocidade;
    public void SetVetVel(Vector2 vel) {vetorVelocidade = vel;}
    public bool GetCorrida => corrida;
    public void SetCorrida(bool corrida) {this.corrida = corrida;}
    public int GetVida => vida;
    public void RedVida() {vida -= 1;}
    public bool GetGameOver => gameOver;

    #endregion
}
