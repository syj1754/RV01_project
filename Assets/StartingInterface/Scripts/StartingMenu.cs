using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartingMenu : MonoBehaviour
{
    public Toggle[] toggles;
    void Awake(){
        int difficulty= PlayerPrefs.GetInt ("difficulty");
        if (difficulty>0 && difficulty<4){
            toggles[difficulty-1].isOn=true;
        }else{
            toggles[0].isOn=true;
        }
        Camera VRCamera;
        GameObject gameObject=GameObject.Find("OverlookCamera");
        if(gameObject!=null){
            VRCamera=gameObject.GetComponent<Camera>();
            Canvas canvas=GetComponent<Canvas>();
            canvas.worldCamera = VRCamera;
        }else{
            Camera MainCamera;
            gameObject=GameObject.Find("Main Camera");
            MainCamera=gameObject.GetComponent<Camera>();
            MainCamera.enabled=true;
            Canvas canvas=GetComponent<Canvas>();
            canvas.worldCamera = MainCamera;
        }
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
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//编辑状态下退出
        #else
        Application.Quit();//打包编译后退出
        #endif
    }

    public void SetDifficulty()
    {
        if(toggles[0].isOn){
            PlayerPrefs.SetInt("difficulty",1);
        }else if(toggles[1].isOn){
            PlayerPrefs.SetInt("difficulty",2);
        }else if(toggles[2].isOn){
            PlayerPrefs.SetInt("difficulty",3);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

}
