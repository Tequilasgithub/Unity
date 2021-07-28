using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float maxSpeed=8;
    public float minSpeed=4;
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
        GameManager._instance.pigs.Remove(this);
        GameObject obj = Instantiate(score,transform.position+new Vector3(0,0.5f,0),Quaternion.identity);
        Destroy(obj,1.5f);
        Destroy(gameObject);
        Instantiate(boom,transform.position,Quaternion.identity);
        //克隆一个boom对象
        
        
    }
}
