using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   // Start is called before the first frame update

   [SerializeField]
   private Stat vie;

   private void Awake()
   {
      vie.Initialise();
   }

   // Update is called once per frame
   void Update()
    {
      if (Input.GetKeyDown(KeyCode.Q))
      {
         vie.CurrentVal += 10;

      }

      if (Input.GetKeyDown(KeyCode.E))
      {
         vie.CurrentVal -= 10;

      }
   }
}
