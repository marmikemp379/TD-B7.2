using UnityEngine;

public class GUN : MonoBehaviour
{
      public ushort PistolAmmo, RifleAmmo;

      [SerializeField] private Transform nozzle;
      [SerializeField] private Bullet bullet;


      private void Shoot(int ID)
      {
            switch (ID)
            {
                  case 0: // Pistol
                        {
                              var instantiatedBullet = Instantiate(bullet, nozzle.position, Quaternion.identity);
                              instantiatedBullet.Fire(-nozzle.up, 100F);

                              print(nozzle.up);
                        }
                        break;

                  case 1: // Rifle
                        {

                        }
                        break;
            }
      }
}