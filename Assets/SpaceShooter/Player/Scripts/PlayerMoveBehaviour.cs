using UnityEngine;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class PlayerMoveBehaviour : MonoBehaviour
    {
        private PlayerEngineInteractor engineInteractor;
        private InputListener inputListener;

        private Camera mainCamera;

        private bool isMoving;
        private Vector3 targetPosition;

        private void OnEnable()
        {            
            SceneManagerBase.OnSceneInitializedEvent += OnSceneInitialized;
            this.mainCamera = Camera.main;
            this.inputListener = InputListener.instance;
        }

        private void OnDisable()
        {
            SceneManagerBase.OnSceneInitializedEvent -= OnSceneInitialized;
            this.inputListener.TouchStartedEvent -= StartMovement;
            this.inputListener.TouchEndedEvent -= StopMovement;
        }

        private void OnSceneInitialized()
        {
            this.engineInteractor = Game.GetInteractor<PlayerEngineInteractor>();
            this.inputListener.TouchStartedEvent += StartMovement;
            this.inputListener.TouchEndedEvent -= StopMovement;
        }

        private void Update()
        {
            if (isMoving == true)
                Move();
        }

        private void StartMovement(Vector2 touchPosition)
        {
            Vector3 screenPosition = new Vector3(touchPosition.x, touchPosition.y, this.mainCamera.nearClipPlane);
            this.targetPosition = this.mainCamera.ScreenToWorldPoint(screenPosition);
            this.targetPosition.z = 0;
            this.isMoving = true;
        }

        private void StopMovement()
        {
            this.isMoving = false;
        }

        private void Move()
        {
            var currentPosition = this.transform.position;
            var step = this.engineInteractor.Speed * Time.deltaTime;

            this.transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step);
        }
    }
}