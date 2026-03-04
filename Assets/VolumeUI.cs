using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
   public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeSlider.value = savedVolume;

        volumeSlider.onValueChanged.AddListener(delegate
        {
            AudioManager.Instance.SetVolume(volumeSlider.value);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
