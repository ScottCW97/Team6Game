using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Combo : MonoBehaviour
{
    public float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public LayerMask whatIsTrashcan;
    public Animator animator;
    public float attackRange;
    public int light_damage;
    public int heavy_damage;


    private void Update()
    {


        //light attack to enemy
        if (timeBtwAttack <= 0)
        {
            //then you can attack

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("lightAttack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy_Health>().TakeLightDamage(light_damage);
                }

            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }


        //light attack to trashcan
        if (timeBtwAttack <= 0)
        {
            //then you can attack

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("lightAttack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsTrashcan);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Trashcan_Behavior>().TakeLightDamage(light_damage);
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }



        //heavy attack to enemy
        if (timeBtwAttack <= 0)
        {
            //then you can attack

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                animator.SetTrigger("heavyAttack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy_Health>().TakeHeavyDamage(heavy_damage);
                }

            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }




        //heavy attack to trashcan
        if (timeBtwAttack <= 0)
        {
            //then you can attack

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                animator.SetTrigger("heavyAttack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsTrashcan);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Trashcan_Behavior>().TakeHeavyDamage(heavy_damage);
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }



    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }

}