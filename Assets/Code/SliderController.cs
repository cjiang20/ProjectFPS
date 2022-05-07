using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    [SerializeField]
    private Slider volumeSlider = null;

    [SerializeField]
    private Text volumeTextUI =  null;
    // Start is called before the first frame update
    public void VolumeSlider(float volume){
        volumeTextUI.text = volume.ToString("0.0");
    }
    public void saveVolumeButton(){
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue",volumeValue);
        LoadValues();
    }

    void LoadValues(){
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
        VolumeSlider(volumeValue);
    }
    private void Start(){
        LoadValues();
    }
}
