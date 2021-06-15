using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private float roll = 20f;
        [SerializeField] private float pitch = 15f;

        private PlayerEngineInteractor engineInteractor;

        private void OnEnable()
        {
            SceneManagerBase.OnSceneInitializedEvent += OnSceneInitialized;
        }

        private void OnDisable()
        {
            SceneManagerBase.OnSceneInitializedEvent -= OnSceneInitialized;
        }

        private void OnSceneInitialized()
        {
            this.engineInteractor = Game.GetInteractor<PlayerEngineInteractor>();
        }

        private void Update()
        {
            if (this.engineInteractor != null)
                this.PlayerMove();
        }

        private void PlayerMove()
        {
            float xAxis = PlayerInputListener.instance.Horizontal;
            float yAxis = PlayerInputListener.instance.Vertical;

            Vector3 position = this.transform.position;

            position.x += xAxis * this.engineInteractor.Speed * Time.deltaTime;
            position.y += yAxis * this.engineInteractor.Speed * Time.deltaTime;

            this.transform.position = position;

            this.transform.rotation = Quaternion.Euler(-90 + (yAxis * pitch), xAxis * roll, 0);
        }
    }
}