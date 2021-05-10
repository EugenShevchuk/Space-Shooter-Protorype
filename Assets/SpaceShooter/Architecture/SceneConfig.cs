using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceShooter.Architecture 
{
    public abstract class SceneConfig
    {
        public abstract Dictionary<Type, Repository> CreacteAllRepositories();
        public abstract Dictionary<Type, Interactor> CreateAllInteractors();
        public abstract string SceneName { get; }

        protected void CreateRepository<T>(Dictionary<Type, Repository> repositoriesMap) where T : Repository, new()
        {
            var repository = new T();
            var type = typeof(T);

            repositoriesMap[type] = repository;
        } 

        protected void CreateInteractor<T>(Dictionary<Type, Interactor> interactorsMap) where T : Interactor, new ()
        {
            var interactor = new T();
            var type = typeof(T);

            interactorsMap[type] = interactor;
        }

    }
}