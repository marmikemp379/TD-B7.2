using UnityEngine;

public class Bullet : MonoBehaviour
{
      private Rigidbody2D body;

      private void Awake()
      {
            body = GetComponent<Rigidbody2D>();
      }

      public void Fire(Vector2 direction, float force)
      {
            body.AddForce(direction * force, ForceMode2D.Impulse);
      }
}
