using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/Stats/PlayerStats")]
public class PlayerStatsObject : StatsObject
{
    [SerializeField] private float maxHealthValue = 10f;
    public float MaxHealthValue
    {
        get { return maxHealthValue; }
        set { maxHealthValue = value; }
    }
    public int HealthLvl = 0;

    [SerializeField] private float maxShieldValue = 10f;
    public float MaxShieldValue
    {
        get { return maxShieldValue; }
        set { maxShieldValue = value; }
    }
    public int ShieldLvl = 0;

    [SerializeField] private float baseSpeed = 20f;
    public float Speed
    {
        get { return baseSpeed; }
        set { baseSpeed = value; }
    }
    public int SpeedLvl = 0;

    private void Awake()
    {
        StatsType = StatsType.Player;
    }    
}
