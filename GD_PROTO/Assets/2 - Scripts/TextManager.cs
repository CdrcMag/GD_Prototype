using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI mainText;

    private char[] c = new char[0];

    public float ecart;

    private void Awake()
    {
        string baseText = mainText.text;
        mainText.text = "";

        c = baseText.ToCharArray();


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(IDisplayLetters(c));

            EyesManager.Instance.ChangeEyeOffset(EyesManager.EyePosition.happy);
        }
    }

    IEnumerator IDisplayLetters(char[] c)
    {

        for(int i = 0; i < c.Length; i++)
        {
            mainText.text += c[i];
            yield return new WaitForSeconds(ecart);
        }

        
    }



}
