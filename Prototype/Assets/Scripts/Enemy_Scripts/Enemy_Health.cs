using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

	public int health;
	public float speed; 
    private float dazedTime;
    public float startDazedTime;
    public Transform attackPos;
    public ParticleSystem Hit_Spark;
    public Animator animator;
    private ParticleSystem cloneSpark;

    // Use this for initialization
    void Start () 
    {
     
    }
	
	// Update is called once per frame
	void Update () 
	{
        if(dazedTime <= 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
            animator.SetTrigger("enemy_stumble");
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }





        //transform.Translate(Vector2.left *speed * Time.deltaTime);
    }

	public void TakeLightDamage(int light_damage)
	{
        dazedTime = startDazedTime;
		health -= light_damage;
        SoundManager.PlaySound("light_attack");
        cloneSpark = Instantiate(Hit_Spark, transform.position, Quaternion.identity);
        Destroy(cloneSpark.gameObject, 5f);
        Debug.Log("Light Damage Taken!");
	}

    public void TakeHeavyDamage(int heavy_damage)
    {
        dazedTime = startDazedTime;
        health -= heavy_damage;
        SoundManager.PlaySound("heavy_attack");
        cloneSpark = Instantiate(Hit_Spark, transform.position, Quaternion.identity);
        Destroy(cloneSpark.gameObject, 5f);
        Debug.Log("Heavy Damage Taken!");
    }
}

