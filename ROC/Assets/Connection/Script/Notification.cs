// But : Programmer les fenêtres de notification du jeu.
// Auteur : Gabriel Duquette Godon
// Date : 10 octobre 2019

#region Bibliothèuqe
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#endregion

public class Notification : MonoBehaviour
{
   #region Attributs
   public Button btn_Fermer;
   #endregion

   #region Méthode
   /// <summary>
   /// Fermer la notification pour revenier
   /// </summary>
   public void Fermeture_Page()
   {
      SceneManager.LoadScene("Connection", LoadSceneMode.Single);
   }

   #endregion
}
