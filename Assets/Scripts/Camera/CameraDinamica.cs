using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDinamica : MonoBehaviour
{
    [SerializeField] private float tamanhoCamera;
    private CinemachineVirtualCamera camLen;
    //private CinemachineTransposer camPos;
    private void Awake() {
        camLen = GetComponent<CinemachineVirtualCamera>();
        //camPos = GetComponent<CinemachineTransposer>();
    }
    private void Update() {
        EfeitoCam();
        OffSetCam();
        //if(camPos == null) Debug.Log("NULL");
    }

    private void OffSetCam()
    {
        //camPos.m_FollowOffset = GameManager.Instance.GetVetVel.normalized * 2f;
    }

    private void EfeitoCam()
    {
        camLen.m_Lens.OrthographicSize = tamanhoCamera + GameManager.Instance.GetVelocidade / 11f;
    }
}
