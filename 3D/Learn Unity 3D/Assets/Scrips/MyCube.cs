using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCube : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 30f;
    void Start()
    {
        // Transform target = GameObject.Find("Sphere").transform;
        // this.transform.LookAt(target);
    } 

    // Update is called once per frame
    void Update()
    {
        float angle = speed * Time.deltaTime;
        transform.parent.Rotate(0, 0, angle);
    }
}
