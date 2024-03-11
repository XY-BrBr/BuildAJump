using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBlockTest : MonoBehaviour
{
    public GameObject prefabs;

    // Start is called before the first frame update
    void Start()
    {
        
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
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Instantiate(prefabs, pos, Quaternion.identity);
        }
    }
}
