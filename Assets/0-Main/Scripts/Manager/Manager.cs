using UnityEngine;

namespace TDS
{
      using Object;


      [DefaultExecutionOrder(5)]
      public class Manager : MonoBehaviour
      {
            [SerializeField] private Settings settings;
            [SerializeField] private CursorLockMode cursorLockMode;


            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
            private static void Initialize()
            {
                  Load();
            }

            private void Start()
            {
                  Cursor.lockState = cursorLockMode;
            }
            private void OnApplicationQuit()
            {
                  Save();
            }


            public static void Load()
            {

            }
            public static void Save()
            {

            }
      }
}