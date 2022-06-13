using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    //Camera target position
    public Vector3 targetPosition;

    //Camera's movement speed to reach target
    public float cameraMovementSpeed;

    //if the camera is moving
    private bool isMoving = false;

    private void Awake()
    {
        Instance = this;
    }

    [ContextMenu("Go to position")]
    public void GoToPosition()
    {
        if (isMoving)
            return;

        isMoving = true;

        StartCoroutine(IMove());

    }

    IEnumerator IMove()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            //transform.position = Vector3.Lerp(transform.position, targetPosition, 1 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, cameraMovementSpeed * Time.deltaTime);

            yield return null;
        }

        transform.position = targetPosition;

        isMoving = false;
    }



   
}
