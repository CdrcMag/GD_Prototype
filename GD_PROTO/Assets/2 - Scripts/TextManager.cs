using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI compteur;

    public GameObject fleche;

    private char[] c = new char[0];

    public float ecart;

    [TextArea(5, 10)]
    public string[] texts = new string[3];
    private int currentId = 0;
    private bool isWriting = false;
    private bool isDone = false;

    private void Awake()
    {
        mainText.text = "";
        StartCoroutine(IDisplayLetters(c, currentId));
        UpdateCpt();
        

        if (currentId + 1 < texts.Length)
            currentId++;

       
    }

    private void Start()
    {
        EyesManager.Instance.ChangeEyeOffset(EyesManager.EyePosition.happy);
    }

    private void UpdateCpt()
    {
        compteur.text = $"{currentId+1}/{texts.Length}";
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isWriting && !isDone)
        {
            StartCoroutine(IDisplayLetters(c, currentId));

            AddOn();

            if(currentId + 1 < texts.Length)
                currentId++;

        }
    }



    IEnumerator IDisplayLetters(char[] c, int id)
    {
        fleche.SetActive(false);
        UpdateCpt();

        isWriting = true;

        string baseText = texts[id];
        mainText.text = "";

        c = baseText.ToCharArray();


        for (int i = 0; i < c.Length; i++)
        {
            mainText.text += c[i];
            yield return new WaitForSeconds(ecart);
        }

        fleche.SetActive(true);
        isWriting = false;

        if (id == texts.Length-1)
            isDone = true;


        
    }

    private void AddOn()
    {
        if(currentId == 1)
        {
            EyesManager.Instance.ChangeEyeOffset(EyesManager.EyePosition.normal);
            AnimationManager.Instance.PlayAnim("Idle");
        }


        if(currentId == 2)
        {
            isWriting = true;
            AI_Manager.Instance.GoToPosition(0);
            CameraManager.Instance.GoToPosition();
            AnimationManager.Instance.PlayAnim("Walk");
        }
    }

}
