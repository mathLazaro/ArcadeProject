using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class Cliente : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    private SpriteRenderer _renderer;
    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void Start() {
        Destroy(transform.parent.gameObject,ControladorCorrida.Instance.GetTempCliente);
        _renderer.sprite = sprites[Random.Range(0,sprites.Count)];
    }
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if(collider2D.CompareTag("Player"))
        {
            GameManager.Instance.RedVida();
            Destroy(transform.parent.gameObject);
        }
    }
    
}
