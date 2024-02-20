using UnityEngine;

namespace Game
{
      [CreateAssetMenu(order = 64)]
      public class Settings : ScriptableObject
      {
            [Header("C O N T R O L S")]
            public Keybinds Key;

            [Header("V I D E O")]
            public ushort FPS;
      }
}