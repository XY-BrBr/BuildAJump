using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject prefabs;

    //TODO:������Ҫ�����Ƿ񽫷������ݷ���
    [SerializeField] private int BlockCount = 10;
    public int BlockCurrentCount;

    // Start is called before the first frame update
    void Start()
    {
        BlockCurrentCount = BlockCount;
        ChangeBlockCount(0);
    }

    // Update is called once per frame
    void Update()
    {
        DoBuildBlock();
    }

    public void DoBuildBlock()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(BlockCurrentCount <= 0) { Debug.Log("�Ѿ�û�з�����...."); return; }

            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Instantiate(prefabs, pos, Quaternion.identity);
            ChangeBlockCount(-1);
        }
    }

    /// <summary>
    /// ����ʣ�෽������
    /// ��Ϸ���ݺ�UI����
    /// </summary>
    /// <param name="count">���ĵ���������Ϊ���ӣ���Ϊ����</param>
    public void ChangeBlockCount(int count)
    {
        if(count != 0)
            BlockCurrentCount = BlockCurrentCount + count;

        //TODO:��Ҫ����Ϊ��������
        GameObject.Find("Canvas").GetComponent<UIManager>().RefreshBlockCount(BlockCurrentCount);
    }
}
