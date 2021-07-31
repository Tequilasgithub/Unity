using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : bird
{
    // Start is called before the first frame update
    //public List<pig> pigs=new List<pig>();
    public List<block> blocks=new List<block>();
    ///<summary>
    ///进入触发区
    ///</summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collision2D collision)
    {
        Debug.Log("碰");
        //if(collision.gameObject.tag=="Enemy")
        //{
            // if (collision.gameObject.name=="pig")
            // {
            //     pigs.Add(collision.gameObject.GetComponent<pig>());
            // }
            // else
            // {
            //     blocks.Add(collision.gameObject.GetComponent<block>());
            // }
        //}
    }
    ///<summary>
    ///离开触发区
    ///</summary>
    private void OnTriggerExit2D(Collision2D collision)
    {
        // if(collision.gameObject.tag=="Enemy")
        // {
        //     if (collision.gameObject.name=="pig")
        //     {
        //         pigs.Remove(collision.gameObject.GetComponent<pig>());
        //     }
        //     else
        //     {
        //         blocks.Remove(collision.gameObject.GetComponent<block>());
        //     }
        // }
    }
    
    
    public override void Skill()
    {
        base.Skill();
        
    }
}
