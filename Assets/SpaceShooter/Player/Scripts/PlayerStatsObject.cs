using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/Stats/PlayerStats")]
public class PlayerStatsObject : ScriptableObject
{
    [Header("Base Stats")]
    public float BaseHealthValue = 10;    
    public float BaseShieldValue = 10;  
    public float BaseSpeedValue = 25;

    [Header("Health Bonuses For Ugrading")]
    public float healthBonusLevel1_5 = 2;    
    public float healthBonusLevel5_10 = 3;
    
    [Header("Shield Bonuses For Upgrading")]
    public float shieldBonusLevel1_5 = 1;
    public float shieldBonusLevel5_10 = 3;

    [Header("Speed Bonuses For Upgrading")]
    public float speedBonusLevel1_5 = 1;
    public float speedBonusLevel5_10 = 3;
}
