using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject boom;
    protected virtual void OnCollisionEnter2D(Collision2D collision) //
    {
        if (collision.relativeVelocity.magnitude>4)
        {
            if(collision.gameObject.tag=="Enemy")
            {
                //Debug.Log("Enemy");
                Destroy(gameObject);
                Instantiate(boom,transform.position,Quaternion.identity);
            }
            
        }
        
    }
}
