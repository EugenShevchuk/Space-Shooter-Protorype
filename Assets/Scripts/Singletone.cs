using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        public static GameObject playerPrefab;
        public static Material playerMaterial;
    }
}