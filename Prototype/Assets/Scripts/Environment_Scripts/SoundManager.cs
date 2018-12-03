using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{

    public static AudioClip Special_Move_FX;
    public static AudioClip light_attack;
    public static AudioClip heavy_attack;
    public static AudioClip Boss_Fight;
    public static AudioClip TextScrollingSound;
    public static AudioClip kick;
    public static AudioClip Health_Sound;

    static AudioSource audioSrc;

	// Use this for initialization
	void Start () 
    {

        Special_Move_FX = Resources.Load<AudioClip>("Special_Move_FX");
        light_attack = Resources.Load<AudioClip>("light_attack");
        heavy_attack = Resources.Load<AudioClip>("heavy_attack");
        Boss_Fight = Resources.Load<AudioClip>("Boss_Fight");
        TextScrollingSound = Resources.Load<AudioClip>("TextScrollingSound");
        kick = Resources.Load<AudioClip>("kick");
        Health_Sound = Resources.Load<AudioClip>("Health_Sound");

        audioSrc = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () 
    {

	
	}



    public static void PlaySound (string clip)
    {

        switch(clip)
        {
            case "Special_Move_FX":
                audioSrc.PlayOneShot(Special_Move_FX);
                break;

            case "light_attack":
                audioSrc.PlayOneShot(light_attack);
                break;

            case "heavy_attack":
                audioSrc.PlayOneShot(heavy_attack);
                break;

            case "Boss_Fight":
                audioSrc.PlayOneShot(Boss_Fight);
                break;

            case "TextScrollingSound":
                audioSrc.PlayOneShot(TextScrollingSound);
                break;

            case "kick":
                audioSrc.PlayOneShot(kick);
                break;

            case "Health_Sound":
                audioSrc.PlayOneShot(Health_Sound);
                break;
        }


    }

}
