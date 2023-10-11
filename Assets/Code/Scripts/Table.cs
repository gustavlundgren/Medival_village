using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour, IInteractableObjectParent
{
    [SerializeField] private Transform TableTopPoint;

    private InteractableObject interactableObject;

    public void Interact(PlayerController player)
    {
        if (!HasInteractableObject())
        {
            if(player.HasInteractableObject())
            {
                player.GetInteractableObject().SetInteractableObjectParent(this);
            } 
        } 
        else
        {
            if(!player.HasInteractableObject())
            {
                GetInteractableObject().SetInteractableObjectParent(player);
            }
        }
    }

    public Transform GetInteractableObjectFollowTransform()
    {
        return TableTopPoint;
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
}
