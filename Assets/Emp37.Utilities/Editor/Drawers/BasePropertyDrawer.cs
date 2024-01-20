using UnityEngine;

using UnityEditor;

namespace Emp37.Editor
{
      internal abstract class PropertyDrawer : UnityEditor.PropertyDrawer
      {
            private protected abstract void OnPropertyDraw(Rect position, SerializedProperty property, GUIContent label);

            public sealed override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                  using (new EditorGUI.PropertyScope(position, label, property))
                  {
                        OnPropertyDraw(position, property, label);
                  }
            }
            public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => EditorGUI.GetPropertyHeight(property, label, true);
      }
}