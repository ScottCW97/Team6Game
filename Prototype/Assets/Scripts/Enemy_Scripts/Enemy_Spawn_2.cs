using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn_2 : MonoBehaviour 
{

    public GameObject enemy;
    public Transform EnemyPos_2;

    private float repeatRate_2 = 4.0f;



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            InvokeRepeating("EnemySpawner_2", 0.5f, repeatRate_2);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }

    }



    void EnemySpawner_2()
    {

        Instantiate(enemy, EnemyPos_2.position, EnemyPos_2.rotation);

    }

}
