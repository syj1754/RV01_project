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
        
        Camera VRCamera;
        GameObject gameObject=GameObject.Find("OverlookCamera");
        if(gameObject!=null){
            VRCamera=gameObject.GetComponent<Camera>();
            Canvas canvas=GetComponent<Canvas>();
            VRCamera.enabled=true;
            canvas.worldCamera = VRCamera;
        }else{
            Camera MainCamera;
            gameObject=GameObject.Find("Camera");
            MainCamera=gameObject.GetComponent<Camera>();
            MainCamera.enabled=true;
            MainCamera.transform.position=new Vector3(0f, 15f, 0f);
            Canvas canvas=GetComponent<Canvas>();
            canvas.worldCamera = MainCamera;
        }
        int difficulty= PlayerPrefs.GetInt ("difficulty");
        if (difficulty>0 && difficulty<4){
            toggles[difficulty-1].isOn=true;
        }else{
            toggles[0].isOn=true;
           
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
        SceneManager.UnloadSceneAsync("StartingScene");
    }

}
