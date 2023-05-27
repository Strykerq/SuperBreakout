using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public PlayerPlatform playerPlatform;
    public Text SliderText;
    public static bool isMainMenu = true;

    private void Start()
    {
        slider.value = playerPlatform.PlayerSpeed;
        slider.onValueChanged.AddListener(SliderPlayerSpeed);
    }
    public void SliderPlayerSpeed(float value)
    {
        if (isMainMenu)
        {
            SliderText.text = "PLAYER SPEED: " + slider.value.ToString();
            playerPlatform.PlayerSpeed = slider.value;
        }
    }
}
