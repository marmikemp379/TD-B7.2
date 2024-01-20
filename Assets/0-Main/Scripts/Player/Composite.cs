using UnityEngine;

namespace TDS.Player
{
      using Object;


      public class Composite : MonoBehaviour
      {
            [SerializeField] private Keybindings keys;
            [SerializeField] private Character[] characters;

            private int id; public int ID
            {
                  get => id;
                  set
                  {
                        characters[id].enabled = false;

                        id = Mathf.Clamp(value, min: 0, max: characters.Length);

                        characters[id].enabled = true;
                  }
            }


            private void Start()
            {
                  for (int i = 0; i < characters.Length; i++)
                  {
                        characters[i].enabled = false;
                  }
                  ID = 0;
            }
            private void Update()
            {
                  if (Input.GetKeyDown(keys.Switch))
                  {
                        ID = (int)Mathf.Repeat(ID + 1, characters.Length);
                  }
            }
      }
}