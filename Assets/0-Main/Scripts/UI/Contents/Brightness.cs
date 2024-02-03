using UnityEngine;

public class Brightness : MonoBehaviour
{
      public void OnValueChange(float value)
      {
            Screen.brightness = value;
      }
}
