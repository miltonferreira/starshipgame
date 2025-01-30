using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public Vector3 offset; // Deslocamento da câmera em relação ao jogador
    public float smoothSpeed = 0.125f; // Velocidade de suavização do movimento da câmera
    
    void LateUpdate()
    {
        // Posição desejada da câmera
        Vector3 desiredPosition = player.position + offset;

        // Posição suavizada da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
    }

}
