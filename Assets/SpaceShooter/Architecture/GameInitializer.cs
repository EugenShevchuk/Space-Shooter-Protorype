using UnityEngine;

namespace SpaceShooter.Architecture
{
    public class GameInitializer : MonoBehaviour
    {
        private void Start()
        {
            Game.Run();
        }
    }
}