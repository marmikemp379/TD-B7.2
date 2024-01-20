using Emp37.Attribute;

using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
      public UnityEvent OnDeath, OnDamage;

      [field: SerializeField, Min(0F)] public int Max { get; private set; } = 100;

      [SerializeField, Readonly] private int value;

      [SerializeField, Range(0F, 5F)] private int damageMultiplier = 1;


      public int Value => value;


      private void Start()
      {
            value = Max;
      }

      void IDamageable.OnDamage(int amount)
      {
            value = Mathf.Clamp(value - amount * damageMultiplier, 0, Max);

            if (value is 0) OnDeath.Invoke();
            else OnDamage.Invoke();
      }
}