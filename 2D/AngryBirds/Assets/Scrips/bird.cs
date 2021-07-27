using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private bool mouseDown=false;
    public Transform rightPos;
    public float maxDistance=3;
    private SpringJoint2D sp;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseDown)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position -= new Vector3(0,0,Camera.main.transform.position.z);
            if(Vector3.Distance(transform.position,rightPos.position)>maxDistance)
            {
                Vector3 pos = (transform.position-rightPos.position).normalized;//单位话向量
                pos *= maxDistance;
                transform.position=pos+rightPos.position;
            }
        }
    }
    private void OnMouseDown()
    {
        mouseDown=true;
        rb.isKinematic=true;//鼠标拖拽时开启运动学，此时不受物理限制，拖拽时不受重力弹力等因素的干扰，以免获取过多力导致速度过大
    }
    private void OnMouseUp()
    {
        mouseDown=false;
        rb.isKinematic=false;//关闭运动学，开始计算弹力
        Invoke("fly",0.1f);//延迟调用方法，给予计算获取弹簧关节弹力的时间，否则来不及获得弹力就失去弹簧关节作用
    }
    private void fly()
    {
        sp.enabled=false;
    }
}
