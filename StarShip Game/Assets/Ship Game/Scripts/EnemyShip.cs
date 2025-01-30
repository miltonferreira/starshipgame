using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float speed = 5f; // Velocidade de movimento da nave inimiga
    public float stoppingDistance = 2f; // Distância mínima para parar de seguir o jogador

    private Rigidbody2D rb; // Referência ao Rigidbody2D da nave inimiga

    public float angleOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D não encontrado!");
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player não definido!");
            return;
        }

        // Calcular a distância entre a nave inimiga e o jogador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Se a distância for maior que a distância de parada, mover-se em direção ao jogador
        if (distanceToPlayer > stoppingDistance)
        {
            // Calcular a direção de movimento em direção ao jogador
            Vector2 direction = (player.position - transform.position).normalized;

            // Mover a nave inimiga em direção ao jogador
            rb.velocity = direction * speed;

            // Opcional: Fazer a nave inimiga olhar na direção do jogador
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle + angleOffset;
        }
        else
        {
            // Parar a nave inimiga se estiver dentro da stoppingDistance
            rb.velocity = Vector2.zero;
        }
    }
}
