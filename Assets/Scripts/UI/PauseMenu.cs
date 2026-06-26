using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    void Update() { if (Input.GetKeyDown(KeyCode.Escape)) Toggle(); }

    public void Toggle()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void Resume() => Toggle();
    public void Quit() => Application.Quit();
}
