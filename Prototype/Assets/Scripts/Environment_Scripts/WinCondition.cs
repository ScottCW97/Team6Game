using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour 
{

    private GameObject[] enemy_list;



    void Update()
    {
        enemy_list = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log(enemy_list.Length);

        if (enemy_list.Length == 0)
        {

            Invoke("DelayedAction", 3);

        }

    }


    void DelayedAction()
    {

        SceneManager.LoadScene("victory_Cutscene");

    }

}
