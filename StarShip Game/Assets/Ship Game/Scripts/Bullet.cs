using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f; // Tempo de vida do projétil

    public bool isPlayer;

    public GameObject vfx_explosion;

    void Start()
    {
        // Destrói o projétil após o tempo de vida
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 && !isPlayer){
            GameController.instance.sfxShip(0); // som de explosao
            Destroy(collision.gameObject);  // destroi nave inimiga
            Instantiate(vfx_explosion, collision.transform.position, Quaternion.identity);
            Destroy(gameObject); // destroi bala
        }

        if(collision.gameObject.layer == 6 && isPlayer){
            GameController.instance.PlayerDamage();
            Destroy(gameObject); // destroi bala
        }

    }

}
