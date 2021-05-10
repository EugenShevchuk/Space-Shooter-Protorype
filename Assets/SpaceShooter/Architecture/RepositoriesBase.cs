using System;
using System.Collections.Generic;

namespace SpaceShooter.Architecture
{
    public class RepositoriesBase 
    {
        private Dictionary<Type, Repository> repositoriesMap;
        private SceneConfig sceneConfig;

        public RepositoriesBase(SceneConfig config)
        {
            sceneConfig = config;
        }

        public void CreateAllRepositories()
        {
            repositoriesMap = sceneConfig.CreacteAllRepositories();
        }

        public void SendOnCreateToAllRepositories()
        {
            var allRepositories = repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnCreate();
            }
        }

        public void InitializeAllRepositories()
        {
            var allRepositories = repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.Initialize();
            }
        }

        public void SendOnStartToAllRepositories()
        {
            var allRepositories = repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnStart();
            }
        }

        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T) repositoriesMap[type];
        }
    }
}