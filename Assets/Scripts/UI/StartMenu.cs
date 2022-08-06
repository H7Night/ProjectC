using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class StartMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    //进入游戏
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    //退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Setting()
    {
        GameObject.Find("Canvas/MainMenu/UI/Set").SetActive(true);
    }
    public void BackToMenu()
    {
        GameObject.Find("Canvas/MainMenu/UI/Set").SetActive(false);
    }
    //调节音量
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    }
}
