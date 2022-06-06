using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesManager : MonoBehaviour
{
    public static EyesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum EyePosition { normal, happy, angry, dead }

    //Eyes renderer
    public Renderer eyes;

    public void ChangeEyeOffset(EyePosition pos)
    {
        Vector2 offset = Vector2.zero;

        switch (pos)
        {
            case EyePosition.normal:
                offset = new Vector2(0, 0);
                break;
            case EyePosition.happy:
                offset = new Vector2(.33f, 0);
                break;
            case EyePosition.angry:
                offset = new Vector2(.66f, 0);
                break;
            case EyePosition.dead:
                offset = new Vector2(.33f, .66f);
                break;
            default:
                break;
        }

        eyes.material.SetTextureOffset("_BaseMap", offset);

    }
}


