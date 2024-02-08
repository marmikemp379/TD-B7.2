using System;
using UnityEngine;

namespace TDS.UI.Menu
{
      public class OptionSelection : MonoBehaviour
      {
            public enum Category
            {
                  Video = 0, Audio = 1, Inputs = 2
            }

            [Serializable]
            private struct Categories
            {
                  public GameObject[] _video, _audio, _inputs;
                  public GameObject[] this[Category category] => category switch { Category.Video => _video, Category.Audio => _audio, Category.Inputs => _inputs, _ => null };
            }

            [SerializeField] private Categories categories;


            public void SetCategoryActive(int id)
            {
                  foreach (Category category in Enum.GetValues(typeof(Category)))
                  {
                        foreach (var obj in categories[category])
                        {
                              obj.SetActive((int)category == id);
                        }
                  }
            }
            public void SetCategoryActive(Category category) => SetCategoryActive((int)category);
      }
}