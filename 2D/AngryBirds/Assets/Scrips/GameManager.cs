using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager _instance;
    public List<bird> birds;
    public List<pig> pigs;
    private Vector3 origionPos;
    //小鸟起始位置
    public GameObject win;
    public GameObject lose;
    public GameManager[] stars;
    private void Awake()
    {
        if(birds.Count>0)
        origionPos = birds[0].transform.position;
    }
    void Start()
    {
        _instance = this;
        
        Initialized();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialized()//初始化
    {
        for(int i=0;i<birds.Count;i++)
        {
            if(i==0)
            {
                birds[i].transform.position=origionPos;
                birds[i].enabled    = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled    = false;
                birds[i].sp.enabled = false;
            }
        }
    }
    public void NextBird()//下一只小鸟初始化的逻辑判断
    {
        if(pigs.Count>0)
        {
            if(birds.Count>0)
            //进行中
            {
                Initialized();
                
            }
            else
            //输
            {
                lose.SetActive(true);
            }
        }
        else
        //赢
        {
              win.SetActive(true);
        }
    }
    public void ShowStars()
    {
        for(int i = 0;i<birds.Count;i++)
        {
            
        }
    }
}
