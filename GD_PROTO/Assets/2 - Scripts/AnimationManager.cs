using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    public Animator playerAnimator;

    public void PlayAnim(string name)
    {
        playerAnimator.SetTrigger(name);
    }





}
