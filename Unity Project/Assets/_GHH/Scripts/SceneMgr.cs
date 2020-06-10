using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr Instance;
    private void Awake()
    {
        if(Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string value)
    {
        SceneManager.LoadScene( value);
    }

    public string GetScenName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
