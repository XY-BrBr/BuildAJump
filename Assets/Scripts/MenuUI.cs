using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��ҳ�˵�UI
/// </summary>
public class MenuUI : MonoBehaviour
{
    //TODO:���ڿ����Ƿ��б�Ҫ������UIת��ΪSO������
    private Transform MenuParent;

    [SerializeField] private Text GameTitle_Text;
    [SerializeField] private Button Start_Btn;

    private void Awake()
    {
        MenuParent = transform.Find("MenuParent");

        GameTitle_Text = MenuParent.GetChild(0).GetComponent<Text>();
        Start_Btn = MenuParent.GetChild(1).GetComponent<Button>();
    }

    private void Start()
    {
        InitUI();
    }

    public void InitUI()
    {
        Start_Btn.onClick.AddListener(
            () => {
                StartGame();
            });
    }

    public void StartGame()
    {
        SceneControlller.Instance.LoadScene("Game");
    }


    //TODO:�Ƿ���Ҫ�ȸ��£��˷������ܻ����ڻ�ȡ��Ϸ��Ϣ�����ְ汾�ȣ�
    public void GetGameVersionMessage()
    {

    }
}
