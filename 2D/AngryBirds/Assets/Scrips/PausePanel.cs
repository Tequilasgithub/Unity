using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //用来调用SceneManager方法

public class PausePanel : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public GameObject pauseBottun;
    void Awake()
    {
        anim=GetComponent<Animator>();
    }
    public void OnRetry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2); //加载2号场景(02-game)
    }
    public void OnPause()
    {
        anim.SetBool("isPause",true);
        //播放动画
        pauseBottun.SetActive(false);
        if (GameManager._instance.birds.Count>0)
        {
            if(GameManager._instance.birds[0].isReleased==false) //暂停时即使未释放小鸟，也不能拖拽了
            {
                GameManager._instance.birds[0].canDrag=false;
            }
        }
    }
    public void OnHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void OnResume()
    {
        Time.timeScale=1;
        anim.SetBool("isPause",false);//播放动画

        if (GameManager._instance.birds.Count>0)
        {
            if(GameManager._instance.birds[0].isReleased==false) //取消暂停时恢复可以拖拽
            {
                GameManager._instance.birds[0].canDrag=true;
            }
        }
    }
    public void PauseAnimEnd()
    {
        //Debug.Log("PauseAnimEnd");
        Time.timeScale=0; //时间静止
    }
    public void ResumeAnimEnd()
    {
        //Debug.Log("ResumeAnimEnd");
        pauseBottun.SetActive(true);
    }
}
