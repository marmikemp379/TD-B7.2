using UnityEngine;

namespace TDS.Object
{
      [CreateAssetMenu]
      public class Settings : ScriptableObject
      {
            [Header("V I D E O")]
            public ushort TargetFPS;

            [Header("I N P U T")]
            public Keybinds Key;
      }
}