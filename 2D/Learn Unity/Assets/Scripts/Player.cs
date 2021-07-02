using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BackGroundMovingSpeed = 0.03f;
    public static bool click=false;
    //public float BackGroundMovingSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("player start");
        Application.targetFrameRate = 60;
        this.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private bool toUp=true;
    
    // Update is called once per frame
    void Update()
    {
        float step = BackGroundMovingSpeed * Application.targetFrameRate * Time.deltaTime;
        if(Input.GetMouseButtonDown(0))
        {
            click=true;
            Debug.Log("click");
        }
        if(click)
        {
            if (this.transform.position.y > -2.2)
        {
            step = -step;
            toUp =false;
        }
        if (this.transform.position.y <= -2.2 && !toUp)
        {
            step = -step;
        }
        if (this.transform.position.y < -2.5)
        {
            toUp = true;
            this.transform.position=new Vector3(0,-2.4f,0);
            click=false;
        }
        this.transform.Translate(0, step, 0);
        }    
        
    }
}
