using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

	void LateUpdate ()
    {
		if(Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;

            SceneManager.LoadScene("Level1");
        }
	}
}
