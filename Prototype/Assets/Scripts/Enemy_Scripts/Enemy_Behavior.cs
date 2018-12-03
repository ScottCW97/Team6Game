using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float timeBtwDamage;
    public float startTimeBtwDamage;
    public float attackRange;
    float someScale;


    public Transform player;
    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public Animator animator;

    public int damage;

    bool isInRange = false; //Do not want player to randomly take damage

    private float player_x;
    private float enemy_x;





    // Use this for initialization
    void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        someScale = transform.localScale.x;

    }
	
	// Update is called once per frame
	void Update () 
    {



        player_x = player.transform.position.x;


        enemy_x = gameObject.transform.position.x;



        if (player_x > enemy_x)
        {
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            //animator.SetTrigger("enemy2_walk");

        }

        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;

            isInRange = true;
            timeBtwDamage += Time.deltaTime;
        }

        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            //animator.SetTrigger("enemy2_walk");
        }

        //Attack Player
        if (isInRange == true && timeBtwDamage >= 1)
        {
            //then they can attack
            animator.SetTrigger("enemy_punch");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Player_Controller>().health -= damage;
                }
            Debug.Log("PLAYER TOOK DAMAGE!!");

            player.GetComponent<Animator>().SetTrigger("stumble");
            SoundManager.PlaySound("kick");

            timeBtwDamage = 0;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }

}
