using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;  

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public AudioSource clip;

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }
}
