using UnityEngine;

public class Bullet : MonoBehaviour
{
      private Rigidbody2D body;
      private TrailRenderer trail;


      private void Awake()
      {
            body = GetComponent<Rigidbody2D>();
            trail = GetComponent<TrailRenderer>();
      }
      private void Start() => ResetBullet();

      public void Fire(Vector2 direction, float force)
      {
            body.AddForce(direction * force * body.mass, ForceMode2D.Impulse);
      }
      private void OnCollisionEnter2D(Collision2D collision)
      {
            if (collision.transform.TryGetComponent(out IDamageable ID))
            {
                  ID.OnDamage(4);
            }
            ResetBullet();
      }
      private void OnBecameInvisible()
      {
            ResetBullet();
      }


      private void ResetBullet()
      {
            gameObject.SetActive(false);

            trail.Clear();
      }
}
