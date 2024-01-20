using UnityEngine;

namespace Emp37.Singleton
{
      public static class Generic<T> where T : MonoBehaviour
      {
            private static T instance;

            /// <summary>
            /// A simple MonoBehaviour-based singleton to use at runtime.
            /// </summary>
            /// <remarks>
            /// <b>NOTE:</b>
            /// <br>• This implementation does not support the 'Recompile and Continue Playing' value in <i><b>Preferences > General > Script Changes While Playing</b></i>.</br>
            /// <br>• Requires explicit placement of component T on the scene.</br>
            /// </remarks>
            public abstract class Lightweight : MonoBehaviour // ~Hextant Studios
            {
                  public static T Instance => instance;

                  protected virtual void Awake()
                  {
                        Debug.Assert(condition: instance == null, message: $"Multiple instances of type <{typeof(T).Name}> exist on this scene.", context: this);

                        instance = this as T;
                  }
                  protected virtual void OnDestroy() => instance = null;
            }

            /// <remarks>
            /// <b>NOTE:</b>
            /// <br>• This implementation destroys any duplicate gameObject of type T instantiated at runtime.</br>
            /// <br>• Explicit placement of component T on the scene is not necessary.</br>
            /// <br>• It is recommended to call the 'Initialize' function manually on awake or a static method using InitializeOnLoadAttribute on the derived class.</br>
            /// </remarks>
            public abstract class Dynamic : MonoBehaviour
            {
                  public static T Instance => instance ??= Application.isPlaying ? FindObjectOfType<T>() ?? new GameObject(typeof(T).Name + " : Singleton").AddComponent<T>() : null;

                  protected virtual void OnDestroy() => instance = instance == this ? null : instance;

                  /// <summary>
                  /// Initializes the singleton instance of type T.
                  /// </summary>
                  /// <param name="persistency">Determines weather or not to use 'DontDestroyOnLoad' method on this object.</param>
                  protected void Initialize(bool persistency)
                  {
                        if (instance != null && instance != this)
                        {
                              Debug.LogWarning($"Destroying a duplicate component of type <{typeof(T).Name}> namely: {name}");
                              Destroy(instance);
                              return;
                        }
                        instance = this as T;
                        if (persistency) DontDestroyOnLoad(instance);
                  }
            }
      }
}