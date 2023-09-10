using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputMap input;
    public static float acelerar;
    public static Vector2 virar;
    public static float frear;
    public static float derrapar;
    public static float teste;
    public static float acao;

    private void Awake() {
        input = new InputMap();
        acelerar = derrapar = frear = 0f;
        virar = new Vector2(0,0);
    }


    private void OnEnable() {
        input.Enable();

        input.Player.Acelerar.performed += Acelerar;
        input.Player.Acelerar.canceled += Acelerar;

        input.Player.Direcao.performed += Virar;
        input.Player.Direcao.canceled += Virar;

        input.Player.Frear.performed += Frear;
        input.Player.Frear.canceled += Frear;

        input.Player.Derrapar.performed += Derrapar;
        input.Player.Derrapar.canceled += Derrapar;

        input.Teste.Teste.started += Teste;
        input.Teste.Teste.canceled += Teste;

        input.Player.Acao.performed += Acao;
        input.Player.Acao.canceled += Acao;
    }

    private void OnDisable() {
        input.Disable();
        input.Player.Acelerar.performed -= Acelerar;
        input.Player.Acelerar.canceled -= Acelerar;

        input.Player.Direcao.performed -= Virar;
        input.Player.Direcao.canceled -= Virar;

        input.Player.Frear.performed -= Frear;
        input.Player.Frear.canceled -= Frear;

        input.Player.Derrapar.performed -= Derrapar;
        input.Player.Derrapar.canceled -= Derrapar;

        input.Teste.Teste.started -= Teste;
        input.Teste.Teste.canceled -= Teste;

        input.Player.Acao.performed -= Acao;
        input.Player.Acao.canceled -= Acao;
    }

    private void Teste(InputAction.CallbackContext context) {teste = context.ReadValue<float>();}

    private void Derrapar(InputAction.CallbackContext context) {derrapar = context.ReadValue<float>();}

    private void Frear(InputAction.CallbackContext context) {frear = context.ReadValue<float>();}

    private void Virar(InputAction.CallbackContext context) {virar = context.ReadValue<Vector2>();}

    private void Acelerar(InputAction.CallbackContext context) {acelerar = context.ReadValue<float>();}

    private void Acao(InputAction.CallbackContext context) {acao = context.ReadValue<float>();}
    
}
