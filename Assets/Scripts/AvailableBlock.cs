using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetEffect()
    {
        Debug.Log("获取效果!!");

        //TODO:将方块功能抽象成接口，在此调用不同方法
        #region 添加方块基础功能
        GameObject.Find("Controller").GetComponent<GameController>().ChangeBlockCount(2);
        #endregion 

        gameObject.SetActive(false);
    }
}
