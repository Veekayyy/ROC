using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
   [SerializeField]
   private BarreDeVie barreVie;
   [SerializeField]
   private float maxVal;
   [SerializeField]
   private float currentVal;

   //[SerializeField]
   //private BarreDeVie barreMana;
   //[SerializeField]
   //private float maxValM;
   //[SerializeField]
   //private float currentValM;

   public float CurrentVal {
      get
      {
         return currentVal;
      }
      set 
      {
         this.currentVal = Mathf.Clamp(value,0,MaxVal);
         barreVie.Value = currentVal;
      } 
   }
   //public float CurrentValM
   //{
   //   get
   //   {
   //      return currentValM;
   //   }
   //   set
   //   {
   //      this.currentValM = Mathf.Clamp(value, 0, MaxVal);
   //      barreMana.Value = currentValM;
   //   }
   //}

   public float MaxVal {
      get
      {
        return maxVal;
      }
      set
      {
         this.maxVal = value;
         barreVie.MaxValue = maxVal;
      }
   }

   //public float MaxValM
   //{
   //   get
   //   {
   //      return maxValM;
   //   }
   //   set
   //   {
   //      this.maxValM = value;
   //      barreMana.MaxValue = maxValM;
   //   }
   //}

   public void Initialise()
   {
      this.MaxVal = maxVal;
      this.CurrentVal = currentVal;
   }
}
