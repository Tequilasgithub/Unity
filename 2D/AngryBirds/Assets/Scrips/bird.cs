using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private bool mouseDown=false;
    
    public float maxDistance=3; //最大弹簧关节距离
    [HideInInspector]//隐藏sp
    public SpringJoint2D sp; //弹簧关节
    private Rigidbody2D rb; //刚体


    public LineRenderer lineRight;
    public LineRenderer lineLeft;
    public Transform rightPos;
    public Transform leftPos;
    public GameObject boom; //爆炸组件
    private TestMyTrail myTrail; //拖尾脚本
    private bool canDrag=true; //小鸟是否可以拖拽
    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        myTrail=GetComponent<TestMyTrail>();
        //由于要在其他类中访问sp，所以要在awake中赋值，否则访问时会出现未赋值的情况
    }
    // Start is called before the first frame update
    void Start()
    {
        //sp = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseDown)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); //小鸟随鼠标拖拽
            transform.position -= new Vector3(0,0,Camera.main.transform.position.z); //减去相机z轴坐标
            if(Vector3.Distance(transform.position,rightPos.position)>maxDistance) //超过最大距离
            {
                Vector3 pos = (transform.position-rightPos.position).normalized;//单位化小鸟到右弹弓的向量
                pos *= maxDistance; //再乘最大值
                transform.position=pos+rightPos.position; //小鸟坐标等于右弹弓坐标加上（鼠标到右弹弓的单位向量乘最大值）
            }
            line();
        }
    }
    private void OnMouseDown()
    {
        if(canDrag)
        {
            mouseDown=true;
            rb.isKinematic=true;
            //鼠标拖拽时开启运动学，此时不受物理限制，拖拽时不受重力弹力等因素的干扰，以免获取过多力导致速度过大
        }
    }
    private void OnMouseUp()
    {
        if(canDrag)
        {
            mouseDown=false;
            rb.isKinematic=false; //关闭运动学，开始计算弹力
            Invoke("fly",0.05f);
            //延迟调用方法，给予计算获取弹簧关节弹力的时间，否则来不及获得弹力就失去弹簧关节作用
            lineLeft.enabled=false;
            lineRight.enabled=false;
        }
        canDrag=false;
    }
    private void fly() //起飞
    {
        myTrail.trailStart(); //开始拖尾
        sp.enabled=false; //弹簧关节关闭
        Invoke("changeToNextBird",4); //延时后换下一只小鸟
    }
    private void line() //画线
    {
        lineLeft.enabled=true;
        lineRight.enabled=true;
        lineRight.SetPosition(0,rightPos.position);
        lineRight.SetPosition(1,transform.position);

        lineLeft.SetPosition(0,leftPos.position);
        lineLeft.SetPosition(1,transform.position);
    }
    private void changeToNextBird()//此小鸟销毁,下一只小鸟初始化
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom,transform.position,Quaternion.identity); //实例化一个新的组件或预制体
        GameManager._instance.NextBird(); //下一只小鸟初始化或者游戏结束的逻辑判断
    }
    private void OnCollisionEnter2D(Collision2D collision) //
    {
        myTrail.trailEnd();
    }
}
