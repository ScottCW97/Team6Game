using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn_3 : MonoBehaviour 
{

    public GameObject enemy;
    public Transform EnemyPos_3;

    private float repeatRate_3 = 2.0f;



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            InvokeRepeating("EnemySpawner_3", 0.5f, repeatRate_3);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }

    }



    void EnemySpawner_3()
    {

        Instantiate(enemy, EnemyPos_3.position, EnemyPos_3.rotation);

    }

}
