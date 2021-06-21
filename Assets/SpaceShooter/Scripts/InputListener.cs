using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShooter
{
    public sealed class InputListener : MonoBehaviour
    {
        #region Singleton
        public static InputListener instance => GetInstance();
        private static InputListener m_instance;
        private static bool isInitialized => m_instance != null;

        private const string NAME = "[INPUT LISTENER]";

        private static InputListener GetInstance()
        {
            if (isInitialized == false)
                m_instance = CreateSingleton();
            return m_instance;
        }

        private static InputListener CreateSingleton()
        {
            InputListener createdManager = new GameObject(NAME).AddComponent<InputListener>();
            //createdManager.hideFlags = HideFlags.HideAndDontSave;
            DontDestroyOnLoad(createdManager.gameObject);
            return createdManager;
        }
        #endregion

        public event Action<Vector2> TouchStartedEvent;
        public event Action TouchEndedEvent;
        
        private GameControlls gameControlls;

        private void Awake()
        {
            this.gameControlls = new GameControlls();            
        }

        private void OnEnable()
        {
            this.gameControlls.Enable();

            this.gameControlls.Gameplay.Move.performed += ctx => TouchStarted(ctx);
            this.gameControlls.Gameplay.Move.canceled += ctx => TouchEnded();
        }

        private void OnDisable()
        {
            this.gameControlls.Gameplay.Move.performed -= ctx => TouchStarted(ctx);
            this.gameControlls.Gameplay.Move.canceled -= ctx => TouchEnded();

            this.gameControlls.Disable();            
        }

        private void TouchStarted(InputAction.CallbackContext context)
        {
            var position = context.ReadValue<Vector2>();
                        
            Debug.Log($"Touch position - {position}");
            
            TouchStartedEvent?.Invoke(position);
        }

        private void TouchEnded()
        {
            TouchEndedEvent?.Invoke();
        }
    }
}