using UnityEngine;

[ExecuteAlways]
public class DayNight : MonoBehaviour
{
    [SerializeField]
    private Light directionLight;
    [SerializeField]
    private EnvLightPreset lightPreset;

    [SerializeField, Range(0, 24)]
    private float dayTime;

    [SerializeField, Range(0, 1)]
    private float dayTimeSpeed;

    private void OnValidate()
    {
        if (directionLight != null)
            return;

        directionLight = RenderSettings.sun;
    }

    void Update()
    {
        if (lightPreset == null)
            return;

        if(Application.isPlaying)
        {
            dayTime += Time.deltaTime * dayTimeSpeed;
            dayTime %= 24;
        }
        UpdateLight(dayTime / 24f);
    }

    private void UpdateLight(float time)
    {
        RenderSettings.ambientLight = lightPreset.AmbientColor.Evaluate(time);
        RenderSettings.fogColor = lightPreset.FogColor.Evaluate(time);
        if(directionLight != null)
        {
            directionLight.color = lightPreset.DirectionColor.Evaluate(time);
            directionLight.transform.localRotation = Quaternion.Euler(new Vector3((time * 360f) - 90f, 90f, 10f));
        }
    }
}
