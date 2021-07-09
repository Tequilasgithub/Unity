using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BackGroundMovingSpeed = 0.03f;
    public static bool click=false;
    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    //public float BackGroundMovingSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("player start");
        Application.targetFrameRate = 60;
        this.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private bool toUp=true;
    private int index=0;
    // Update is called once per frame
    void Update()
    { 
        float step = BackGroundMovingSpeed * Application.targetFrameRate * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            click = true;
            Debug.Log("click");
            //DoChange();
        }
        if (click)
        {
            if (this.transform.position.y > -2.2)
            {
                step = -step;
                toUp = false;
                DoChange();
            }
            if (this.transform.position.y <= -2.2 && !toUp)
            {
                step = -step;
                //DoChange();
            }
            if (this.transform.position.y < -2.5)
            {
                toUp = true;
                this.transform.position = new Vector3(0, -2.4f, 0);
                click = false;
                DoChange();
            }
            this.transform.Translate(0, step, 0);
        }
        void DoChange()
        {
            SpriteRenderer playerRender = GetComponent<SpriteRenderer>();
            if (index == 0)
            {
                index = 1;
                playerRender.sprite = this.sprite1;
            }
            else if (index == 1)
            {
                index = 2;
                playerRender.sprite = this.sprite2;
            }
            else if (index == 2)
            {
                index = 3;
                playerRender.sprite = this.sprite3;
            }
            else if (index == 3)
            {
                index = 4;
                playerRender.sprite = this.sprite4;
            }
            else if (index == 4)
            {
                index = 5;
                playerRender.sprite = this.sprite5;
            }
            else if (index == 5)
            {
                index = 0;
                playerRender.sprite = this.sprite0;
            }
        }
    }
}
