using UnityEngine;
using UnityEngine.UI;

public class ScreenCategory : MonoBehaviour
{
      [SerializeField] private VerticalLayoutGroup contentVerticalLayoutGroup;
      private VerticalLayoutGroup verticalLayoutGroup;

      private RectTransform rectTransform;

      public int X;
      private void Awake()
      {
            rectTransform = GetComponent<RectTransform>();
            verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
      }
      private void OnValidate()
      {
            Awake();

            OnTransformChildrenChanged();
      }

      private void OnTransformChildrenChanged()
      {
            verticalLayoutGroup.spacing = contentVerticalLayoutGroup.spacing;

            float height = 0F;
            for (int i = 0; i < transform.childCount; i++)
            {
                  var rect = transform.GetChild(i).GetComponent<RectTransform>();
                  height += rect.sizeDelta.y;
            }
            height += transform.childCount * verticalLayoutGroup.spacing;

            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
      }
}