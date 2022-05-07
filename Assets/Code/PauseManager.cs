using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    public InputAction pauseButton;
    [SerializeField]
    private Canvas canvas;

    private bool paused = false;

    private void OnEnable(){
        pauseButton.Enable();
    }
    private void OnDisable() {
        pauseButton.Disable();
    }
    // Start is called before the first frame update
    private void Start()
    {
        pauseButton.performed += _ => Pause();
    }
    public void Pause(){
        paused = !paused;
        if(paused){
            Time.timeScale = 0;
            canvas.enabled = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else{
            Time.timeScale = 1;
            canvas.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void quitToMenu(){
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
