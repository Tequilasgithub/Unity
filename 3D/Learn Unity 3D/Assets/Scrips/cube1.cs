using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube1 : MonoBehaviour
{
     Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            rb.AddRelativeTorque(20,0,0);
        }
        if(Input.GetButton("Jump"))
        {
            rb.AddForce(20,0,0);
        }
    }
}
