using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float BackGroundMovingSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("background start");
        Application.targetFrameRate = 60;
    }
    //
    // Update is called once per frame
    void Update()
    {
        if(Player.click)
        {
        if (this.transform.position.x < -4f)
        {
            this.transform.position = new Vector3(this.transform.position.x+4f, this.transform.position.y, this.transform.position.z);
        }
        float step = BackGroundMovingSpeed * Application.targetFrameRate * Time.deltaTime;
        this.transform.Translate(-step, 0, 0);
        } 
    }
}
