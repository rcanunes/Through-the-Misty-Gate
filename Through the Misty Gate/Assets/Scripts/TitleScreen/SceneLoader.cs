using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public static SceneLoader instance;

    public float loadTime = 5.0f;

    public enum SceneName {
        TitleScreenScene,
        LoadingScene,
        GameScene
    }

    private void Awake() {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LoadScene(SceneName name) {
        StartCoroutine(SceneLoading(name));
    }

    private IEnumerator SceneLoading(SceneName name) {
        SceneManager.LoadScene(SceneName.LoadingScene.ToString());

        yield return new WaitForSeconds(loadTime);

        SceneManager.LoadScene(name.ToString());
    }
}
