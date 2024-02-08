using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using TMPro;

namespace TDS.UI
{
      public class SliderText : MonoBehaviour
      {
            [Header("R E F E R E N C E S")]
            [SerializeField] private Slider slider;
            [SerializeField] private TMP_InputField input;

            [Header("E V E N T S")]
            public UnityEvent<float> OnValueChange;


            private void Reset()
            {
                  slider = GetComponentInChildren<Slider>();
                  input = GetComponentInChildren<TMP_InputField>();
            }


            #region I N P U T   F I E L D
            public void FilterText(string text)
            {
                  int length = 0, period = 0;
                  input.text = new(text.Where(@char => char.IsDigit(@char) || @char == '.' && ++period == 1 && ++length < 4).ToArray());
            }
            public void UpdateSlider(string text) => input.text = Mathf.Clamp(slider.value = float.Parse(text), slider.minValue, slider.maxValue).ToString();
            #endregion

            #region S L I D E R
            public void UpdateText(float value)
            {
                  input.text = value.ToString(slider.wholeNumbers ? "0" : "0.00");

                  OnValueChange.Invoke(value);
            }
            #endregion
      }
}