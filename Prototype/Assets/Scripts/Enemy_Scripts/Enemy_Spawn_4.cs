using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy_Spawn_4 : MonoBehaviour
{

    public GameObject enemy;
    public Transform EnemyPos_4;

    private float repeatRate_4 = 1.0f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            InvokeRepeating("EnemySpawner_4", 0.5f, repeatRate_4);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }

    } 



    void EnemySpawner_4()
    {

        Instantiate(enemy, EnemyPos_4.position, EnemyPos_4.rotation);

    }

}