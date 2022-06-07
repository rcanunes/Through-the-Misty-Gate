using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TitleScreenManager _titleScreenManager;
    [SerializeField] private SceneLoader _sceneLoader;
    
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScene(String name)
    {
        if (!SceneLoader.SceneName.TryParse(name, out SceneLoader.SceneName sceneName))
            return;

        _titleScreenManager.FadeOut();

        StartCoroutine(WaitAndLoad(sceneName));
    }
    
    private IEnumerator WaitAndLoad(SceneLoader.SceneName sceneName)
    {
        yield return new WaitForSeconds(1);
        _sceneLoader.LoadScene(sceneName);
    }
}
