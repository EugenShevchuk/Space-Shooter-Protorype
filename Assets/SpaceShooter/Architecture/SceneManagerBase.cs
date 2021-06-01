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
            this.sceneConfigMap = new Dictionary<string, SceneConfig>();
            this.InitializeScenesMap();
        }

        public abstract void InitializeScenesMap();

        public Coroutine LoadCurrentSceneAsync()
        {
            if (this.IsLoading)
                throw new Exception("Scene is loading already");

            LoadingScreen.Show();
                        
            var sceneName = SceneManager.GetActiveScene().name;

            var config = this.sceneConfigMap[sceneName];
            if (config == null)
                throw new Exception("There is no config for this scene");

            return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));            
        }

        private IEnumerator LoadCurrentSceneRoutine(SceneConfig config)
        {
            this.IsLoading = true;
            this.OnSceneStartLoadEvent?.Invoke(this.Scene);

            yield return Coroutines.StartRoutine(InitializeSceneRoutine(config));
                        
            this.IsLoading = false;
            this.OnSceneLoadedEvent?.Invoke(this.Scene);
            LoadingScreen.Hide();
        }

        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if (this.IsLoading)
                throw new Exception("Scene is loading already");

            var config = this.sceneConfigMap[sceneName];
            if (config == null)
                throw new Exception("There is no config for this scene");

            LoadingScreen.Show();
            return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig config)
        {
            this.IsLoading = true;
            this.OnSceneStartLoadEvent?.Invoke(this.Scene);
                        
            yield return Coroutines.StartRoutine(LoadSceneRoutine(config));
            yield return Coroutines.StartRoutine(InitializeSceneRoutine(config));

            this.IsLoading = false;
            this.OnSceneLoadedEvent?.Invoke(this.Scene);
            OnSceneInitializedEvent?.Invoke();
        }

        private IEnumerator LoadSceneRoutine(SceneConfig config)
        {
            var loadAsync = SceneManager.LoadSceneAsync(config.SceneName);
            loadAsync.allowSceneActivation = false;

            while (loadAsync.progress < 0.9f)            
                yield return null;
                        
            loadAsync.allowSceneActivation = true;
            LoadingScreen.Hide();
        }

        private IEnumerator InitializeSceneRoutine(SceneConfig config)
        {
            this.Scene = new Scene(config);
            yield return this.Scene.InitializeRoutine();            
        }

        public T GetRepository<T>() where T : Repository
        {
            return this.Scene.GetRepository<T>();
        }

        public T GerInteractor<T>() where T : Interactor
        {
            return this.Scene.GetInteractor<T>();
        }
    }
}