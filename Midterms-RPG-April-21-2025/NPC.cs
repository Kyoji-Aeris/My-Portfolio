using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField]
    List<string> dialogues = new();

    int currentIndex;

    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel, continueButton, exitButton;

    void Start()
    {
        foreach (var dialogue in dialogues)
        {
            Debug.Log(dialogue);
        }
    }
    public void Talk()
    {
        Time.timeScale = 0f;
        dialoguePanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        currentIndex = 0;
        NextLine();
    }
    public void NextLine()
    {
        if (currentIndex < dialogues.Count - 1)
        {
            dialogueText.text = dialogues[currentIndex];
            exitButton.SetActive(false);
            continueButton.SetActive(true);
            Debug.Log(currentIndex);
            currentIndex += 1;
        }
        else
        {
            dialogueText.text = dialogues[dialogues.Count - 1];
            continueButton.SetActive(false);
            exitButton.SetActive(true);
            Button button = exitButton.GetComponent<Button>();
            button.onClick.AddListener(() => { dialoguePanel.SetActive(false); Cursor.lockState = CursorLockMode.Locked; Time.timeScale = 1f; currentIndex = 0; });
        }
    }
}
