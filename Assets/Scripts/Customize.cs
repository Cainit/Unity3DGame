using UnityEngine;

public class Customize : MonoBehaviour
{
    public Color myColor;

    Material materialChar;
    Health playerHealth;

    void Awake()
    {
        materialChar = GetComponentInChildren<SkinnedMeshRenderer>().material;
        playerHealth = GetComponent<Health>();
    }

    void OnGUI()
    {
        myColor = RGBSlider(new Rect(10, 60, 100, 20), myColor);

        materialChar.color = myColor;

        playerHealth.SetHealth(HealthSlider(new Rect(10, 40, 100, 20), playerHealth.GetHealth()));
    }


    float HealthSlider(Rect screenRect, float health)
    {
        return LabelSlider(screenRect, health, playerHealth.GetMax(), "Health");
    }

    Color RGBSlider(Rect screenRect, Color rgb)
    {
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Color Red");
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Color Green");
        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Color Blue");
        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "Color Alpha");
        return rgb;
    }

    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, 0.0f,
        sliderMaxValue);
        return sliderValue;
    }
}
