using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    public int index;
    
    public GameObject babyPrefab, canvas, gameOver, gameOverText, scoreText;
    
	void Start () {
        
        InvokeRepeating("SpawnBaby",0,10);
	}
	
    public void GameOver()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
	public void SpawnBaby()
    {
        GameObject baby = Instantiate(babyPrefab,canvas.transform);
        baby.transform.localPosition = new Vector3(-250 + 250*index,-200,-1);
        baby.GetComponent<Baby>().gameOver = gameOver;
        baby.GetComponent<Baby>().gameOverText = gameOverText;
        baby.GetComponent<Baby>().refreshRate -= 0.005f * index;
        index ++;
        scoreText.GetComponent<TextMeshPro>().text = "BABIES: " + index;
    }
    
}
