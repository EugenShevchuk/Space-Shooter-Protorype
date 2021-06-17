using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShooter
{
    public sealed class PlayerInputListener : MonoBehaviour
    {
        #region Singleton
        public static PlayerInputListener instance => GetInstance();
        private static PlayerInputListener m_instance;
        private static bool isInitialized => m_instance != null;

        private const string NAME = "[INPUT LISTENER]";

        private static PlayerInputListener GetInstance()
        {
            if (isInitialized == false)
                m_instance = CreateSingleton();
            return m_instance;
        }

        private static PlayerInputListener CreateSingleton()
        {
            PlayerInputListener createdManager = new GameObject(NAME).AddComponent<PlayerInputListener>();
            //createdManager.hideFlags = HideFlags.HideAndDontSave;
            DontDestroyOnLoad(createdManager.gameObject);
            return createdManager;
        }
        #endregion

        public event Action<Vector2> ScreenTouchedEvent;
        
        private GameControlls gameControlls;

        private void Awake()
        {
            this.gameControlls = new GameControlls();            
        }

        private void OnEnable()
        {
            this.gameControlls.Enable();

            this.gameControlls.Gameplay.Move.performed += ctx => ScreenTouched(ctx);
        }

        private void OnDisable()
        {
            this.gameControlls.Gameplay.Move.performed -= ctx => ScreenTouched(ctx);

            this.gameControlls.Disable();            
        }

        private void ScreenTouched(InputAction.CallbackContext context)
        {
            var position = context.ReadValue<Vector2>();
                        
            Debug.Log($"Touch position - {position}");
            
            ScreenTouchedEvent?.Invoke(position);
        }
    }
}