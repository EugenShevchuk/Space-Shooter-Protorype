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
            this.objectPool = GetComponent<ProjectileObjectPool>();

            if (this.playerPrefab != null)
            {
                this.player = Instantiate(this.playerPrefab);                

                MeshRenderer[] childRenderers = this.player.GetComponentsInChildren<MeshRenderer>();
                for (int i = 0; i < childRenderers.Length; i++)                
                    childRenderers[i].material = this.playerMaterial;
            }
            else
            {
                this.player = Instantiate(this.defaultPrefab);                
            }

            this.player.GetComponent<PlayerBehaviour>().enabled = true;
            this.player.GetComponent<CollisionHandler>().enabled = true;

            this.player.layer = LayerMask.NameToLayer("Player");
        }

        private void InitializePlayer()
        {
            var weaponSystem = this.player.GetComponent<WeaponsSystem>();
            weaponSystem.objectPool = this.objectPool;
            weaponSystem.enabled = true;
            weaponSystem.OpenFire();
        }
    }
}