using UnityEngine;

namespace TDS.Object
{
      using static KeyCode;

      [CreateAssetMenu]
      public class Keybinds : ScriptableObject
      {
            [Header("M O V E M E N T")]
            public KeyCode Forward = W;
            public KeyCode Back = S;
            public KeyCode Left = A;
            public KeyCode Right = D;

            [Header("A C T I O N S")]
            public KeyCode Switch = F;
            public KeyCode Fire = Mouse0;

            [Header("W E A P O N S")]
            public KeyCode Bat = Alpha1;
            public KeyCode Knife = Alpha2;
            public KeyCode Pistol = Alpha3;
            public KeyCode Rifle = Alpha4;
            public KeyCode Flamethrower = Alpha5;

            [Header("U I")]
            public KeyCode Pause = Escape;


            public bool IsAnyAxisKeyPressedOrReleased => Input.GetKeyDown(Forward) || Input.GetKeyDown(Back) || Input.GetKeyDown(Left) || Input.GetKeyDown(Right) || Input.GetKeyUp(Forward) || Input.GetKeyUp(Back) || Input.GetKeyUp(Left) || Input.GetKeyUp(Right);


            public KeyCode this[string keyName]
            {
                  get => keyName switch
                  {
                        nameof(Forward) => Forward,
                        "Back" => Back,
                        "Left" => Left,
                        "Right" => Right,
                        _ => None
                  };
                  set
                  {
                        switch (keyName)
                        {
                              case "Forward": Forward = value; break;
                              case "Back": Back = value; break;
                              case "Left": Left = value; break;
                              case "Right": Right = value; break;
                        }
                  }
            }
      }
}