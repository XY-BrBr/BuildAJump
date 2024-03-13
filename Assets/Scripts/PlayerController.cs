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
/// �����ڿ�ʼ����Զ�������Ծ
/// ��ҿ���ͨ���ֻ����������A��D��������ˮƽ������ƶ�
/// </summary>
public class PlayerController : MonoBehaviour
{
    Rigidbody2D p_rigidbody;
    Collider2D p_collider;

    GameState gameState;

    public Transform checkGround;

    [Header("��Ϸ����")]
    //��Ծ
    public float jumpTime = 0.5f;
    public float jumpForce = 5f;
    [SerializeField] private float tempTime = -1f;

    //����ƽ��
    public float Speed_h = 3f;
    [SerializeField] private float Input_h;

    //��Ϸ�������
    private bool isDead;
    
    private void Awake()
    {
        p_rigidbody = GetComponent<Rigidbody2D>();
        p_collider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�л�����ʼ��ģʽ");
        gameState = GameState.init;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�����߼�
        //������ɫ����ͻ�si���ؿ���Ϸ
        if(isDead == true)
        {
            isDead = false;
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            return;
        }

        switch (gameState)
        {
            //demo...���Enter��ʼ�л�Ϊ��Ϸ��ʼ״̬
            case GameState.init:
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Debug.Log("�л�����Ϸ��ʼģʽ");
                    gameState = GameState.start;
                }
                break;
            case GameState.start:
                //�����⵽��ؾ��Զ���Ծ
                tempTime = tempTime - Time.deltaTime;
                Ray2D ray = new Ray2D(checkGround.position, new Vector2(0, 0.1f));
                RaycastHit2D hit = Physics2D.Raycast(checkGround.position, new Vector2(0, -0.1f), 0.1f, LayerMask.GetMask("Ground"));

                if(hit.collider != null && tempTime < 0f)
                {
                    tempTime = jumpTime;
                    Jump();
                }

                //���������񶼿��������ƶ�
                Move();

                //Debug.Log("�л�����Ϸ����ģʽ");
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
        //Debug.Log("��Ծ����");
        //��Ծ�߼�

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
            Debug.Log("�������");

            isDead = true;
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Avaliable")
        {
            //ÿһ�ֿɻ�ȡ������ܶ����в�ͬ��Ч��
            //�����Ҫ���÷����Ч������
            //TODO:�˴�������Ҫ������֧�ֶ���Ϸ�ײ�����ݻ�ȡ

            
            collision.transform.GetComponent<AvailableBlock>().GetEffect();
        }
    }
}
