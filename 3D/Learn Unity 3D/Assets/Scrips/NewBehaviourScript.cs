using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public float speed;
    void Start()
        {

        }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            transform.LookAt(target);
        float distance = speed * Time.deltaTime;
        transform.Translate(0, 0, distance,Space.Self);
    }
}
