using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        if(EyesManager.Instance)
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
            if (EyesManager.Instance) EyesManager.Instance.ChangeEyeOffset(EyesManager.EyePosition.normal);
            if(AnimationManager.Instance) AnimationManager.Instance.PlayAnim("Idle");
        }


        if(currentId == 2)
        {
            if (AI_Manager.Instance) AI_Manager.Instance.GoToPosition(0);
            if (CameraManager.Instance) CameraManager.Instance.GoToPosition();
            if (AnimationManager.Instance) AnimationManager.Instance.PlayAnim("Walk");
            isDone = true;
            fleche.SetActive(false);
        }
        if (currentId == 4)
        {
            if(images.Length > 0) images[3].SetActive(true);
        }

        if (currentId == 6)
        {
            if (images.Length > 0) images[3].SetActive(false);
            if (images.Length > 0) images[0].SetActive(true);
            if (AnimationManager.Instance) AnimationManager.Instance.PlayAnim("Pump");
        }

        if (currentId == 11)
        {
            if (images.Length > 0) images[0].SetActive(false);
        }

        if (currentId == 12)
        {
            if (AnimationManager.Instance) AnimationManager.Instance.PlayAnim("Pump");
            if (images.Length > 0) images[1].SetActive(true);
        }
        if (currentId == 13)
        {
            if (images.Length > 0) images[2].SetActive(true);
        }

        if (currentId == 15)
        {
            
        }

        if(currentId == 16)
        {
            if (AnimationManager.Instance) AnimationManager.Instance.PlayAnim("Pump");

            StartCoroutine(IWait());

        }
    }

    IEnumerator IWait()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(t.IFadeOut());
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public Transition t;

    public GameObject[] images = new GameObject[0];
}
