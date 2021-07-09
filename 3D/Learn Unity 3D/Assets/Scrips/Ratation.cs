using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratation : MonoBehaviour
{
    public Vector3 speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle=speed*Time.deltaTime;
        transform.parent.Rotate(angle);
    }
}
