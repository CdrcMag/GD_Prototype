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
    public bool isDone = false;

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

        for(int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
    }

    private void UpdateCpt()
    {
        compteur.text = $"{currentId+1}/{texts.Length}";
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isWriting && !isDone)
        {
            Main();
        }
    }

    public void Main()
    {
        StartCoroutine(IDisplayLetters(c, currentId));

        AddOn();

        if (currentId + 1 < texts.Length)
            currentId++;
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
            AI_Manager.Instance.GoToPosition(0);
            CameraManager.Instance.GoToPosition();
            AnimationManager.Instance.PlayAnim("Walk");
            isDone = true;
            fleche.SetActive(false);
        }
        if (currentId == 4)
        {
            images[3].SetActive(true);
        }

        if (currentId == 6)
        {
            images[3].SetActive(false);
            images[0].SetActive(true);
            AnimationManager.Instance.PlayAnim("Pump");
        }

        if (currentId == 11)
        {
            images[0].SetActive(false);
        }

        if (currentId == 12)
        {
            AnimationManager.Instance.PlayAnim("Pump");
            images[1].SetActive(true);
        }
        if (currentId == 13)
        {
            images[2].SetActive(true);
        }

        if (currentId == 15)
        {
            AnimationManager.Instance.PlayAnim("Pump");
        }
    }

    

    public GameObject[] images = new GameObject[0];
}
