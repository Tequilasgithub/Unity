using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //
public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public static GameManager _instance;
    public List<bird> birds; //小鸟脚本的列表
    public List<pig> pigs; //猪脚本的列表
    private Vector3 origionPos; //小鸟起始位置
    public GameObject win; //胜利UI
    public GameObject lose; //失败UI
    public GameObject[] stars; //星星数组
    private void Awake()
    {
        if(birds.Count>0)
        origionPos = birds[0].transform.position;
        //将小鸟的起始位置设置为第一只鸟的位置
    }
    void Start()
    {
        _instance = this;
        Initialized(); //初始化
    }
    ///<summary>
    ///初始化声明
    ///</summary>
    private void Initialized() 
    {
        for(int i=0;i<birds.Count;i++)
        {
            if(i==0) //第一只小鸟
            {
                birds[i].transform.position=origionPos;
                birds[i].enabled    = true; //脚本启动
                birds[i].sp.enabled = true; //弹簧关节启动
            }
            else //其他小鸟
            {
                birds[i].enabled    = false; //脚本关闭
                birds[i].sp.enabled = false; //弹簧关节关闭
            }
        }
    }
    ///<summary>
    ///下一只小鸟初始化或者游戏结束的逻辑判断
    ///</summary>
    public void NextBird() 
    {
        if(pigs.Count>0) //有剩下的猪
        {
            if(birds.Count>0) //还有小鸟，未结束
            {
                Initialized();
                
            }
            else //无小鸟，输
            {
                lose.SetActive(true);
            }
        }
        else //赢
        {
              win.SetActive(true);
        }
    }
    ///<summary>
    ///根据剩余小鸟数决定星星
    ///</summary>
    public void ShowStars()
    {
        StartCoroutine("show");
        //继续运行协程show
    }
    ///<summary>
    ///协程, 就像一个函数, 能够暂停执行并将控制权返还给Unity, 然后在下一帧继续执行
    ///</summary>
    IEnumerator show()
    {
        for(int i = 0;i<birds.Count+1;i++)
        {
            yield return new WaitForSeconds(0.2f); //0.2秒后恢复
            //默认情况下，协程将在执行 yield 后的帧上恢复，但也可以使用 WaitForSeconds 来引入时间延迟
            //可通过这样的协程在一段时间内传播效果，但也可将其作为一种有用的优化
            stars[i].SetActive(true); //启动星星
        }
    }
    public void Retry() //retry键
    {
        SceneManager.LoadScene(2); //加载2号场景(02-game)
    }
    public void Home() //home键
    {
        SceneManager.LoadScene(1); //加载1号场景(01-level)
    }
}
