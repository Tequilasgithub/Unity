using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : bird
{
    // Start is called before the first frame update
    public List<pig> pigs=new List<pig>();
    public List<block> blocks=new List<block>();
    ///<summary>
    ///进入触发区
    ///</summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.gameObject.tag=="Enemy")
        {
            if(collider.gameObject.GetComponent<pig>()==true)
            {
                pigs.Add(collider.gameObject.GetComponent<pig>());
            }
            else
            {
                blocks.Add(collider.gameObject.GetComponent<block>());
            }
                
        }
    }
    ///<summary>
    ///离开触发区
    ///</summary>
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Enemy")
        {
            if (collider.gameObject.GetComponent<pig>()==true)
            {
                pigs.Remove(collider.gameObject.GetComponent<pig>());
            }
            else
            {
                blocks.Remove(collider.gameObject.GetComponent<block>());
            }
        }
    }
    
    
    public override void Skill()
    {
        base.Skill();
        if(blocks.Count>0)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Dead();
            }
        }
        if(pigs.Count>0)
        {
            for (int i = 0; i < pigs.Count; i++)
            {
                pigs[i].Dead();
            }
        }
        OnClear();
    }
    void OnClear()
    {
        rb.velocity=Vector3.zero;
        Instantiate(boom,transform.position,Quaternion.identity);
        render.enabled=false;
        GetComponent<CircleCollider2D>().enabled=false;
        myTrail.trailEnd();
    }
    protected override void changeToNextBird()
        {
            GameManager._instance.birds.Remove(this);
            Destroy(gameObject);
            //Instantiate(boom,transform.position,Quaternion.identity); //实例化一个新的组件或预制体
            GameManager._instance.NextBird(); //下一只小鸟初始化或者游戏结束的逻辑判断
        }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        myTrail.trailEnd();
        isFly=false;
        if (collision.relativeVelocity.magnitude>4)
        {
            Skill();
        }
    }
}
