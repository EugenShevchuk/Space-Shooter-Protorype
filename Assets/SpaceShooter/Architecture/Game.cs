using System.Collections;
using SpaceShooter.Tools;
using System;

namespace SpaceShooter.Architecture {
    public static class Game
    {
        public static SceneManagerBase SceneManager { get; private set; }
                
        public static event Action GameInitializedEvent;

        public static void Run()
        {
            SceneManager = new SceneManagerRealization();
            Coroutines.StartRoutine(InitializeGameRoutine());           
        }

        private static IEnumerator InitializeGameRoutine()
        {
            SceneManager.InitializeScenesMap();
            yield return SceneManager.LoadCurrentSceneAsync();
            GameInitializedEvent?.Invoke();
        }

        public static T GetRepository<T>() where T : Repository
        {
            return SceneManager.GetRepository<T>();
        }

        public static T GetInteractor<T>() where T : Interactor
        {
            return SceneManager.GerInteractor<T>();
        }
    }
}