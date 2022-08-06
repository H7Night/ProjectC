using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public GameObject setting;
    public GameObject resume;
    public GameObject setting_volume;
    public GameObject return_setting;

    public AudioMixer audioMixer;

    void Start()
    {
        setting.SetActive(false);
        setting_volume.SetActive(false);
    }
    #region 通用设置
    //按设置
    public void Setting()
    {
        setting.SetActive(true);
        Time.timeScale = 0f;
    }
    //音量设置
    public void Setting_Volume()
    {
        setting.SetActive(false);
        setting_volume.SetActive(true);
    }
    //返回
    public void Return()
    {
        setting.SetActive(false);
        Time.timeScale = 1f;
    }
    //退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }
    //调节音量
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    }
    //返回设置
    public void ReturnSetting()
    {
        setting_volume.SetActive(false);
        setting.SetActive(true);
    }
    #endregion
    

}
