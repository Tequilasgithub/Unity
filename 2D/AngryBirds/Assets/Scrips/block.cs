using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public float maxSpeed=6;
    public float minSpeed=2;
    private SpriteRenderer render;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score;
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
            Dead();
        }
        else if(collision.relativeVelocity.magnitude>minSpeed)
        {
            render.sprite=hurt;
        }
    }
    private void Dead()
    {
        Destroy(gameObject);
        GameObject obj = Instantiate(score,transform.position+new Vector3(0,0.5f,0),Quaternion.identity);
        Destroy(obj,1.5f);
        Instantiate(boom,transform.position,Quaternion.identity);
        //克隆一个boom对象
        
        
    }
}
