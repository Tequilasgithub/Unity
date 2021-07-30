using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
    public void OnPause()
    {
        anim.SetBool("isPause",true);
        //播放动画
        pauseBottun.SetActive(false);
    }
    public void OnHome()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void OnResume()
    {
        Time.timeScale=1;
        anim.SetBool("isPause",false);
        //播放动画
    }
    public void PauseAnimEnd()
    {
        //Debug.Log("PauseAnimEnd");
        Time.timeScale=0;
    }
    public void ResumeAnimEnd()
    {
        //Debug.Log("ResumeAnimEnd");
        pauseBottun.SetActive(true);
    }
}
