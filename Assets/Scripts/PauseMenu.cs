using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector] public Ball ball;
    private bool GameOnPause = false;
    public static bool isRestart = false;
    public GameObject pauseMenu;

    private void Start()
    {
        GameObject ballObject = GameObject.Find("Ball");
        ball = ballObject.GetComponent<Ball>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameOnPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameOnPause = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameOnPause = true;
    }

    public void Restart()
    {
        ball.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void QuitToMainMenu()
    {
        isRestart = true;
        SceneManager.LoadScene(0);
        SliderController.isMainMenu = true;
    }
}
