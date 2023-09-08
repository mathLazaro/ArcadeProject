using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputMap input;
    public static float inputAcelerar;
    public static Vector2 inputVirar;
    public static float inputFrear;
    public static float inputDerrapar;

    private void Awake() {
        input = new InputMap();
        inputAcelerar = inputDerrapar = inputFrear = 0f;
        inputVirar = new Vector2(0,0);
    }


    private void OnEnable() {
        input.Enable();

        input.Player.Acelerar.performed += Acelerar;
        input.Player.Acelerar.canceled += Acelerar;

        input.Player.Direcao.performed += Virar;
        input.Player.Direcao.canceled += Virar;

        //input.Player.Frear.performed += Frear;
        //input.Player.Frear.canceled += Frear;

        input.Player.Derrapar.performed += Derrapar;
        input.Player.Derrapar.canceled += Derrapar;
    }

    private void OnDisable() {
        input.Disable();
        input.Player.Acelerar.performed -= Acelerar;
        input.Player.Acelerar.canceled -= Acelerar;

        input.Player.Direcao.performed -= Virar;
        input.Player.Direcao.canceled -= Virar;

        //input.Player.Frear.performed -= Frear;
        //input.Player.Frear.canceled -= Frear;

        input.Player.Derrapar.performed -= Derrapar;
        input.Player.Derrapar.canceled -= Derrapar;
    }

    private void Derrapar(InputAction.CallbackContext context) {inputDerrapar = context.ReadValue<float>();}

    //private void Frear(InputAction.CallbackContext context) {inputFrear = context.ReadValue<float>();}

    private void Virar(InputAction.CallbackContext context) {inputVirar = context.ReadValue<Vector2>();}

    private void Acelerar(InputAction.CallbackContext context) {inputAcelerar = context.ReadValue<float>();}
    
}
