using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem instance;//單例模式
    public GameObject dialougueBox; //顯示或隱藏
    public Text dialogueText, nameText;
    public Talkable talkable;
    [SerializeField] private int currentLine;
    [SerializeField] private float textSpeed;
    [TextArea(1, 3)]
    public string[] dialogueLines;
    private bool isScrolling;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        dialougueBox.SetActive(false);
        dialogueText.text = dialogueLines[currentLine];
    }
       private void Update()
    {
        if(dialougueBox.activeInHierarchy)//檢測對話窗口是否可見
        {
            if(Input.GetKeyUp(KeyCode.R))
            {
                if(isScrolling == false)
                {

                    currentLine++;
                    if(currentLine <dialogueLines.Length)
                    {
                        CheckName();
                        StartCoroutine(ScrollingText());
                    }
                    else
                    {
                        dialougueBox.SetActive(false);
                        FindObjectOfType<PlayerController>().canMove = true;
                    }
                }
            }

        }
    }
    public void ShowDialogue(string[] _newLines, bool _hasName)
    {
        dialogueLines = _newLines;
        currentLine = 0;

        CheckName();

        dialogueText.text = dialogueLines[currentLine];
        StartCoroutine(ScrollingText());

        nameText.gameObject.SetActive(_hasName);

        FindObjectOfType<PlayerController>().canMove = false;
    }
    private void CheckName()
    {
        if(dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-","");//replace替換用法用new(2),替換lod(1)
            currentLine++;
        }
    }
    private IEnumerator ScrollingText()
    {
        isScrolling = true;
        dialogueText.text = "";
        foreach(char letter in dialogueLines[currentLine].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        isScrolling = false;
    }
}
