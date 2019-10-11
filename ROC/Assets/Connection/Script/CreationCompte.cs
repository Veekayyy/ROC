// But : Programmer la création de compte pour le jeu ROC.
// Auteur : Gabriel Duquette Godon
// Date : 10 octobre 2019

#region Bibliothèque
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
#endregion

public class CreationCompte : MonoBehaviour
{
   #region Attribut

   #region Bouton
   public Button btn_Connection;
   public Button btn_Annuler;
   #endregion

   #region Zone texte
   public InputField Utilisateur;
   public InputField MotDePasse;
   public InputField Confirmation_MotDePasse;
   #endregion

   #region Regex
   private Regex alphanumerique = new Regex("^[a-zA-Z0-9]*$");
   #endregion

   #region Constances
   private const int MIN_CARACTERE = 1;
   private const int MAX_CARACTERE = 15;
   #endregion

   #region Système
   EventSystem systeme;
   #endregion

   #endregion

   private void Start()
   {
      // On initialise la variable system.
      systeme = EventSystem.current;
   }

   private void Update()
   {
      // On fait la tabulation si l'utilisateur clique sur tabulation.
      Tabulation();
   }

   #region Méthode publique

   #region Bouton
   public void Annuler()
   {
      SceneManager.LoadScene("Connection", LoadSceneMode.Single);
   }
   #endregion

   public bool Verification_Utilisateur()
   {
      // Minimum un caractère.
      // Maximum : 15 caractère.
      // Caractère alpha numérique
      // Case unsentitive.

      // On regarde si le mot de passe respect les normes du nombre de caractère.
      if (Utilisateur.text.Length < MIN_CARACTERE || Utilisateur.text.Length > MAX_CARACTERE)
         return false;   // S'il ne respecte pas les caractérisque, on retourne faux.

      // On regarde si le nom n'est alpha numérique.
      if (!alphanumerique.IsMatch(Utilisateur.text))
         return false; // S'il n'est pas alpha numérique, renvoie faux.

      // Si le nom respecte tous les cas, on retourne vrai.
      return true;
   }

   public bool Verification_MotDePasse(bool Confirmation)
   {
      // Déclaration des variables locales.
      InputField MotPasse_Verifier = (Confirmation ? MotDePasse : Confirmation_MotDePasse);
      
      // Minimum : un caractère.
      // Maximum : 15 caractère.
      // Caractère alpha numérique et caractères spéciaux.
      // Case ensitive.

      // On regarde si le mot de passe respect les normes du nombre de caractère.
      if (MotPasse_Verifier.text.Length < MIN_CARACTERE || MotPasse_Verifier.text.Length > MAX_CARACTERE)
         return false;   // S'il ne respecte pas les caractérisque, on retourne faux.


      return true;
   }

   public bool Verification_Confirmation()
   {
      // Minimum : un caractère.
      // Maximum : 15 caractère.
      // Caractère alpha numérique et caractères spéciaux.
      // Case ensitive.
      // Mot de passe parail.

      // On regarde si le mot de passe respect c'est norme.
      if (!Verification_MotDePasse(true))
         return false;

      // On regarde si le mot de passe est parail comme le champ de mot de passe.
      if (MotDePasse.text != Confirmation_MotDePasse.text)
         return false;

      return true;
   }


   #endregion

   #region Méthode Privées
   private void Tabulation()
   {
      // Lien internet qui m'a aider configuerer la méthode : https://forum.unity.com/threads/tab-between-input-fields.263779/

      // Si l'utilisateur clique sur la tabulation, fait ceci.
      if (Input.GetKeyDown(KeyCode.Tab))
      {
         // On crée une variable qui va sélectionner la prochain objet.
         Selectable prochain = systeme.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

         // Si le prochain objet n'est pas null, fait ceci.
         if (prochain != null)
         {
            // On crée une variable bouton qui va trouver le prochain bouton.
            Button bouton = prochain.GetComponent<Button>();

            // Si le prochain bouton n'est pas null, fait ceci.
            if (bouton != null)
               bouton.OnPointerClick(new PointerEventData(systeme));

            systeme.SetSelectedGameObject(prochain.gameObject, new BaseEventData(systeme));
         }
      }
   }
   #endregion
}
