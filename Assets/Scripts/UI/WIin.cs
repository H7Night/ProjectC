using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WIin : MonoBehaviour
{
    //public GameObject WinUI;
    public void ReStart()
    {
        GameObject.Find("Canvas/WinUI").SetActive(false);
        SceneManager.LoadScene("One");
    }
    public void BackToMenu()
    {
        GameObject.Find("Canvas/WinUI").SetActive(false);
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            //WinUI.SetActive(true);
            GameObject.Find("Canvas/WinUI").SetActive(true);
            PlayerController.instance.canMove = false;
        }
    }
}
