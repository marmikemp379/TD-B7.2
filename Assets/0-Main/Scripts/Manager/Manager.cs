using UnityEngine;

namespace TDS
{
      using Object;


      [DefaultExecutionOrder(5)]
      public class Manager : MonoBehaviour
      {
            private static Manager instance;

            [SerializeField] private Settings settings;
            [SerializeField] private CursorLockMode cursorLockMode;

            public static Settings Settings => instance.settings;


            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
            private static void Initialize()
            {
                  Load();
            }

            private void Awake()
            {
                  instance = this;
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