using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GameState
{
    init = 0,
    start,
    end
}

/// <summary>
/// 人物在开始后会自动进行跳跃
/// 玩家可以通过手机触屏或键盘A、D控制人物水平方向的移动
/// </summary>
public class PlayerController : MonoBehaviour
{
    Rigidbody2D p_rigidbody;
    Collider2D p_collider;

    GameState gameState;

    public Transform checkGround;

    [Header("游戏数据")]
    //跳跃
    public float jumpTime = 0.5f;
    public float jumpForce = 5f;
    [SerializeField] private float tempTime = -1f;

    //左右平移
    public float Speed_h = 3f;
    [SerializeField] private float Input_h;

    //游戏进程相关
    private bool isDead;
    
    private void Awake()
    {
        p_rigidbody = GetComponent<Rigidbody2D>();
        p_collider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("切换至初始化模式");
        gameState = GameState.init;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //死亡逻辑
        //碰到红色方块就会si，重开游戏
        if(isDead == true)
        {
            isDead = false;
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            return;
        }

        switch (gameState)
        {
            //demo...点击Enter后开始切换为游戏开始状态
            case GameState.init:
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Debug.Log("切换至游戏开始模式");
                    gameState = GameState.start;
                }
                break;
            case GameState.start:
                //人物检测到落地就自动跳跃
                tempTime = tempTime - Time.deltaTime;
                Ray2D ray = new Ray2D(checkGround.position, new Vector2(0, 0.1f));
                RaycastHit2D hit = Physics2D.Raycast(checkGround.position, new Vector2(0, -0.1f), 0.1f, LayerMask.GetMask("Ground"));

                if(hit.collider != null && tempTime < 0f)
                {
                    tempTime = jumpTime;
                    Jump();
                }

                //无论落地与否都可以左右移动
                Move();

                //Debug.Log("切换至游戏结束模式");
                break;
            case GameState.end:
                break;
        }
    }

    private void OnDrawGizmos()
    {
        //Ray2D ray = new Ray2D(checkGround.position, new Vector2(0, -0.1f));
        Gizmos.color = Color.red;

        Gizmos.DrawRay(checkGround.position, new Vector2(0, -0.1f));
    }

    private void Jump()
    {
        //Debug.Log("跳跃！！");
        //跳跃逻辑

        p_rigidbody.velocity = new Vector2(p_rigidbody.velocity.x, 0f);
        p_rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Move()
    {
        Input_h = Input.GetAxis("Horizontal");

        //transform.position
        p_rigidbody.velocity = new Vector2(Input_h * Speed_h, p_rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Error")
        {
            Debug.Log("玩家死亡");

            isDead = true;
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Avaliable")
        {
            //每一种可获取方块可能都会有不同的效果
            //因此需要调用方块的效果方法
            //TODO:此处可能需要单例来支持对游戏底层的数据获取

            
            collision.transform.GetComponent<AvailableBlock>().GetEffect();
        }
    }
}
