using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 a=new Vector3(3,4,5);
        Debug.Log("长度"+a.normalized);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
