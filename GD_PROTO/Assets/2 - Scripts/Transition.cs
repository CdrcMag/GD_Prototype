using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public float speed = 1;

    public bool open;

    private IEnumerator Start()
    {
        //if(open)
        //{
        //    StartCoroutine(IOpen());
        //}
        //else
        //{
        //    StartCoroutine(IClose());
        //}

        yield return new WaitForSeconds(1f);

        if (open)
            StartCoroutine(IFade());
        else
            StartCoroutine(IFadeOut());
    }

    private IEnumerator IOpen()
    {
        
        yield return null;
    }

    private IEnumerator IClose()
    {
        transform.localScale = new Vector2(1, 1);

        while (transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x-speed, transform.localScale.y - speed);

            yield return null;
        }
            
    }

    public IEnumerator IFade()
    {
        Image i = GetComponent<Image>();

        while (i.color.a > 0)
        {
            i.color = new Color(i.color.r, i.color.r, i.color.b, i.color.a-speed);

            yield return null;
        }

        i.color = new Color(i.color.r, i.color.r, i.color.b, 0);
        i.enabled = false;
    }

    public IEnumerator IFadeOut()
    {
        Image i = GetComponent<Image>();
        i.enabled = true;
        while (i.color.a < 1)
        {
            i.color = new Color(i.color.r, i.color.r, i.color.b, i.color.a + speed);

            yield return null;
        }

        i.color = new Color(i.color.r, i.color.r, i.color.b, 1);
    }
}
