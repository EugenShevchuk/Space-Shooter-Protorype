using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private float roll = 20f;
        [SerializeField] private float pitch = 15f;

        private PlayerStatsInteractor statsInteractor;

        private void OnEnable()
        {
            SceneManagerBase.OnSceneInitializedEvent += OnSceneInitialized;
        }

        private void OnSceneInitialized()
        {
            this.statsInteractor = Game.GetInteractor<PlayerStatsInteractor>();
        }

        private void Update()
        {
            this.PlayerMove();
        }

        public void PlayerMove()
        {
            if (this.statsInteractor != null)
            {
                float xAxis = PlayerInputListener.instance.Horizontal;
                float yAxis = PlayerInputListener.instance.Vertical;

                Vector3 position = this.transform.position;

                position.x += xAxis * this.statsInteractor.Speed * Time.deltaTime;
                position.y += yAxis * this.statsInteractor.Speed * Time.deltaTime;

                this.transform.position = position;

                this.transform.rotation = Quaternion.Euler(-90 + (yAxis * pitch), xAxis * roll, 0);
            }
        }
    }
}