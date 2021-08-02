using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private List<GameObject> buttons;
    private bool isGamePaused;

    private void Update()
    {
        EscapePause();
    }

    public void EnterPause()
    {
        isGamePaused = true;
        Time.timeScale = 0;

        pausePanel.SetActive(true);
        ManageButtons();
    }

    public void ExitPause()
    {
        isGamePaused = false;
        Time.timeScale = 1;

        pausePanel.SetActive(false);
        ManageButtons();
    }

    private void ManageButtons()
    {       
        for (int i = 0; i < buttons.Count; i++)
        {
            if (isGamePaused)
            {
                buttons[i].SetActive(false);
            }
            else if (!isGamePaused)
            {
                buttons[i].SetActive(true);
            }
        }       
    }

    private void EscapePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                EnterPause();
            }
            else if (isGamePaused)
            {
                ExitPause();
            }
        }
    }
}
