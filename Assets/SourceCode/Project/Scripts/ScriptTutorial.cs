using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScriptTutorial : MonoBehaviour
{

    public string scene;
    public float time;
    public float timeMusic;

    private AudioSource music;

    private AsyncOperation asyncOpe;

	void Start ()
    {
        asyncOpe = SceneManager.LoadSceneAsync(scene);
        asyncOpe.allowSceneActivation = false;

        GameObject sound = GameObject.Find("Kokoro Music");
        if(sound == null)
        {
            sound = Resources.Load("Kokoro Music") as GameObject;
            sound = Instantiate(sound);
            sound.name = "Kokoro Music";
            DontDestroyOnLoad(sound);

            music = sound.GetComponent<AudioSource>();
            music.time = timeMusic;
            music.Play();
        }
        else
        {
            music = sound.GetComponent<AudioSource>();
            if(!music.isPlaying)
            {
                music.time = timeMusic;
                music.Play();
            }
        }
        

        Invoke("StartScene", time);
	}
    void Update()
    {
    }
    private void StartScene()
    {
        
        asyncOpe.allowSceneActivation = true;
    }
}
