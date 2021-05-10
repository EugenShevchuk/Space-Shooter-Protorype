using System;
using System.Collections.Generic;

namespace SpaceShooter.Architecture
{
    public class SceneConfigMainMenu : SceneConfig
    {
        public const string SCENE_NAME = "MainMenu";
        public override string SceneName => SCENE_NAME;

        public override Dictionary<Type, Repository> CreacteAllRepositories()
        {
            var repositoriesMap = new Dictionary<Type, Repository>();

            CreateRepository<PlayerStatsRepository>(repositoriesMap);
            CreateRepository<WeaponsRepository>(repositoriesMap);
            CreateRepository<KinematicWeaponRepository>(repositoriesMap);
            CreateRepository<BlasterWeaponRepository>(repositoriesMap);
            CreateRepository<LaserWeaponRepository>(repositoriesMap);

            return (repositoriesMap);
        }

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            var interactorsMap = new Dictionary<Type, Interactor>();

            CreateInteractor<PlayerStatsInteractor>(interactorsMap);
            CreateInteractor<WeaponsInteractor>(interactorsMap);
            CreateInteractor<KinematicWeaponInteractor>(interactorsMap);
            CreateInteractor<BlasterWeaponInteractor>(interactorsMap);
            CreateInteractor<LaserWeaponInteractor>(interactorsMap);

            return (interactorsMap);
        }
    }
}