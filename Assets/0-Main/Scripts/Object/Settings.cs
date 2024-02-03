using UnityEngine;

namespace TDS.Object
{
      [CreateAssetMenu]
      public class Settings : ScriptableObject
      {
            public ushort MaxFPS;
            public Vector2[] Resolutions;
      }
}