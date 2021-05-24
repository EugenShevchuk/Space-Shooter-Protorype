using UnityEngine;
using SpaceShooter.Architecture;
using System;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float roll = 20f;
    [SerializeField] private float pitch = 15f;

    private PlayerStatsInteractor statsInteractor;
    private WeaponsInteractor weaponsInteractor;
        
    private void OnEnable()
    {
        SceneManagerBase.OnSceneInitializedEvent += OnSceneInitialized;        
    }

    private void OnSceneInitialized()
    {
        statsInteractor = Game.GetInteractor<PlayerStatsInteractor>();
        weaponsInteractor = Game.GetInteractor<WeaponsInteractor>();
        weaponsInteractor.OpenFire();
    }
    
    private void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        if (statsInteractor != null)
        {
            float xAxis = PlayerInputListener.instance.Horizontal;
            float yAxis = PlayerInputListener.instance.Vertical;

            Vector3 position = transform.position;

            position.x += xAxis * statsInteractor.Speed * Time.deltaTime;
            position.y += yAxis * statsInteractor.Speed * Time.deltaTime;

            transform.position = position;

            transform.rotation = Quaternion.Euler(-90 + (yAxis * pitch), xAxis * roll, 0);
        }
    }
}
