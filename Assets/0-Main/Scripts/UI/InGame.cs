using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
      [SerializeField] private TDS.Player.Animation anim;

      [SerializeField] private TMP_Text ammoCount;
      [SerializeField] private Image equippedWeaponImage;

      [SerializeField] private Sprite[] weaponImages;


      private void Start()
      {
            WhenSwitched(anim.WeaponID);
      }
      private void OnEnable()
      {
            anim.OnSwitch += WhenSwitched;
      }
      private void OnDisable()
      {
            anim.OnSwitch -= WhenSwitched;
      }

      private void WhenSwitched(int ID)
      {
            equippedWeaponImage.sprite = weaponImages[ID];

            ammoCount.text = ID switch
            {
                  <= 1 => "∞", // Melee
                  2 => ammoCount.text = anim.GetComponent<GUN>().PistolAmmo.ToString(),
                  3 => ammoCount.text = anim.GetComponent<GUN>().RifleAmmo.ToString(),
                  _ => string.Empty
            };
      }
}