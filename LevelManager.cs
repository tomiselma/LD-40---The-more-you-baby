using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void QuitGame()
    {
        Application.Quit();
    }
    
    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }
}
