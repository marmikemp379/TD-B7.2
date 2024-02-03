using System;

using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI.Content
{
      public class FPS : MonoBehaviour
      {
            public void SetInitialValue(Slider slider) => slider.value = 0;/*Manager.Settings.MaxFPS;*/
            public void OnValueChange(float value) => Application.targetFrameRate /*Manager.Settings.MaxFPS*/ = Convert.ToUInt16(value);
      }
}