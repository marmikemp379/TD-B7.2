using UnityEngine;
using UnityEngine.Events;

namespace TDS.Player
{
      using Object;


      public class Character : MonoBehaviour
      {
            [Tooltip("When the character is marked to be in control.")]
            public UnityEvent<bool> OnFocused;

            public InputKeys keys;


            private void OnEnable() => OnFocused.Invoke(true);
            private void OnDisable() => OnFocused.Invoke(false);
      }
}