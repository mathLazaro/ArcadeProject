using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDinamica : MonoBehaviour
{
    [SerializeField] private float tamanhoCamera;
    [SerializeField] private Transform transformFrente;
    [SerializeField] private Transform transformTras;
    [SerializeField] private Transform transformPlayer;
    private CinemachineVirtualCamera camLen;

    private void Awake() {
        camLen = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update() {
        EfeitoCam();
        OffSetCam();
    }

    private void OffSetCam()
    {
        if(Vector2.Dot(transformPlayer.up,GameManager.Instance.GetVetVel) >= 0) camLen.Follow = transformFrente;
        else camLen.Follow = transformTras;
    }

    private void EfeitoCam()
    {
        camLen.m_Lens.OrthographicSize = tamanhoCamera + GameManager.Instance.GetVelocidade / 11f;
    }
}
