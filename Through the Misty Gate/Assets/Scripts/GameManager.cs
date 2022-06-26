using System;
using System.Collections;
using System.Linq;
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

    public void SwitchScene(int name)
    {
        
        _titleScreenManager.FadeOut();
        if (name > Enum.GetValues(typeof(SceneName)).Cast<int>().Max())
            Debug.Log("No such scene");
        if (name < Enum.GetValues(typeof(SceneName)).Cast<int>().Min())
            Debug.Log("No such scene");

        StartCoroutine(WaitAndLoad((SceneName) name));
    }
    
    private IEnumerator WaitAndLoad(SceneName sceneName)
    {
        yield return new WaitForSeconds(1);
        _sceneLoader.LoadScene(sceneName);
    }
}
