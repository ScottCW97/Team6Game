using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAME_OVER : MonoBehaviour 
{

    public void RestartGame ()
    {

        SceneManager.LoadScene("Level_1");

    }





    public void QuitGame ()
    {

        Debug.Log("QUIT!");
        Application.Quit();

    }


}


