using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls_Screen : MonoBehaviour {

	
	// Update is called once per frame
	void Update () 
    {
        Invoke("DelayedAction", 6);
    }



    void DelayedAction()
    {

        SceneManager.LoadScene("opening_Cutscene");

    }


}
