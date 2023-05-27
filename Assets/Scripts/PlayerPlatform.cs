using UnityEngine;
using UnityEngine.UI;

public class PlayerPlatform : MonoBehaviour
{
    public float PlayerSpeed = 5;
    private float increaseScale = 2f;

    public Ball ball;

    void Start()
    {
        GameObject Ball = GameObject.Find("Ball");
        ball = Ball.GetComponent<Ball>();
        

    }
    
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * PlayerSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * PlayerSpeed * Time.deltaTime);
        }
    }

    public void IncreaseInSize()
    {
        
        ball.audioBonus.Play();
        Vector2 currentScale = transform.localScale;
        currentScale.x *= increaseScale;
        transform.localScale = currentScale;
        Invoke("ReturnToNormalSize", 5f);
        
    }
    
    public void ReturnToNormalSize()
    {
        Vector2 currentScale = transform.localScale;
        currentScale.x /= increaseScale;
        transform.localScale = currentScale;
    }
    
   
}
