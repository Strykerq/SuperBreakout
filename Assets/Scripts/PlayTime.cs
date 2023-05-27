using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour
{
    public Text playTime;
    public static int hours;
    public static  int minutes;
    public static  int seconds;
    private float gameTime;
    public static string currentTime;

    void Update()
    {
        gameTime = Time.time; 
        hours = Mathf.FloorToInt(gameTime / 3600);
        minutes = Mathf.FloorToInt((gameTime % 3600) / 60); 
        seconds = Mathf.FloorToInt(gameTime % 60); 
        currentTime = string.Format("{0:D2}.{1:D2}.{2:D2}", hours, minutes, seconds);
        playTime.text = currentTime;
    }
}
