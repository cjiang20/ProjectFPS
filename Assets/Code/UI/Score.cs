using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public (int,int) getScore(float time, float accuracy, float damage) {
        int score = (int)(20f-time + (damage*accuracy));
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        if (score < 0) {
            score = 0;
        }
        if (PlayerPrefs.HasKey(sceneName)) {
            if (PlayerPrefs.GetInt(sceneName) < score) {
                Debug.Log(sceneName);
                PlayerPrefs.SetInt(sceneName, score);
                return (1,score);
            }
        }
        else {
            PlayerPrefs.SetInt(sceneName, score);
            return (1,score);
        }
        return (0, score);
    }
}
