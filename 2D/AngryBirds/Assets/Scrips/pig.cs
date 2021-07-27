using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float maxSpeed=10;
    public float minSpeed=5;
    private SpriteRenderer render;
    public Sprite hurt;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude>maxSpeed)
        {
            Destroy(gameObject);
        }
        else if(collision.relativeVelocity.magnitude>minSpeed)
        {
            render.sprite=hurt;
        }

    }
}
