using System.Collections;
using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class GameSceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject defaultPrefab;
        [SerializeField] private GameObject shield;

        private GameObject playerPrefab = UICosmeticMenu.ChosenPrefab;
        private Material playerMaterial = UICosmeticMenu.ChosenMaterial;

        private GameObject player;

        private ProjectileObjectPool objectPool;

        private void Awake()
        {
            objectPool = GetComponent<ProjectileObjectPool>();
        }

        private void OnEnable()
        {
            SceneManagerBase.OnSceneInitializedEvent += InitializePlayer;
        }

        private void OnDisable()
        {
            SceneManagerBase.OnSceneInitializedEvent -= InitializePlayer;
        }

        private void Start()
        {
            InstantiatePlayer();
        }

        private void InstantiatePlayer()
        {
            if (playerPrefab != null)
            {
                player = Instantiate(playerPrefab);                

                MeshRenderer[] childRenderers = player.GetComponentsInChildren<MeshRenderer>();
                for (int i = 0; i < childRenderers.Length; i++)                
                    childRenderers[i].material = playerMaterial;                
            }
            else
            {
                player = Instantiate(defaultPrefab);
            }

            player.GetComponent<PlayerBehaviour>().enabled = true;
            player.GetComponent<PlayerCollisionHandler>().enabled = true;
            player.layer = LayerMask.NameToLayer("Player");
        }

        private void InitializePlayer()
        {
            var weaponSystem = player.GetComponent<WeaponsSystem>();
            weaponSystem.objectPool = this.objectPool;
            weaponSystem.enabled = true;
            weaponSystem.OpenFire();
        }
    }
}