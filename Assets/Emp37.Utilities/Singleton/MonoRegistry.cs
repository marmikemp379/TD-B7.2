using System;
using System.Collections.Generic;

using UnityEngine;

namespace Emp37.Singleton
{
      using Object = UnityEngine.Object;

      /// <summary>
      /// A registry for registering and managing singleton instances of MonoBehaviour components.
      /// </summary>
      public static class MonoRegistry
      {
            public enum DestroyOptions
            {
                  /// <summary>
                  /// Instance.gameObject is destroyed.
                  /// </summary>
                  GameObject,
                  /// <summary>
                  /// Instance component is destroyed.
                  /// </summary>
                  Component,
                  /// <summary>
                  /// No destruction is performed instead, an exception is thrown.
                  /// </summary>
                  Exception,
            }


            static readonly Dictionary<Type, Component> content = new();

            /// <summary>
            /// Specify the action to be perform when handling duplicate instance registrations.
            /// </summary>
            public static DestroyOptions DuplicateInstanceHandlingAction { get; set; }

            /// <summary>
            /// Fetches a formatted list of registered type names from this registry.
            /// <br>Intended for logging and debugging purposes.</br>
            /// </summary>
            /// <remarks>This property provides a newline-separated string containing the names of all registered types on this registry.</remarks>
            public static string Read => string.Join('\n', content.Keys);

            /// <summary>
            /// Searches this registry for MonoBehaviour component of type T.
            /// </summary>
            /// <typeparam name="T">The type of component to search for.</typeparam>
            /// <returns>If found, the component as type T. Otherwise, an exception is thrown.</returns>
            /// <exception cref="NullReferenceException"></exception>
            /// <remarks>It is recommended to cache the return value for better performance when making many lookups of the same type.</remarks>
            public static T Lookup<T>() where T : Component
            {
                  if (content.TryGetValue(typeof(T), out var instance)) return instance as T;
                  throw new NullReferenceException($"Instance of type <{typeof(T).Name}> does not exist on this registry.");
            }
            /// <summary>
            /// Searches this registry for MonoBehaviour component of type T.
            /// </summary>
            /// <typeparam name="T">The type of component to search for.</typeparam>
            /// <param name="value">If found, the component as type T. Otherwise, Null.</param>
            /// <returns>True if 'value' is not null.</returns>
            /// <remarks>It is recommended to cache the out value for better performance when making many lookups of the same type.</remarks>
            public static bool TryLookup<T>(out T value) where T : Component
            {
                  _ = content.TryGetValue(typeof(T), out var instance);
                  return value = instance as T;
            }

            /// <summary>
            /// Writes this MonoBehaviour component type on the SingletonRegistry.
            /// </summary>
            public static void Register(this MonoBehaviour instance)
            {
                  if (instance == null)
                  {
                        Debug.LogWarning("Instance couldn't be registered: instance is null.");
                        return;
                  }
                  var instanceType = instance.GetType();
                  if (content.ContainsKey(instanceType))
                  {
                        var message = $"Instance of type <{instanceType}> couldn't be registered: instance is already registered.";
                        Object context = DuplicateInstanceHandlingAction switch { DestroyOptions.GameObject => instance.gameObject, DestroyOptions.Component => instance, _ => throw new NullReferenceException(message) };
                        Debug.LogWarning($"{message} Hence, destroying duplicate {DuplicateInstanceHandlingAction} context: '{context.name}'.");
                        Object.Destroy(context);
                  }
                  else
                  {
                        content.Add(key: instanceType, value: instance);
                        Debug.Log($"Registered instance of type <{instanceType}>.");
                  }
            }
            /// <summary>
            /// Erases this MonoBehaviour component type from the SingletonRegistry.
            /// </summary>
            public static void Unregister(this MonoBehaviour instance)
            {
                  if (instance == null)
                  {
                        Debug.LogWarning("Instance couldn't be unregistered: instance is null.");
                        return;
                  }
                  var instanceType = instance.GetType();
                  if (content.ContainsKey(instanceType))
                  {
                        if (content[instanceType] != instance) return;

                        content.Remove(key: instanceType);
                        Debug.Log($"Unegistered instance of type <{instanceType}>.");
                  }
                  else
                  {
                        Debug.LogWarning($"Instance of type <{instanceType}> couldn't be unregistered: instance does not exist on this registry.");
                  }
            }

            /// <summary>
            /// Erases everything from this registry.
            /// </summary>
            public static void Wipe()
            {
                  foreach (var key in content.Keys)
                  {
                        Debug.Log($"Unregistering instance of type <{key}>.");
                  }
                  content.Clear();
                  Debug.Log("Registry Wiped!");
            }
      }
}