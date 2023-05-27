using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    [HideInInspector]public PlayerPlatform player;
    [HideInInspector]public PlatformsLogic platLogic;
    [HideInInspector]public int score = 0;
    [HideInInspector]public int bonusScore = 4;
    [HideInInspector]public Object explosion;
    public AudioSource audioBonus;
    public Text points;
    private Rigidbody2D rb;
    private Vector2 direction = new Vector2(1f, 1f);
    
    public float speed = 3;
    private float speedBonus = 4.5f;
    private float currentSpeed;
    private float durationEffect = 5f;
    private float timerForSlow = 0f;
    private float timerForSpeed = 0f;
    private bool isSpeedBonus = false;
    private bool isSlow = false;
    public static bool isPause = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        explosion = Resources.Load("Particle");
        GameObject playerPlatform = GameObject.Find("PlayerPlatform");
        player = playerPlatform.GetComponent<PlayerPlatform>();
    }
    void Update()
    {
        if (isPause)
        {
            PauseBall(1f);
        }
        if (timerForSpeed > durationEffect)
        {
            isSpeedBonus = false;
            timerForSpeed = 0f;
        }
        if (!isSpeedBonus)
        { 
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else if (isSpeedBonus && timerForSpeed < durationEffect)
        {
            timerForSpeed += Time.deltaTime;
            transform.Translate(direction * speedBonus * Time.deltaTime);
        }
        
        if (isSlow)
        {
            timerForSlow += Time.deltaTime;
            if (timerForSlow >= durationEffect)
            {
                ReturnToNormalTime();
            }
        }
    }

    void PauseBall(float value)
    {
        rb.Sleep();
        Invoke("ResumePauseBall",value);
    }

    void ResumePauseBall()
    {
        isPause = false;
        rb.WakeUp();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "SideWall")
        {
            direction.x = -direction.x;
        }

        if (col.gameObject.tag == "TopWall")
        {
            direction.y = -direction.y;
        }
        
        if (col.gameObject.tag == "Player")
        {
            direction.y = -direction.y;
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }

        if (col.gameObject.tag == "Platform")
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            direction.y = -direction.y;
            Destroy(col.gameObject);
            int randomNumber = Random.Range(0, 100);
            int randomIndex = Random.Range(0, 3);
            if (randomNumber < 99 && randomIndex == 0)
            {
                SlowTime();
            }
            else if (randomNumber < 12 && randomIndex == 1)
            {
                SpeedUpBall();
            }
            else if(randomNumber < 12 && randomIndex == 2)
            {
                player.IncreaseInSize();
                GameObject explosionRef = (GameObject)Instantiate(explosion);
                explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y);
                score += bonusScore;
                Destroy(explosionRef,2f);

            }
            score++;
            points.text = "" + score;
        }
        
    }
    void SlowTime()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y);
        audioBonus.Play();
        isSlow = true;
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        score += bonusScore;
        Destroy(explosionRef,2f);
    }
    private void ReturnToNormalTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f; 
        isSlow = false;
        timerForSlow = 0f;
    }
    void SpeedUpBall()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y);
        audioBonus.Play(); 
        isSpeedBonus = true;
        score += bonusScore;
        Destroy(explosionRef,2f);
    }
}
