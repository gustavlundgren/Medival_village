using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractableObjectParent
{
    [SerializeField] private InteractableObjectSO interactableObjectSO;
    [SerializeField] private Transform chestTopPoint;

    [SerializeField] private Animator animator;



    private bool isOpened;
    private InteractableObject interactableObject;



    public void Interact(PlayerController player)
    {
        if (interactableObject == null && !isOpened)
        {
            animator.SetTrigger("Open");

            Transform interactableObjectTransform = Instantiate(interactableObjectSO.prefab, chestTopPoint);
            interactableObjectTransform.GetComponent<InteractableObject>().SetInteractableObjectParent(this);

            isOpened = true;
        }
        else if (!player.HasInteractableObject())
        {
            interactableObject.SetInteractableObjectParent(player);
        }
    }

    public Transform GetInteractableObjectFollowTransform()
    {
        return chestTopPoint;
    }

    public void SetInteractableObject(InteractableObject interactableObject)
    {
        this.interactableObject = interactableObject;
    }

    public InteractableObject GetInteractableObject()
    {
        return interactableObject;
    }

    public void ClearInteractableObject()
    {
        interactableObject = null;
    }

    public bool HasInteractableObject()
    {
        return interactableObject != null;
    }

    public bool ChestIsOpen()
    {
        return isOpened;
    }
}
