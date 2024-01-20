using UnityEngine;

public class MELEE : MonoBehaviour
{
      [Header("H I T   P O I N T S")]
      [SerializeField] private Transform meleeHitTransform;

      [SerializeField] private LayerMask damageableLayers;

      [SerializeField] private RaycastHit2D[] results = new RaycastHit2D[3];


#pragma warning disable IDE0051 // Remove unused private members
      private void Attack(float radius)
      {
            var enemies = Physics2D.CircleCastNonAlloc(meleeHitTransform.position, radius, Vector2.down, results, 0F, damageableLayers);
            if (enemies > 0)
            {
                  for (int i = 0; i < enemies; i++)
                  {
                        if (results[i].collider.TryGetComponent(out IDamageable ID))
                        {
                              ID.OnDamage(2);
                        }
                        else
                        {
                              Debug.Log(results[i].collider.name);
                        }
                  }
            }
      }
#pragma warning restore IDE0051
}