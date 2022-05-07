using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void playGame(){
        SceneManager.LoadScene(1);
    }
    public void levelSelect(){
        SceneManager.LoadScene("LevelSelect");
    }

    public void quitGame(){
        Application.Quit();
    }
}
