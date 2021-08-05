using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBird : bird
{
    public GameObject egg;
    public override void Skill()
    {
        base.Skill();
        Vector3 v=new Vector3(0,-0.5f,0);
        Instantiate(egg,transform.position+v,Quaternion.identity);
    }
}
