namespace Wolverine
{
    using System;
    using UnityEngine;

    public class Loader
    {
        private static GameObject gameObject_0;


        public static void InitMystique()
        {
            gameObject_0 = new GameObject();
            gameObject_0.AddComponent<Mystique>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject_0);
           
        }
    }
}

