using UnityEngine;

namespace TDS.Object
{
      using static KeyCode;

      [CreateAssetMenu]
      public class Keybindings : ScriptableObject
      {
            public KeyCode Switch = F;

            public KeyCode Forward = W, Back = S, Left = A, Right = D;
            public KeyCode Fire = Mouse0;

            public KeyCode Bat = Alpha1, Knife = Alpha2, Pistol = Alpha3, Rifle = Alpha4, Flamethrower = Alpha5;


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