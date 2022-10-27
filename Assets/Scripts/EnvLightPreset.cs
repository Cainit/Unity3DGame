using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="EnvLightPreset", menuName ="Scriptable/EvvLightPreset", order =-1)]
public class EnvLightPreset : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionColor;
    public Gradient FogColor;
}
