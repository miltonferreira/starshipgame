using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil
    public Transform firePoint;         // Ponto de onde o projétil será disparado
    public float projectileSpeed = 10f; // Velocidade do projétil
    public float fireRate = 0.5f;       // Intervalo de tempo entre os tiros

    private float nextFireTime = 0f;

    public float shotDistance = 5f;
    public Transform playerTrans;

    private void Start() {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {

        // Calcular a distância entre a nave inimiga e o jogador
        float distanceToPlayer = Vector2.Distance(transform.position, playerTrans.position);

        if (distanceToPlayer <= shotDistance && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameController.instance.sfxShip(1); // som do laser
        
        // Instancia o projétil no ponto de disparo
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        projectile.GetComponent<Bullet>().isPlayer = true; // indica que deve dar dano no player

        if (rb != null)
        {
            rb.velocity = -firePoint.up * projectileSpeed;
        }
    }
}
