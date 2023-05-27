using UnityEngine;
using UnityEngine.UI;

public class SliderBonusPoints : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public Ball ball;
    void Start()
    {
        slider.value = ball.bonusScore;
        slider.onValueChanged.AddListener(SliderBonusScore);
    }

    public void SliderBonusScore(float value)
    {
        text.text = "BONUS SCORE POINTS: " + slider.value.ToString();
        ball.bonusScore = (int)slider.value;
    }

   
}
