using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private PlayerEngineInteractor engineInteractor;

        private Camera mainCamera;

        private void OnEnable()
        {            
            SceneManagerBase.OnSceneInitializedEvent += OnSceneInitialized;
            mainCamera = Camera.main;
        }

        private void OnDisable()
        {
            SceneManagerBase.OnSceneInitializedEvent -= OnSceneInitialized;
            PlayerInputListener.instance.ScreenTouchedEvent -= Move;
        }

        private void OnSceneInitialized()
        {
            this.engineInteractor = Game.GetInteractor<PlayerEngineInteractor>();
            PlayerInputListener.instance.ScreenTouchedEvent += Move;
        }

        private void Move(Vector2 touchPosition)
        {
            Vector3 screenPosition = new Vector3(touchPosition.x, touchPosition.y, mainCamera.nearClipPlane);
            Vector3 targetPosition = mainCamera.ScreenToWorldPoint(screenPosition);
            targetPosition.z = 0;

            var currentPosition = this.transform.position;
            var step = 10 * Time.deltaTime;

            this.transform.position = Vector3.Lerp(currentPosition, targetPosition, step);
        }
    }
}