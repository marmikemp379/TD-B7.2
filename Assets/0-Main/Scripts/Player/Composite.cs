using UnityEngine;

namespace TDS.Player
{
      using Object;


      public class Composite : MonoBehaviour
      {
            [SerializeField] private InputKeys keys;
            [SerializeField] private Character[] characters;

            private int _id; public int ID
            {
                  get => _id;
                  set
                  {
                        characters[_id].enabled = false;

                        _id = Mathf.Clamp(value, min: 0, max: characters.Length);

                        characters[_id].enabled = true;
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