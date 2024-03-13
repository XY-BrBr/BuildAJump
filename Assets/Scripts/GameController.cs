using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject prefabs;

    //TODO:后续需要考虑是否将方块数据分离
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
            if(BlockCurrentCount <= 0) { Debug.Log("已经没有方块了...."); return; }

            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Instantiate(prefabs, pos, Quaternion.identity);
            ChangeBlockCount(-1);
        }
    }

    /// <summary>
    /// 更改剩余方块数量
    /// 游戏数据和UI界面
    /// </summary>
    /// <param name="count">更改的数量，正为增加，负为减少</param>
    public void ChangeBlockCount(int count)
    {
        if(count != 0)
            BlockCurrentCount = BlockCurrentCount + count;

        //TODO:需要更改为单例调用
        GameObject.Find("Canvas").GetComponent<UIManager>().RefreshBlockCount(BlockCurrentCount);
    }
}
