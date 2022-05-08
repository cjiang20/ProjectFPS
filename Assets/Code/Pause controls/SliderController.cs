using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderController : MonoBehaviour
{

    [SerializeField]
    private Slider volumeSlider;

    [SerializeField]
    private TextMeshProUGUI volumeTextUI;

    [SerializeField]
    private Slider sensitivitySlider;

    [SerializeField]
    private TextMeshProUGUI sensitivityTextUI;
    
    public void VolumeSlider(float volume){
        if (volumeTextUI != null) {
            volumeTextUI.text = volume.ToString("0.0");
        }   
    }
    public void saveVolumeButton(){
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue",volumeValue);
        LoadVolume();
    }

    void LoadVolume(){
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        if (volumeSlider != null) {
            volumeSlider.value = volumeValue;
            AudioListener.volume = volumeValue;
        }
        VolumeSlider(volumeValue);
    }

    public void SensitivitySlider(float sensitivity){
        if (sensitivityTextUI != null) {
            sensitivityTextUI.text = sensitivity.ToString("0.0");
        }
    }
    public void saveSensitivityButton(){
        float sensitivityValue = sensitivitySlider.value;
        PlayerPrefs.SetFloat("Sensitivity",sensitivityValue);
        LoadSensitivity();
    }

    void LoadSensitivity(){
        float sensitivityValue = PlayerPrefs.GetFloat("Sensitivity");
        if (sensitivitySlider != null) {
            sensitivitySlider.value = sensitivityValue;
        }
        SensitivitySlider(sensitivityValue);
    }
    private void Start(){
        LoadVolume();
        LoadSensitivity();
    }
}
