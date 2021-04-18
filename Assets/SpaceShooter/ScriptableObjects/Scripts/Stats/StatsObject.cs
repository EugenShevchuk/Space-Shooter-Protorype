using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsType
{ 
    Player,
    Enemy
}

public class StatsObject : BaseObject
{
    public StatsType StatsType;
    private void Awake()
    {
        Type = ObjectType.Stats;
    }
}
