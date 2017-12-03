using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSlider : MonoBehaviour {

    public float force;
    
    public bool moving;
    
    public GameObject mainCamera, bg;
    
    public void OnMouseEnter()
    {
        moving = true;
    }
    
    public void OnMouseExit()
    {
        moving = false;
    }
    
    public void Update()
    {
        if(moving)
        {
            if(force < 0 && Camera.main.transform.position.x >= 0)
            {
                mainCamera.transform.position = new Vector3(Camera.main.transform.position.x + force, Camera.main.transform.position.y,Camera.main.transform.position.z);
                bg.GetComponent<Image>().material.mainTextureOffset += Vector2.right* force/13.5f;
            }
            
            if(force > 0 && Camera.main.transform.position.x <= Camera.main.GetComponent<GameManager>().index)
            {
                mainCamera.transform.position = new Vector3(Camera.main.transform.position.x + force, Camera.main.transform.position.y,Camera.main.transform.position.z);
                bg.GetComponent<Image>().material.mainTextureOffset += Vector2.right* force/13.5f;
            }
            
        }
    }

}
