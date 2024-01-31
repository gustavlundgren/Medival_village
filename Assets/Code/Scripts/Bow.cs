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

    private void Update()
    {
        //Quaternion rotation = Quaternion.Euler(0, cameraTransform.rotation.y, cameraTransform.rotation.z * -100);

        //if(PlayerController.Instance.GetInteractableObject() == this)
        //{
            
        //}
    }

    public void Shoot(Transform holdpoint)
    {

        // Hitta en position lite framför bågen så att det inte sker en krock mellan bågen och pilen när den startar
        float distanceInFront = 0.4f;
        Vector3 targetPosition = holdpoint.position + holdpoint.forward * distanceInFront;

        Transform arrow = Instantiate(arrowPrefab, targetPosition, cameraTransform.rotation);
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();

        arrowRigidbody.AddForce(cameraTransform.forward * 1f, ForceMode.Impulse);
    }
}
