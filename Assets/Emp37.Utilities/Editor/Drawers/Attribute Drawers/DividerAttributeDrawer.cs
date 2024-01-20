using UnityEngine;

using UnityEditor;

namespace Emp37.Editor
{
      using Attribute;

      [CustomPropertyDrawer(typeof(DividerAttribute))]
      internal class DividerAttributeDrawer : DecoratorDrawer
      {
            public override void OnGUI(Rect position)
            {
                  position.y += EditorGUIUtility.standardVerticalSpacing;
                  position.height = (attribute as DividerAttribute).Thickness;
                  EditorGUI.DrawRect(position, EditorGUIUtility.isProSkin ? Color.black : Color.white);
            }
            public override float GetHeight() => 2F * EditorGUIUtility.standardVerticalSpacing + (attribute as DividerAttribute).Thickness;
      }
}