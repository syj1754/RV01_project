using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartingMenu : MonoBehaviour
{
    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        EditorApplication.Exit(0);
    }

    public void SetDifficulty()
    {
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartingScene");
    }

    public void Pause()
    {
        SceneManager.LoadScene("PauseScene");
    }
}
