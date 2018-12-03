using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour 
{
    public void PlayGame()
    {

        SceneManager.LoadScene("Controls");

    }





    public void QuitGame()
    {

        Debug.Log("QUIT!");
        Application.Quit();

    }


}
