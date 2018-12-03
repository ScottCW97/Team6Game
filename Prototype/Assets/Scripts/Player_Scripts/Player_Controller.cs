using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller: MonoBehaviour {

	public float speed;		//Floating point variable to store the player's movement speed.
    public int health;
    public float timeBtwTrail;
    public float startTimeBtwTrail;
    public Transform groundCheck;
    public Slider Health_Bar;
    public Animator animator;

    private Rigidbody2D rb2d;   //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Vector2 moveVelocity;
    private int minY = -3;
    private int maxY = 1;
    float horizontalMove;
    float verticalMove;
    float totalMove;
    float someScale;

    // Use this for initialization
    void Start () 
	{

		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();

        someScale = transform.localScale.x;

	}
	
	// Update is called once per frame
    void Update () 
    {
        Mathf.Clamp(transform.position.y, minY, maxY);
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        horizontalMove = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalMove);

        verticalMove = Input.GetAxisRaw("Vertical");
        //Debug.Log(verticalMove);

        totalMove = Mathf.Abs(horizontalMove) + Mathf.Abs(verticalMove);
        //Debug.Log(totalMove);

        animator.SetFloat("speed", Mathf.Abs(totalMove));


        if(horizontalMove < 0)
        {
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
            animator.SetFloat("speed", Mathf.Abs(totalMove));
        }

        else if (horizontalMove > 0)
        {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
            animator.SetFloat("speed", Mathf.Abs(totalMove));
        }




        if (health <= 0)
        {

            Destroy(gameObject);

            SceneManager.LoadScene("Game_Over");


        }

        Health_Bar.value = health;



        if(Input.GetKeyDown(KeyCode.Alpha2))
        {

            SceneManager.LoadScene("lastFight_Cutscene");

        }

        if(Input.GetKeyDown(KeyCode.L))
        {

            SceneManager.LoadScene("Game_Over");

        }

        if(Input.GetKeyDown(KeyCode.V))
        {

            SceneManager.LoadScene("victory_Cutscene");

        }




    }

    private void FixedUpdate()
    {

        rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);
    }


     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("sushi"))
        {
            //... then set the other object we just collided with to inactive.
            other.gameObject.SetActive(false);

            //increases health value
            health += 13;
            SoundManager.PlaySound("Health_Sound");

            if(health > 25)
            {
                health = 25;
            }

        }

    }


}