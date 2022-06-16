using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public TextMeshProUGUI t;

    public Image currentSpectre;

    private int currentSpectreId;

    public Sprite[] spectres = new Sprite[0];
    public Image[] spectresEmission = new Image[0];
    public Sprite[] spectresEmissionStock = new Sprite[0];
    public Image[] EtoilesFaites = new Image[0];

    //Bonnes réponses
    public string[] goodAnswers = new string[3];

    public GameObject[] etoiles;



    private void Start()
    {
        t.text = "";

        PointerEnterImage(0);


    }

    public void PointerEnterImage(int id)
    {
        int a = id + 1;
        t.text = "Etude : étoile " + a;

        currentSpectre.sprite = spectres[id];
        currentSpectreId = id;

        AssignNewAnswers(id);

    }

    public void AssignNewElement(string s)
    {
        Image i = null;

        if (spectresEmission[0].sprite.name == "Background") i = spectresEmission[0];
        else if (spectresEmission[1].sprite.name == "Background") i = spectresEmission[1];
        else if (spectresEmission[2].sprite.name == "Background") i = spectresEmission[2];

        if(i == null) i = spectresEmission[0];

        //print("Slot libre : " + i.name);

        switch(s)
        {
            case "Hydrogene": i.sprite = spectresEmissionStock[3]; break;
            case "Argon": i.sprite = spectresEmissionStock[1]; break;
            case "Fer": i.sprite = spectresEmissionStock[2]; break;
            case "Mercure": i.sprite = spectresEmissionStock[4]; break;
            case "Sodium": i.sprite = spectresEmissionStock[5]; break;
            case "Titane": i.sprite = spectresEmissionStock[6]; break;

        }

    }

    public void DeleteElement(int id)
    {
        spectresEmission[id].sprite = spectresEmissionStock[0];
    }

    private void AssignNewAnswers(int id)
    {
        if(id == 0)
        {
            goodAnswers[0] = "Sodium";
            goodAnswers[1] = "Fer";
            goodAnswers[2] = "";
        }
        if (id == 1)
        {
            goodAnswers[0] = "Hydrogene";
            goodAnswers[1] = "Argon";
            goodAnswers[2] = "";
        }
        if (id == 2)
        {
            goodAnswers[0] = "Fer";
            goodAnswers[1] = "Argon";
            goodAnswers[2] = "Titane";
        }
    }

    public void Valider()
    {
        bool resultat = false;

        string first = spectresEmission[0].sprite.name;
        string second = spectresEmission[1].sprite.name;
        string third = spectresEmission[2].sprite.name;

        bool firstAnswerState = false;
        bool secondAnswerState = false;
        bool thirdAnswerState = false;

        if(first == goodAnswers[0] || first == goodAnswers[1] || first == goodAnswers[2])
        {
            firstAnswerState = true;
        }
        if (second == goodAnswers[0] || second == goodAnswers[1] || second == goodAnswers[2])
        {
            secondAnswerState = true;
        }
        
        if (third == goodAnswers[0] || third == goodAnswers[1] || third == goodAnswers[2])
        {
            thirdAnswerState = true;
        }
        if (goodAnswers[2] == "" && third == "Background")
        {
            thirdAnswerState = true;
        }
        print(firstAnswerState + " " + secondAnswerState + " " + thirdAnswerState);

        if (firstAnswerState && secondAnswerState && thirdAnswerState)
        {
            
            resultat = true;
        }

        print(resultat);

        if(resultat)
        {
            ResultatCorrect();
        }
        else
        {
            ResultatIncorrect();
        }
    }

    private void ResultatCorrect()
    {
        //Reset les spectres
        foreach (Image i in spectresEmission)
            i.sprite = spectresEmissionStock[0];

        //Afficher correct

        //Delete l'étoile
        Destroy(etoiles[currentSpectreId]);

        EtoilesFaites[currentSpectreId].color = new Color32(0x69, 0xC8, 0x72, 0x92);

        //Update le nbr total d'étoiles faites
        //Deselectionner etoile
        currentSpectre.sprite = spectresEmissionStock[0];

    }

    private void ResultatIncorrect()
    {

    }

}
