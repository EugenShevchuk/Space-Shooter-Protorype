using UnityEngine;

public enum ObjectType 
{
    Weapon,
    Stats,
    Bonus,
}

public abstract class BaseObject : ScriptableObject
{
    public ObjectType Type;
}
