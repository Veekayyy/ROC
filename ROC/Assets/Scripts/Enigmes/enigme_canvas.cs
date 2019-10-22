using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enigme_canvas : MonoBehaviour
{
    [SerializeField]
    private Button buttontest;

    [SerializeField]
    private GameObject reglage;

    public void OnClickAbandonner()
    {
        CanvasGroup CanvaAOuvrir = GameObject.FindGameObjectWithTag("cnv1").GetComponent<CanvasGroup>();
        CanvasGroup canFelicitation = GameObject.FindGameObjectWithTag("felicitation").GetComponent<CanvasGroup>();

        CanvaAOuvrir.alpha = 0;
        CanvaAOuvrir.blocksRaycasts = false;
        canFelicitation.alpha = 0;
        canFelicitation.blocksRaycasts = false;


        reglage.transform.gameObject.SetActive(false);
    }



    public void OnClickVerifier()
    {
        Text duTexte = GameObject.FindGameObjectWithTag("txtQuestion").GetComponent<Text>();
        Dropdown choixItem3 = GameObject.FindGameObjectWithTag("listeReponses").GetComponent<Dropdown>();
        CanvasGroup CanvaAOuvrir = GameObject.FindGameObjectWithTag("felicitation").GetComponent<CanvasGroup>();
        CanvasGroup CanMauvais = GameObject.FindGameObjectWithTag("txtMauvais").GetComponent<CanvasGroup>();


        switch (duTexte.name)
        {
            case "1":
                if(choixItem3.options[choixItem3.value].text == "Réponses possibles") { CanMauvais.alpha = 0; break; }
                else if (choixItem3.options[choixItem3.value].text == "Un filet")
                {
                    CanvaAOuvrir.alpha = 1;
                    CanMauvais.alpha = 0;
                    CanvaAOuvrir.blocksRaycasts = true;
                }
                else
                {
                    CanMauvais.alpha = 1;
                }

                break;
            case "2":
                if (choixItem3.options[choixItem3.value].text == "Réponses possibles") { CanMauvais.alpha = 0; break; }
                else if (choixItem3.options[choixItem3.value].text == "Une chaise")
                {
                    CanvaAOuvrir.alpha = 1;
                    CanMauvais.alpha = 0;
                    CanvaAOuvrir.blocksRaycasts = true;
                }
                else
                {
                    CanMauvais.alpha = 1;
                }

                break;
            case "3":
                if (choixItem3.options[choixItem3.value].text == "Réponses possibles") { CanMauvais.alpha = 0; break; }
                else if (choixItem3.options[choixItem3.value].text == "1")
                {
                    CanvaAOuvrir.alpha = 1;
                    CanMauvais.alpha = 0;
                    CanvaAOuvrir.blocksRaycasts = true;
                }
                else
                {
                    CanMauvais.alpha = 1;
                }

                break;
            case "4":
                if (choixItem3.options[choixItem3.value].text == "Réponses possibles") { CanMauvais.alpha = 0; break; }
                else if (choixItem3.options[choixItem3.value].text == "3")
                {
                    CanvaAOuvrir.alpha = 1;
                    CanMauvais.alpha = 0;
                    CanvaAOuvrir.blocksRaycasts = true;
                }
                else
                {
                    CanMauvais.alpha = 1;
                }

                break;
            case "5":

                if (choixItem3.options[choixItem3.value].text == "Réponses possibles") { CanMauvais.alpha = 0; break; }
                else if (choixItem3.options[choixItem3.value].text == "Le soleil")
                {
                    CanvaAOuvrir.alpha = 1;
                    CanMauvais.alpha = 0;
                    CanvaAOuvrir.blocksRaycasts = true;
                }
                else
                {
                    CanMauvais.alpha = 1;
                }
                break;
            case "6":

                if (choixItem3.options[choixItem3.value].text == "Réponses possibles") { CanMauvais.alpha = 0; break; }
                else if (choixItem3.options[choixItem3.value].text == "Du pain")
                {
                    CanvaAOuvrir.alpha = 1;
                    CanMauvais.alpha = 0;
                    CanvaAOuvrir.blocksRaycasts = true;
                }
                else
                {
                    CanMauvais.alpha = 1;
                }
                break;
            case "7":

                if (choixItem3.options[choixItem3.value].text == "Réponses possibles") { CanMauvais.alpha = 0; break; }
                else if (choixItem3.options[choixItem3.value].text == "Son ombre")
                {
                    CanvaAOuvrir.alpha = 1;
                    CanMauvais.alpha = 0;
                    CanvaAOuvrir.blocksRaycasts = true;
                }
                else
                {
                    CanMauvais.alpha = 1;
                }
                break;
            case "8":
                if (choixItem3.options[choixItem3.value].text == "Réponses possibles") { CanMauvais.alpha = 0; break; }
                else if (choixItem3.options[choixItem3.value].text == "Un nez")
                {
                    CanvaAOuvrir.alpha = 1;
                    CanMauvais.alpha = 0;
                    CanvaAOuvrir.blocksRaycasts = true;
                }
                else
                {
                    CanMauvais.alpha = 1;
                }
                break;

            default:
                break;
        }


    }
}
