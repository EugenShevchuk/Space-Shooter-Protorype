using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/Stats/PlayerStats")]
public class PlayerStatsObject : StatsObject
{
    [SerializeField] private int maxHealthValue = 10;
    public int MaxHealthValue
    {
        get { return maxHealthValue; }
        set { maxHealthValue = value; }
    }
    public int HealthLvl = 0;

    [SerializeField] private int maxShieldValue = 10;
    public int MaxShieldValue
    {
        get { return maxShieldValue; }
        set { maxShieldValue = value; }
    }
    public int ShieldLvl = 0;

    [SerializeField] private int baseSpeed = 20;
    public int Speed
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
