using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance => _instance ??= new GameObject("GameController").AddComponent<GameController>();

    //Esto y el diccionario est�n para no hacerse quilombo si el d�a de ma�ana quer�s agregar una escena m�s o quer�s hacer alguna otra cosa. Las agregas ac� y lo cambias todo desde el m�todo.
    public enum Scenes
    {
        None = 0,
        MainMenu = 1,
        Gameplay = 2,
        Testing = 3
    }

    private Dictionary<Scenes, string> scenesDict = new Dictionary<Scenes, string>()
    {
        { Scenes.MainMenu, "MainMenu" },
        { Scenes.Gameplay, "Gameplay" },
        { Scenes.Testing, "SampleScene" }
    };

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(Instance.gameObject);
            return;
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        ChangeScene(Scenes.MainMenu);
    }

    // Con esto cambias de escena je
    public void ChangeScene(Scenes scene)
    {
        if (scenesDict.TryGetValue(scene, out string sceneName))
        {
            Debug.Log(sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }

    internal void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
