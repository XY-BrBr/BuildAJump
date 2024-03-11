using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    
    public float smooth;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.y > transform.position.y + distance)
        {
            transform.position = new Vector3(transform.position.x, 
                Mathf.Lerp(transform.position.y, playerTransform.position.y - distance, smooth * Time.deltaTime), 
                transform.position.z);
        }
    }
}
