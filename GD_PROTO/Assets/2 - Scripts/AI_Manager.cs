using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Manager : MonoBehaviour
{
    public static AI_Manager Instance;

    //Player
    public NavMeshAgent agent;

    public Transform[] targets = new Transform[0];
    public float rotateSpeed;

    private bool mainState = false;

    private void Awake()
    {
        Instance = this;
    }

    public void GoToPosition(int id)
    {
        mainState = true;
        agent.destination = targets[id].position;
    }

    private void Update()
    {
    

        if (mainState && agent.remainingDistance < 0.1f)
        {
            AnimationManager.Instance.PlayAnim("Idle");
            StartCoroutine(RotateT());
            mainState = false;
        }
    }

    IEnumerator RotateT()
    {
        while(agent.transform.rotation.eulerAngles.y < 211)
        {
            agent.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            yield return null;
        }

        agent.transform.rotation = Quaternion.Euler(0, 211, 0);
    }



}
