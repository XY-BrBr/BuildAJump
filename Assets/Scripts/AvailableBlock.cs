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
        Debug.Log("��ȡЧ��!!");

        //TODO:�����鹦�ܳ���ɽӿڣ��ڴ˵��ò�ͬ����
        #region ��ӷ����������
        GameObject.Find("Controller").GetComponent<GameController>().ChangeBlockCount(2);
        #endregion 

        gameObject.SetActive(false);
    }
}
