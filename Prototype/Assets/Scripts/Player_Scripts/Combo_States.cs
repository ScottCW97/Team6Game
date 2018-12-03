using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo_States : MonoBehaviour 
{
    public Animator animator;
    public ParticleSystem light_finisher;
    private ParticleSystem clone_light_finisher;

    private enum States { idle, lp, lp_lp, hp, hp_hp, finisher};
    private States myState;
    private int idle_return_timer = 0;


	// Use this for initialization
	void Start () 
    {
        myState = States.idle;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(myState != States.idle)
        {
            idle_return_timer++;
            if(idle_return_timer > 100)
            {
                myState = States.idle;
                idle_return_timer = 0;

            }
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch(myState)
            {
                case States.idle:
                    myState = States.lp;
                    break;

                case States.lp:
                    myState = States.lp_lp;
                    break;

                case States.lp_lp:
                    myState = States.finisher;
                    animator.SetTrigger("light_finisher");
                    clone_light_finisher = Instantiate(light_finisher, transform.position, Quaternion.identity);
                    SoundManager.PlaySound("Special_Move_FX");
                    Destroy(clone_light_finisher.gameObject, 2f);
                    break;
            }

        }

        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            switch(myState)
            {
                case States.idle:
                    myState = States.hp;
                    break;

                case States.hp:
                    myState = States.hp_hp;
                    break;

                case States.hp_hp:
                    myState = States.finisher;
                    animator.SetTrigger("heavy_finisher");
                    break;

            }

        }



	}
}
