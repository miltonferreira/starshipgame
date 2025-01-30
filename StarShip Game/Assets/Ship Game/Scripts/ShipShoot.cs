using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil
    public Transform firePoint;         // Ponto de onde o projétil será disparado
    public float projectileSpeed = 10f; // Velocidade do projétil
    public float fireRate = 0.5f;       // Intervalo de tempo entre os tiros

    private float nextFireTime = 0f;

    void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && Time.time >= nextFireTime)
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

        if (rb != null)
        {
            rb.velocity = firePoint.up * projectileSpeed;
        }
    }
}
