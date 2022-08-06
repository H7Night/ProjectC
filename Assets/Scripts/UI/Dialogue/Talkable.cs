using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [SerializeField] private bool isEntered;
    [SerializeField] public bool hasName;
    public GameObject talkButton;//用来提示玩家可以对话的UI交互
     [TextArea(1, 6)] public string[] lines;
    void Start()
    {
        talkButton.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isEntered = true;
            talkButton.SetActive(true);
            DialogSystem.instance.talkable = this;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isEntered = false;
            talkButton.SetActive(false);
            DialogSystem.instance.talkable = null;
        }
    }
    private void Update()
    {
        if (isEntered && Input.GetKeyDown(KeyCode.R) && DialogSystem.instance.dialougueBox.activeInHierarchy == false)
        {
            DialogSystem.instance.ShowDialogue(lines, hasName);
            FindObjectOfType<DialogSystem>().dialougueBox.SetActive(true);
        }
    }

}
