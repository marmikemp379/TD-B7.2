using UnityEngine;

namespace TDS.Manager
{
      using Object;


      [DefaultExecutionOrder(5)]
      public class GameManager : MonoBehaviour
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

                  Application.targetFrameRate = settings.MaxFPS;
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