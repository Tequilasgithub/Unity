using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour
{
    public int starsNum=0;
    private bool isSelect=false;
    public GameObject locks;
    public GameObject stars;
    public GameObject panel;
    public GameObject map;
    public Text starsText; //地图面板显示获取星星数/总星星数的文本
    public int startNum=1;
    public int endNum=5;
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        if(PlayerPrefs.GetInt("totalStarsNum",0)>=starsNum)
        {
            isSelect=true;
        }
        if(isSelect)
        {
            locks.SetActive(false);
            stars.SetActive(true);

            //地图面板显示获取星星数/总星星数
            int counts=0;
            for (int i = startNum; i < endNum; i++)
            {
                counts+=PlayerPrefs.GetInt("level"+i.ToString(),0);
                //将本地图每一关的星星数求和
            }
            starsText.text=counts.ToString()+"/15";
        }
    } 
    ///<summary>
    ///鼠标点击
    ///</summary>
    public void Selected()
    {
        if(isSelect)
        {
            panel.SetActive(true);
            map.SetActive(false);
        }
    }
    public void PanelReturn()
    {
        panel.SetActive(false);
        map.SetActive(true);
    }
}
