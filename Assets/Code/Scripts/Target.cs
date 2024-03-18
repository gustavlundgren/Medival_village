using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IInteractableObjectParent
{
    [SerializeField] private Transform keyPos;
    [SerializeField] private InteractableObjectSO interactableObjectSO;
    private InteractableObject interactableObject;

    public void Interact(PlayerController player)
    {
        print(player.HasInteractableObject());

        if (!player.HasInteractableObject())
        {
            interactableObject.SetInteractableObjectParent(player);
        }
    }

    public void SpawnKey()
    {
        if (!HasInteractableObject())
        {
            Transform interactableObjectTransform = Instantiate(interactableObjectSO.prefab, keyPos);

            interactableObjectTransform.GetComponent<InteractableObject>().SetInteractableObjectParent(this);
        }
    }

    public Transform GetInteractableObjectFollowTransform()
    {
        return keyPos;
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
