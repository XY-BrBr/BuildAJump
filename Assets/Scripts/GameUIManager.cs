using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text BlockCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ˢ�·�������UI��ʾ
    /// </summary>
    /// <param name="count">��ǰ��������</param>
    public void RefreshBlockCount(int count)
    {
        BlockCount.text = count.ToString();
    }
}
