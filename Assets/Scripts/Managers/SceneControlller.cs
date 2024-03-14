using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景管理器
/// </summary>
public class SceneControlller : Singleton<SceneControlller>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// 加载场景方法
    /// </summary>
    /// <param name="scene"></param>
    public void LoadScene(string scene)
    {
        Debug.Log($"切换至场景 {scene} <===注意场景名是否正确");
        StartCoroutine(LoadLevel(scene));
    }

    /// <summary>
    /// 加载场景方法
    /// </summary>
    /// <param name="scene"></param>
    public void LoadScene(int scene)
    {
        StartCoroutine(LoadLevel(scene));
    }

    /// <summary>
    /// 加载场景协程
    /// </summary>
    /// <param name="scene">场景名</param>
    /// <returns></returns>
    IEnumerator LoadLevel(string scene)
    {
        if(scene != "")
        {
            yield return SceneManager.LoadSceneAsync(scene);
            yield break;
        }
    }

    /// <summary>
    /// 加载场景协程
    /// </summary>
    /// <param name="scene">场景编号</param>
    /// <returns></returns>
    IEnumerator LoadLevel(int? scene)
    {
        if (scene != null)
        {
            yield return SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Single);
            yield break;
        }
    }
}
