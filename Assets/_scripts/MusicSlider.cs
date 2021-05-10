using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour{
    private Slider musicVolume, soundFxVolume;
    public AudioSource musica;
    public AudioSource[] sons;
    GameManager gm;
    void Start() {
        gm = GameManager.GetInstance();
        musicVolume.value = musica.volume*100f;
        foreach (AudioSource som in sons) {
            som.volume = 0.3f;
        }
        soundFxVolume.value = 0.3f;
    }
    private void OnEnable() {
        musicVolume = GameObject.FindWithTag("BackgroundSlider").GetComponent<Slider>();
        soundFxVolume = GameObject.FindWithTag("SoundFxSlider").GetComponent<Slider>();
        
    }

    public void changeMusicVolume() {
        musica.volume = musicVolume.value/100f;
    }

    public void changeSoundFx(){
        foreach(AudioSource som in sons) {
            som.volume = soundFxVolume.value/100f;
        }
    }
}
