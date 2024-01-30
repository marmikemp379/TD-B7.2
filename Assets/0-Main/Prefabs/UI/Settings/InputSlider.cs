using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System.Linq;

public class InputSlider : MonoBehaviour
{
      [Header("R E F E R E N C E S")]
      [SerializeField] private Slider slider;
      [SerializeField] private TMP_InputField input;


      public void FilterText(string text)
      {
            int length = 0;
            input.text = new string(text.Where(@char => char.IsDigit(@char) && ++length < 4).ToArray());
      }
      public void UpdateText(float value) => input.text = value.ToString();
      public void UpdateSlider(string text) => slider.value = int.Parse(text);
}