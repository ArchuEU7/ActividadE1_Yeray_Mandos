using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager: MonoBehaviour

{
    private bool isPaused = false;
    [SerializeField] GameObject PaussaPanel;
    
    [SerializeField] GameObject PauseButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseButton.SetActive(false);
        PaussaPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
       
    }

    public void Resume()
    {
        PaussaPanel.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Quit()
    {
        Time.timeScale = 1f;

        Application.Quit();
    }
}
