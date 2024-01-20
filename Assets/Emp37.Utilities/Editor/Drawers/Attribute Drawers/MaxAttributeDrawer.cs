using UnityEngine;

using UnityEditor;

namespace Emp37.Editor
{
      using Type = SerializedPropertyType;


      [CustomPropertyDrawer(typeof(Attribute.MaxAttribute))]
      internal class MaxAttributeDrawer : PropertyDrawer
      {
            private protected override void OnPropertyDraw(Rect position, SerializedProperty property, GUIContent label)
            {
                  if (property.propertyType is Type.Float or Type.Integer or Type.Vector2 or Type.Vector3 or Type.Vector2Int or Type.Vector3Int is false)
                  {
                        EditorGUI.HelpBox(position, "Use MaxAttribute on 'Floating' or 'Integer' field types.", MessageType.Error);
                        return;
                  }
                  using (new EditorGUI.ChangeCheckScope())
                  {
                        _ = EditorGUI.PropertyField(position, property, label);
                        if (EditorGUI.EndChangeCheck())
                        {
                              var attribute = base.attribute as Attribute.MaxAttribute;
                              switch (property.propertyType)
                              {
                                    case Type.Float:
                                          {
                                                property.floatValue = clampValue(property.floatValue);
                                                break;
                                          }
                                    case Type.Vector2:
                                          {
                                                var value = property.vector2Value;
                                                property.vector2Value = new(x: clampValue(value.x), y: clampValue(value.y));
                                                break;
                                          }
                                    case Type.Vector3:
                                          {
                                                var value = property.vector3Value;
                                                property.vector3Value = new(x: clampValue(value.x), y: clampValue(value.y), z: clampValue(value.z));
                                                break;
                                          }

                                    case Type.Integer:
                                          {
                                                property.intValue = clampIntValue(property.intValue);
                                                break;
                                          }
                                    case Type.Vector2Int:
                                          {
                                                var value = property.vector2IntValue;
                                                property.vector2IntValue = new(x: clampIntValue(value.x), y: clampIntValue(value.y));
                                                break;
                                          }
                                    case Type.Vector3Int:
                                          {
                                                var value = property.vector3IntValue;
                                                property.vector3IntValue = new(x: clampIntValue(value.x), y: clampIntValue(value.y), z: clampIntValue(value.z));
                                                break;
                                          }
                              }
                              int clampIntValue(int value) => Mathf.Clamp(value, int.MinValue, (int) attribute.Value);
                              float clampValue(float value) => Mathf.Clamp(value, float.MinValue, attribute.Value);
                        }
                  }
            }
      }
}