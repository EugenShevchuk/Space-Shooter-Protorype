namespace SpaceShooter.Architecture
{
    public class SceneManagerRealization : SceneManagerBase
    {
        public override void InitializeScenesMap()
        {
            sceneConfigMap[SceneConfigMainMenu.SCENE_NAME] = new SceneConfigMainMenu();
            sceneConfigMap[SceneConfigGame.SCENE_NAME] = new SceneConfigGame();
        }
    }
}