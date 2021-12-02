using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (volumeSlider != null)
        {
            AudioListener.volume = volumeSlider.value;
            Save();
        }
        else
        {
            AudioListener.volume = 0.5f;
        }            
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
