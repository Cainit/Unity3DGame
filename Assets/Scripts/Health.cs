using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float health = 10f;
    [SerializeField]
    float healthMax = 10f;
    [SerializeField]
    Texture2D healthbarTexture;

    void Awake()
    {
        Color[] pix = new Color[2 * 2];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = Color.red;
        }
        healthbarTexture = new Texture2D(1, 1);
        healthbarTexture.SetPixel(0,0, Color.red);
        healthbarTexture.Apply();
    }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }

    public float GetHealth() { return health; }
    public float GetMax() { return healthMax;  }

    void OnGUI()
    {
        float healtBarSize = health / healthMax * 100f;

        GUI.Box(new Rect(10, 10, 100, 20), "");

        var background = GUI.skin.box.normal.background;
        GUI.skin.box.normal.background = Texture2D.whiteTexture;
        GUI.backgroundColor = Color.red;
        GUI.color = Color.red;
        GUI.Box(new Rect(10, 10, healtBarSize, 20), "");

        GUI.skin.box.normal.background = background;


        //GUI.Box(new Rect(10, 10, 100, 20), "HealthBar");
    }
}
