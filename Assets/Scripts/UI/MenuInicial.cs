using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    private InputMap input;

    private void Awake() {
        input = new InputMap();
    }
    private void OnEnable() {
        input.Enable();
        input.UI.Iniciar.started += LoadMainScene;
    }
    private void OnDisable() {
        input.Disable();
        input.UI.Iniciar.started -= LoadMainScene;
    }
    private void LoadMainScene(InputAction.CallbackContext ctx)
    {
        if(ctx.ReadValue<float>()!=0)
        {
            SceneManager.LoadScene("CenaPrincipal");
        }
    }

}
