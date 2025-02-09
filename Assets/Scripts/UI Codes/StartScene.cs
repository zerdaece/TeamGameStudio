using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public Slider soundSlider;
    public GameObject Options;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        soundSlider.value = AudioListener.volume;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnOptionsClicked()
    {
        if(Options.activeSelf)
        {
            Options.SetActive(false);
        }
        else
        {
            Options.SetActive(true);
        }

    }
    public void SoundSlider()
    {
        AudioListener.volume = soundSlider.value;
    }
}
