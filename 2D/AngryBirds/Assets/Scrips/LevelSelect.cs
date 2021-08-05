using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public bool isSelect=false;
    public Sprite levelBG;
    private Image image;
    public GameObject[] stars;

    void Awake()
    {
        image=GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent.GetChild(0).name==gameObject.name)
        //第一关可选
        {
            isSelect=true;
        }
        else //若前一关星星数大于0，此关可选
        {
            int beforeNum = int.Parse(gameObject.name)-1; //将关卡名转化为int，再-1
            if(PlayerPrefs.GetInt("level"+beforeNum.ToString())>0)
            {
                isSelect=true;
            }
        }
        if(isSelect)
        {
            image.overrideSprite=levelBG;
            transform.Find("num").gameObject.SetActive(true);
            int count=PlayerPrefs.GetInt("level"+gameObject.name);
            //获取本关卡的星星数（存储在“levelx”中）
            if(count>0)
            {
                for (int i = 0; i < count; i++)
                {
                    stars[i].SetActive(true);
                }
            }
        }
    }

    public void Selected()
    {
        if(isSelect)
        {
            PlayerPrefs.SetString("nowLevel","level"+gameObject.name);
            //存储游戏数据，将关卡号存储到“nowLevel”中
            SceneManager.LoadScene(2);
            
        }
    }
}
