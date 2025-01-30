using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float rotationSpeed = 200f; // Velocidade de rotação
    public float moveSpeed = 5f; // Velocidade de movimento

    void Update()
    {
        // Capturar a entrada de rotação (setas esquerda/direita ou A/D)
        float rotationInput = Input.GetAxis("Horizontal");
        // Capturar a entrada de movimento (setas cima/baixo ou W/S)
        float moveInput = Input.GetAxis("Vertical");

        // Rotacionar a nave
        transform.Rotate(Vector3.forward, -rotationInput * rotationSpeed * Time.deltaTime);

        // Mover a nave para frente
        transform.Translate(Vector3.up * moveInput * moveSpeed * Time.deltaTime);

        if(Input.GetMouseButton(0)){
            MouseInput();
        }
        
    }

    public void MouseInput(){
        // Obtém a posição do mouse no espaço do mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcula a direção do vetor do objeto para o mouse
        Vector3 direction = mousePosition - transform.position;

        // Calcula o ângulo necessário para rotacionar a nave
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica a rotação à nave
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
    
}
