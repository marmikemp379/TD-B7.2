using UnityEngine;

namespace Game
{
      using static KeyCode;

      [CreateAssetMenu(order = 63)]
      public class Keybinds : ScriptableObject
      {
            [Header("B A S I C   M O V E M E N T")]
            public KeyCode Forward = W;
            public KeyCode Back = S;
            public KeyCode Left = A;
            public KeyCode Right = D;

            [Header("A C T I O N S")]
            public KeyCode Attack = Mouse0;
            public KeyCode Use = E;
      }
}