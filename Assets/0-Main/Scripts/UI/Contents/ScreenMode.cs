using System.Collections.Generic;

using UnityEngine;

using TMPro;

public class ScreenMode : MonoBehaviour
{
      public TMP_Dropdown Dropdown;

      private void Reset()
      {
            Dropdown = GetComponent<TMP_Dropdown>();
      }
      private void OnEnable()
      {
            Dropdown.AddOptions(new List<string>() { "On", "Off" });
      }

      public void OnValueChange(int value)
      {
            Screen.SetResolution(Screen.width, Screen.height, value == 1);
      }
}