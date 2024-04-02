using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SettingMusicAndSound : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider musicSlider;
    [SerializeField] private UnityEngine.UI.Slider soundSlider;
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject deadMenu;
    [SerializeField] private GameManager GameManager;
    [SerializeField] private AudioMixer audioMixer;
    private RunAudio audio;
    private void Start()
    {
        Time.timeScale = 1f;
        musicSlider.value = GameManager.GetMusicVollum();
        soundSlider.value = GameManager.GetSoundVollum();
        audio = RunAudio.instance;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OnMenuPause()
    {
        if (pauseMenu==null)
        {
            return;
        }
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void OffMenuPause()
    {
        if (pauseMenu == null)
        {
            return;
        }
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void OnMenuDead()
    {
        if (deadMenu == null)
        {
            return;
        }
        Time.timeScale = 0f;
        audio.PlaySound("Dead");
        deadMenu.SetActive(true);
    }
    public void OffMenuDead()
    {
        if (deadMenu==null)
        {
            return;
        }
        Time.timeScale = 1f;
        deadMenu.SetActive(false);
    }
    public void SetMusic()
    {
        GameManager.SetMusic(musicSlider.value);
        musicSlider.value = GameManager.GetMusicVollum();
        audioMixer.SetFloat("Music",musicSlider.value);
        Debug.Log(musicSlider.value);
    }
    public void SetSound()
    {
        GameManager.SetSound(soundSlider.value);
        soundSlider.value = GameManager.GetSoundVollum();
        audioMixer.SetFloat("Sound", soundSlider.value);
        Debug.Log(soundSlider.value);
    }
    public void OnSettingMenu()
    {
        settingMenu.SetActive(true);
    }
    public void OffSettingMenu()
    {
        settingMenu.SetActive(false);
    }
}
