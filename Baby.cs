using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Baby : MonoBehaviour {

    public GameObject eatIcon, poopIcon, hugIcon, gameOver, gameOverText;
    
    public Image babyImage;
    
    public Sprite babyNormal, babyCrying;
    
    public float hunger, poopage, love;
    
    public Slider loveSlider, eatSlider, poopageSlider;
    
    public AudioSource audio;
    
    public AudioClip crySound;
    
    public AudioClip loveSound;
    
    public AudioClip eatSound;
    
    public AudioClip poopSound;
    
    public bool canPlay;
    
    [Header("Baby balance")]
    public float refreshRate;
    [Header("Love")]
    public float loveInitial;
    public float loveDecrementPerRef,hugLimitForIcon,loveIncrementOnHug;
    [Header("Poop")]
    public float poopageInitial;
    public float poopageDecrementOnFeed,poopageLimitForIcon,poopageIncrementOnPoop;
    [Header("Eat")]
    public float hungerInitial;
    public float hungerDecrementPerRef, hungerLimitForIcon,hungerIncrementOnFeed;
    
    
	void Start () {
		
        SetInitialMood();
        InvokeRepeating("UpdateMood",0,refreshRate);
        audio = GetComponent<AudioSource>();
        canPlay = true;
        
	}

    
    public void SetInitialMood()
    {
        hunger = hungerInitial;
        poopage = poopageInitial;
        love = loveInitial;
    }
    
    public void UpdateMood()
    {
        hunger -= hungerDecrementPerRef;
        love -= loveDecrementPerRef;
        
        SetSliders();

        if(hunger <= 0 || poopage <= 0 || love <= 0)
        {
            EndGame();
        }
        
        if(hunger < hungerLimitForIcon || poopage < poopageLimitForIcon || love < hugLimitForIcon)
        {
            SetCryingFace();
        }else{
            SetNormalFace();
        }
        
        if(hunger < hungerLimitForIcon)
        {
            ShowIcon(eatIcon);
        }
        
        if(poopage < poopageLimitForIcon)
        {
            ShowIcon(poopIcon);
        }
        if(love < hugLimitForIcon)
        {
            ShowIcon(hugIcon);
        }
       
    }
    
    public void ShowIcon(GameObject icon)
    {
        icon.SetActive(true);
    }
    
    public void HideIcon(GameObject icon)
    {
        icon.SetActive(false);
    }
    
    public void SetCryingFace()
    {
        babyImage.sprite = babyCrying;
        if(canPlay)
        {
            audio.PlayOneShot(crySound);
            StartCoroutine(CanPlay());
        }
        
    }
    
    public void SetNormalFace()
    {
        babyImage.sprite = babyNormal;
    }
    
    public IEnumerator CanPlay()
    {
        canPlay = false;
        yield return new WaitForSeconds(2);
        canPlay = true;
    }
    public void Feed()
    {
        hunger += hungerIncrementOnFeed;
        poopage -= poopageDecrementOnFeed;
        SetSliders();
        if(hunger >= hungerLimitForIcon)
            HideIcon(eatIcon);
        
        if(hunger < hungerLimitForIcon || poopage < poopageLimitForIcon || love < hugLimitForIcon)
        {
            SetCryingFace();
        }else{
            SetNormalFace();
        }
        
        if(hunger >= 100)
            hunger = 100;
        if(poopage >= 100)
            poopage = 100;
        if(love >= 100)
            love = 100;
        audio.Stop();
        audio.PlayOneShot(eatSound);
        
    }
    
    public void Poop()
    {
        poopage += poopageIncrementOnPoop;
        SetSliders();
        if(poopage >= poopageLimitForIcon)
            HideIcon(poopIcon);
        if(hunger < hungerLimitForIcon || poopage < poopageLimitForIcon || love < hugLimitForIcon)
        {
            SetCryingFace();
        }else{
            SetNormalFace();
        }
        
        if(hunger >= 100)
            hunger = 100;
        if(poopage >= 100)
            poopage = 100;
        if(love >= 100)
            love = 100;
        audio.Stop();
        audio.PlayOneShot(poopSound);
    }
    
    public void Hug()
    {
        
        love += loveIncrementOnHug;
        SetSliders();
        if(love >= hugLimitForIcon)
            HideIcon(hugIcon);
        
        if(hunger < hungerLimitForIcon || poopage < poopageLimitForIcon || love < hugLimitForIcon)
        {
            SetCryingFace();
        }else{
            SetNormalFace();
        }
        
        if(hunger >= 100)
            hunger = 100;
        if(poopage >= 100)
            poopage = 100;
        if(love >= 100)
            love = 100;
        audio.Stop();
        audio.PlayOneShot(loveSound);
    }
    
    public void SetSliders()
    {
        loveSlider.value = love;
        eatSlider.value = hunger;
        poopageSlider.value = poopage;
    }
    
    public void EndGame()
    {
        switch (Camera.main.GetComponent<GameManager>().index) {
            case 1:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 1 baby!\n The same amount as Hillary Clinton!";
                break;
            case 2:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 2 babies!\n Halle Berry has 2 kids as well!";
                break;
            case 3:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 3 babies!\n Owen Wilson is also from family of 3 children";
                break;
            case 4:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 4 babies!\n You are like Madonna!";
                break;
            case 5:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 5 babies!\n Just like Shaquille O'Neal!";
                break;
            case 6:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 6 babies! \n The same as famous director Steven Spielberg!";
                break;
            case 7:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 7 babies! \n Mick Jagger has done the same! ";
                break;
            case 8:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 8 babies!\n The same amount as Mel Gibson!";
                break;
            case 9:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 9 babies!\n Just like Muhammad Ali!";
                break;
            case 10:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 10 babies!\n Don Ho has done it too!";
                break;
            case 11:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 11 babies! Charlie Chaplin had 11 children!\n";
                break;
            case 12:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 12 babies!\n The same as Duane Lee Chapman, the famous bounty hunter!";
                break;
            default:
                gameOverText.GetComponent<TextMeshPro>().text = "You've made it to 13 babies!\n just like godlike DMX!";
                break;
        }
        Camera.main.GetComponent<GameManager>().canvas.SetActive(false);
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }
    
}
