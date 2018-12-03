using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan_Behavior : MonoBehaviour
{

    public int health;
    public GameObject item;
    public Transform player;
    public Animator animator;

    private bool taskIsRunning = true; // set to true when you start the task

    private int number;


    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (health <= 0 && taskIsRunning == true)
        {
            number = Random.Range(1, 5);
            Debug.Log(number);
            animator.SetTrigger("knockover");

            if (number >= 3)
            {
                //sushi

                GameObject sushi = Instantiate(item, item.transform.position, Quaternion.identity) as GameObject;
                sushi.transform.position = player.transform.position + new Vector3(2f,-2f,0f);

            }

            else
            {
                //no item
            }


            taskIsRunning = false;
        }

    }

    public void TakeLightDamage(int light_damage)
    {
        health -= light_damage;
        SoundManager.PlaySound("light_attack");
        Debug.Log("Light Damage Taken!");
    }

    public void TakeHeavyDamage(int heavy_damage)
    {
        health -= heavy_damage;
        SoundManager.PlaySound("heavy_attack");
        Debug.Log("Heavy Damage Taken!");
    }
}
