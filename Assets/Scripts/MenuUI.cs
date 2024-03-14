using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 主页菜单UI
/// </summary>
public class MenuUI : MonoBehaviour
{
    //TODO:后期考虑是否有必要将所有UI转化为SO来管理
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


    //TODO:是否需要热更新，此方法可能会用于获取游戏信息（名字版本等）
    public void GetGameVersionMessage()
    {

    }
}
