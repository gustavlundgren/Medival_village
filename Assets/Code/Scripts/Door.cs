using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField] private bool isRotatingDoor= true;
    [SerializeField] private float speed= 1f;

    [Header("Rotation Configs")]
    [SerializeField] float rotationAmount = 90f;
    [SerializeField] float forwardDirection = 0f;

    private Vector3 startingRotation;
    private Vector3 forward;

    private Coroutine animationCoroutine;

    private void Awake()
    {
        startingRotation = transform.rotation.eulerAngles;
        // Motverka bugg med att man inte kan veta vilken sida av dörren som spelaren står på
        forward = transform.right;
    }

    public void Open(Vector3 playerPosition)
    {
        if (!isOpen)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }

            if(isRotatingDoor)
            {
                float dot = Vector3.Dot(forward, (playerPosition - transform.position).normalized);
                Debug.Log($"Dot: {dot.ToString("N3")}");
                animationCoroutine = StartCoroutine(doRotationOpen(dot));
            }
        }
    }

    private IEnumerator doRotationOpen(float forwardAmount)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if(forwardAmount >= forwardDirection)
        {
            endRotation = Quaternion.Euler(new Vector3(0, startingRotation.y - rotationAmount, 0));
        }
        else
        {
            endRotation = Quaternion.Euler(new Vector3(0, startingRotation.y + rotationAmount, 0));
        }

        isOpen = true;

        float time = 0f;

        while(time<1) 
        { 
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, (float)time);
            yield return null;
            
            time += Time.deltaTime * speed;
        }
    }

    public void Close()
    {
        if(isOpen)
        {
            if(animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            if (isRotatingDoor)
            {
                animationCoroutine = StartCoroutine(doRotationClose());
            }

            isOpen= false;
        }
    }

    private IEnumerator doRotationClose()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(startingRotation);

        float time = 0f;
        while(time<1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation,(float)time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }
}
