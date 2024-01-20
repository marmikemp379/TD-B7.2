using UnityEngine;

namespace TDS.Object
{
      using static KeyCode;

      [CreateAssetMenu]
      public class InputKeys : ScriptableObject
      {
            public KeyCode Switch = F;

            public KeyCode Forward = W, Backward = S, Left = A, Right = D;
            public KeyCode Fire = Mouse0;

            public KeyCode Bat = Alpha1, Knife = Alpha2, Pistol = Alpha3, Rifle = Alpha4, Flamethrower = Alpha5;


            public bool IsAnyAxisKeyPressedOrReleased => Input.GetKeyDown(Forward) || Input.GetKeyDown(Backward) || Input.GetKeyDown(Left) || Input.GetKeyDown(Right) || Input.GetKeyUp(Forward) || Input.GetKeyUp(Backward) || Input.GetKeyUp(Left) || Input.GetKeyUp(Right);
      }
}