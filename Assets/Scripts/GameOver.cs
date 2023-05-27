using UnityEngine.SceneManagement;
using UnityEngine;
public class GameOver : MonoBehaviour
{
  public GameObject gameOverMenu;
  [HideInInspector] public Ball ball;
  
  private void Start()
  {
    GameObject ballObject = GameObject.Find("Ball");
    ball = ballObject.GetComponent<Ball>();
  }
  private void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.tag == "Finish")
    {
      EndGame();
    }
  }

  void EndGame()
  {
    gameOverMenu.SetActive(true);
    Time.timeScale = 0f;
  }
  
  public void Restart2()
  {
    ball.score = 0;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1f;
  }
}
