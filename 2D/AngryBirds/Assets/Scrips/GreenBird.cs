using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBird : bird
{
    // Start is called before the first frame update
    public override void Skill()
    {
        base.Skill();
        Vector3 speed=rb.velocity;
        speed.x*=-1;
        rb.velocity = speed;
    }
}
