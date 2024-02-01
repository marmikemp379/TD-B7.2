using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TDS.UI.Content
{
      public class Resolution : MonoBehaviour
      {
            public TMP_Dropdown TD;
            public UnityEngine.Resolution[] resolutions;


            private void OnEnable()
            {
                  resolutions = Screen.resolutions;

                  var options = new List<string>();
                  foreach (var resolution in resolutions)
                  {
                        options.Add(resolution.width + " x " + resolution.height + " @ " + resolution.refreshRateRatio);
                  }
                  TD.AddOptions(options);
            }
      }
}