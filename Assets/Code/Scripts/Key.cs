using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = PlayerController.Instance;
    }

    private void Update()
    {
        //transform.position = player.GetInteractableObjectFollowTransform().position;
        //transform.localPosition = Vector3.zero;
    }
}
