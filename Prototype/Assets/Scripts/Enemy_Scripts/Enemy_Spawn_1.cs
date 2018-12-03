using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn_1 : MonoBehaviour 
{

    public GameObject enemy;
    public Transform EnemyPos_1;

    private float repeatRate_1 = 5.0f;



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            InvokeRepeating("EnemySpawner_1", 0.5f, repeatRate_1);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }

    }



    void EnemySpawner_1()
    {

        Instantiate(enemy, EnemyPos_1.position, EnemyPos_1.rotation);

    }

}
