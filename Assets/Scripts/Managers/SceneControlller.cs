using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ����������
/// </summary>
public class SceneControlller : Singleton<SceneControlller>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// ���س�������
    /// </summary>
    /// <param name="scene"></param>
    public void LoadScene(string scene)
    {
        Debug.Log($"�л������� {scene} <===ע�ⳡ�����Ƿ���ȷ");
        StartCoroutine(LoadLevel(scene));
    }

    /// <summary>
    /// ���س�������
    /// </summary>
    /// <param name="scene"></param>
    public void LoadScene(int scene)
    {
        StartCoroutine(LoadLevel(scene));
    }

    /// <summary>
    /// ���س���Э��
    /// </summary>
    /// <param name="scene">������</param>
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
    /// ���س���Э��
    /// </summary>
    /// <param name="scene">�������</param>
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
