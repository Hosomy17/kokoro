using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScriptTutorial : MonoBehaviour
{

    public string scene;
    public float time;

    private AsyncOperation asyncOpe;

	void Start ()
    {
        asyncOpe = SceneManager.LoadSceneAsync(scene);
        asyncOpe.allowSceneActivation = false;
        Invoke("StartScene",time);
	}
    void Update()
    {
    }
    private void StartScene()
    {
        asyncOpe.allowSceneActivation = true;
    }
}
