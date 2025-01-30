using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public Transform[] respawnPoint; // respawn das naves inimigas

    public GameObject enemyShip; // prefab da nave inimiga

    public List<GameObject> enemyShips; // lista para verificar quantidade de naves inimigas

    public int shipHealth;

    public Slider healthBar;

    public AudioSource[] sfx;

    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }

        shipHealth = 5;
        healthBar.GetComponent<Slider>().value = shipHealth;
    }

    // Update is called once per frame
    void Update()
    {
        checkEmptyEnemiesList();
        EnemiesRespawn();
    }

    public void EnemiesRespawn(){
        if(enemyShips.Count < 4){
            
            int pRandom = Random.Range(0, 4);

            GameObject go = Instantiate(enemyShip, respawnPoint[pRandom].position, Quaternion.identity);

            enemyShips.Add(go);

        }
    }

    public void checkEmptyEnemiesList(){
        for (int i = 0; i < enemyShips.Count; i++)
        {
            if(enemyShips[i] == null){
                enemyShips.Remove(enemyShips[i]);
            }
        }
    }

    public void PlayerDamage(){
        if(shipHealth > 0){
            shipHealth--;
            healthBar.GetComponent<Slider>().value = shipHealth;
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void sfxShip(int kindOfSFX){
       // 0 - explosao | 1 - laser
       sfx[kindOfSFX].Play();
    }

}
