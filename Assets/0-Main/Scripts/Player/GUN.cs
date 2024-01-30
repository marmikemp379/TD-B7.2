using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUN : MonoBehaviour
{
      [SerializeField] private int pistolAmmo, rifleAmmo;
      [SerializeField] private TextMeshProUGUI ammoCountGUI;


      public int PistolAmmo
      {
            get => pistolAmmo;
            set
            {
                  pistolAmmo = Mathf.Clamp(value, 0, int.MaxValue);

                  ammoCountGUI.text = pistolAmmo.ToString();
            }
      }
      public int RifleAmmo
      {
            get => rifleAmmo;
            set
            {
                  rifleAmmo = Mathf.Clamp(value, 0, int.MaxValue);

                  ammoCountGUI.text = rifleAmmo.ToString();
            }
      }


      [SerializeField] private Transform nozzle;
      [SerializeField] private Bullet bullet;

      [SerializeField] private List<Bullet> bullets;

      private WaitForSeconds bulletShootInterval = new(0.1F);


      private void OnGUI()
      {
            if (GUILayout.Button("Show Bullets In Hierarchy"))
            {
                  if (bullets.Count is 0) return;

                  foreach (var bullet in bullets)
                  {
                        bool isShowing = bullet.gameObject.hideFlags is HideFlags.HideInHierarchy;
                        bullet.gameObject.hideFlags = isShowing ? HideFlags.None : HideFlags.HideInHierarchy;
                  }
            }
      }
      private void Start()
      {
            for (int i = 0; i < 10; i++)
            {
                  bullets.Add(Instantiate(bullet, nozzle.position, Quaternion.identity));
            }
      }
      private void Shoot(int ID)
      {
            switch (ID)
            {
                  case 0: // Pistol
                        {
                              ShootInactiveBullet(ID);
                        }
                        break;

                  case 1: // Rifle
                        {
                              StartCoroutine(ShootRifle(ID));
                        }
                        break;
            }
      }


      private IEnumerator ShootRifle(int ID)
      {
            for (byte i = 0; i < 4; ++i)
            {
                  if (RifleAmmo is 0) yield break;

                  ShootInactiveBullet(ID);
                  yield return bulletShootInterval;
            }
      }


      private void ShootInactiveBullet(int ID)
      {
            foreach (var bullet in bullets)
            {
                  if (bullet.gameObject.activeSelf) continue;

                  bullet.transform.position = nozzle.position;
                  bullet.gameObject.SetActive(true);
                  bullet.Fire(-nozzle.up, 100F);

                  switch (ID) { case 0: PistolAmmo--; break; case 1: RifleAmmo--; break; }
                  break;
            }
      }
}