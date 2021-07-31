using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : bird
{
    // Start is called before the first frame update
    public override void Skill()
    {
        base.Skill();
        rb.velocity*=2;
    }
}
