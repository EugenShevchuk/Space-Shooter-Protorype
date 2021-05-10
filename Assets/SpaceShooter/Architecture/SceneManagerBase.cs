using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SpaceShooter.Tools;

namespace SpaceShooter.Architecture
{
    public abstract class SceneManagerBase
    {
        public event Action<Scene> OnSceneLoadedEvent;
        public event Action<Scene> OnSceneStartLoadEvent;

        public static event Action OnSceneInitializedEvent;

        public Scene Scene { get; private set; }
        public bool IsLoading { get; private set; }

        public Dictionary<string, SceneConfig> sceneConfigMap;

        public SceneManagerBase()
        {
            sceneConfigMap = new Dictionary<string, SceneConfig>();
            InitializeScenesMap();
        }

        public abstract void InitializeScenesMap();

        public Coroutine LoadCurrentSceneAsync()
        {
            if (IsLoading)
                throw new Exception("Scene is loading already");

            LoadingScreen.Show();
                        
            var sceneName = SceneManager.GetActiveScene().name;

            var config = sceneConfigMap[sceneName];
            if (config == null)
                throw new Exception("There is no config for this scene");

            return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));            
        }

        private IEnumerator LoadCurrentSceneRoutine(SceneConfig config)
        {
            IsLoading = true;
            OnSceneStartLoadEvent?.Invoke(Scene);

            yield return Coroutines.StartRoutine(InitializeSceneRoutine(config));
                        
            IsLoading = false;
            OnSceneLoadedEvent?.Invoke(Scene);
            LoadingScreen.Hide();
        }

        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if (IsLoading)
                throw new Exception("Scene is loading already");

            var config = sceneConfigMap[sceneName];
            if (config == null)
                throw new Exception("There is no config for this scene");

            return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig config)
        {
            IsLoading = true;
            OnSceneStartLoadEvent?.Invoke(Scene);
                        
            yield return Coroutines.StartRoutine(LoadSceneRoutine(config));            
            yield return Coroutines.StartRoutine(InitializeSceneRoutine(config));
            
            IsLoading = false;
            OnSceneLoadedEvent?.Invoke(Scene);
        }

        private IEnumerator LoadSceneRoutine(SceneConfig config)
        {
            LoadingScreen.Show();
            var loadAsync = SceneManager.LoadSceneAsync(config.SceneName);
            loadAsync.allowSceneActivation = false;

            while (loadAsync.progress < 0.9f)            
                yield return null;
                        
            loadAsync.allowSceneActivation = true;
            LoadingScreen.Hide();
        }

        private IEnumerator InitializeSceneRoutine(SceneConfig config)
        {
            Scene = new Scene(config);
            yield return Scene.InitializeRoutine();
            OnSceneInitializedEvent?.Invoke();
        }

        public T GetRepository<T>() where T : Repository
        {
            return Scene.GetRepository<T>();
        }

        public T GerInteractor<T>() where T : Interactor
        {
            return Scene.GetInteractor<T>();
        }
    }
}