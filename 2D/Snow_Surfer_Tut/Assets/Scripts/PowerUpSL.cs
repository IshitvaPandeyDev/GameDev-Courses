using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpObj", menuName = "PowerUpSL")]
public class PowerUpSL : ScriptableObject
{
    [SerializeField] string PowerUpType;
    [SerializeField] float ValueChange;
    [SerializeField] float Time;
    public string GetPowerUpType()
    {
        return PowerUpType;
    }
    public float GetValueChange()
    {
        return ValueChange;
    }
    public float GetTime()
    {
        return Time;
    }
}
