using System.Collections.Generic;
using System;

namespace SpaceShooter.Architecture
{
    public class SceneConfigInGameUI : SceneConfig
    {
        public const string SCENE_NAME = "InGameUI";
        public override string SceneName => SCENE_NAME;

        public override Dictionary<Type, Repository> CreacteAllRepositories()
        {
            var repositoriesMap = new Dictionary<Type, Repository>();

            CreateRepository<PlayerStatsRepository>(repositoriesMap);

            return (repositoriesMap);
        }

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            var interactorsMap = new Dictionary<Type, Interactor>();

            CreateInteractor<PlayerStatsInteractor>(interactorsMap);

            return (interactorsMap);
        }
    }
}