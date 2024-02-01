using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] Transform arrowPrefab;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    public void Shoot(Transform holdpoint, Vector2 currentSpeed)
    {

        print(currentSpeed);

        if (currentSpeed == Vector2.zero)
        {
            float distanceInFront = 0.4f;
            Vector3 targetPosition = holdpoint.position + holdpoint.forward * distanceInFront;

            Transform arrow = Instantiate(arrowPrefab, targetPosition, cameraTransform.rotation);
            Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();

            arrowRigidbody.AddForce(cameraTransform.forward * 1f, ForceMode.Impulse);
        }
    }
}
