using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class ScoreMenu : MonoBehaviour
{
    private int score;
    private int highscore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    void Start (){ 
        Cursor.lockState = CursorLockMode.None;
        string sceneName = PlayerPrefs.GetString("currScene");
        score = PlayerPrefs.GetInt("currScore");
        highscore = PlayerPrefs.GetInt("highscoreBool");
        if (highscore == 1) {
            scoreText.text = "NEW HIGHSCORE: " + score;
        }
        else {
            scoreText.text = "SCORE: " + score;
        }
        Debug.Log(sceneName);
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt(sceneName);
   }
   public void Continue() {
     SceneManager.LoadScene((PlayerPrefs.GetInt("currSceneInt") + 1)%5);
   }
   public void levelSelect(){
        SceneManager.LoadScene("LevelSelect");
    }
    public void quitGame(){
        Application.Quit();
    }
}
