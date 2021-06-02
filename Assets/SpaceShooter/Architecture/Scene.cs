using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Architecture {
    public class Scene
    {
        private RepositoriesBase repositoriesBase;
        private InteractorsBase interactorsBase;
        private SceneConfig sceneConfig;

        public static event Action InitializedEvent;

        public Scene(SceneConfig config)
        {
            sceneConfig = config;
            repositoriesBase = new RepositoriesBase(config);
            interactorsBase = new InteractorsBase(config);
        }

        public IEnumerator InitializeRoutine()
        {
            repositoriesBase.CreateAllRepositories();
            interactorsBase.CreateAllInteractors();
            yield return null;

            repositoriesBase.SendOnCreateToAllRepositories();
            interactorsBase.SendOnCreateToAllInteractors();
            yield return null;

            repositoriesBase.InitializeAllRepositories();
            interactorsBase.InitializeAllInteractors();
            yield return null;

            repositoriesBase.SendOnStartToAllRepositories();
            interactorsBase.SendOnStartToAllInteractors();
            InitializedEvent?.Invoke();
        }

        public T GetRepository<T>() where T : Repository
        {
            return repositoriesBase.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return interactorsBase.GetInteractor<T>();
        }
    }
}