using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconAnimation : MonoBehaviour {
    
    public Sprite Texture1;
    public Sprite Texture2;
	void Start () {
        InvokeRepeating("Animate",0,0.3f);
	}
    
    public void Animate()
    {
        if(GetComponent<Image>().sprite == Texture2)
        {
            GetComponent<Image>().sprite = Texture1;
        }else{
            GetComponent<Image>().sprite = Texture2;
        }
    }

}
