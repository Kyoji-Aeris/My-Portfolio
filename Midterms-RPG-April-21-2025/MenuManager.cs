using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject pausePanel;
    

    public void TogglePausePanel()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        pausePanel.SetActive(true);
    }

    public void ToggleUnpausePanel()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        pausePanel.SetActive(false);
    }

    public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
    void Update()
    {
        Scene activeScene = SceneManager.GetActiveScene();
         if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf == false && menuPanel.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.None;
            TogglePausePanel();
        }
         else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0f && menuPanel.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            ToggleUnpausePanel();
        }
         else if (menuPanel.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
