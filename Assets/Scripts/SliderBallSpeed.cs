using UnityEngine;
using UnityEngine.UI;

public class SliderBallSpeed : MonoBehaviour
{
    public Ball ball;
    public Slider slider;
    public Text text;

    void Start()
    {
        slider.value = ball.speed;
        slider.onValueChanged.AddListener(SliderBallSpped);
    }

    public void SliderBallSpped(float value)
    {
        text.text = "BALL SPEED: " + slider.value.ToString();
        ball.speed = slider.value;
    }
}    
