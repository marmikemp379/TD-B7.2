using UnityEngine;

namespace TDS.Player
{
      using Emp37.Attribute;
      using Object;
      using UnityEngine.Events;

      public class Animation : MonoBehaviour
      {
            private Keybinds keys;
            private Movement movement;

            private GUN gun;

            private Animator animator;

            private readonly int switchHash = Animator.StringToHash("Switch");
            private readonly int weaponIDHash = Animator.StringToHash("Weapon ID");
            private readonly int attackHash = Animator.StringToHash("Attack");
            private readonly int paceHash = Animator.StringToHash("Pace");


            public UnityAction<int> OnSwitch = delegate { };


            [SerializeField, Readonly] private int _weaponID;
            public int WeaponID => _weaponID;

            private int SetWeapon
            {
                  set
                  {
                        _weaponID = value;

                        OnSwitch.Invoke(_weaponID);

                        animator.SetInteger(weaponIDHash, _weaponID);
                        animator.SetTrigger(switchHash);
                  }
            }


            private void Awake()
            {
                  if (TryGetComponent(out Character ch))
                  {
                        keys = ch.keys;
                  }
                  animator = GetComponent<Animator>();
                  movement = GetComponent<Movement>();
                  gun = GetComponent<GUN>();
            }
            private void Update()
            {
                  if (Input.anyKeyDown)
                  {
                        if (Input.GetKeyDown(keys.Bat)) SetWeapon = 0;
                        if (Input.GetKeyDown(keys.Knife)) SetWeapon = 1;
                        if (Input.GetKeyDown(keys.Pistol)) SetWeapon = 2;
                        if (Input.GetKeyDown(keys.Rifle)) SetWeapon = 3;
                        if (Input.GetKeyDown(keys.Flamethrower)) SetWeapon = 4;
                  }

                  if (Input.GetKeyDown(keys.Fire))
                  {
                        bool hasAmmo = true;
                        switch (WeaponID)
                        {
                              case 2: hasAmmo = gun.PistolAmmo > 0; break;
                              case 3: hasAmmo = gun.RifleAmmo > 0; break;
                        }
                        print(gun.PistolAmmo);

                        if (hasAmmo)
                              animator.SetTrigger(attackHash);
                  }
                  if (Input.GetKeyUp(keys.Fire))
                  {
                        animator.ResetTrigger(attackHash);
                  }
                  if (keys.IsAnyAxisKeyPressedOrReleased)
                  {
                        animator.SetFloat(paceHash, movement.IsMoving ? 1F : 0F);
                  }
            }
      }
}