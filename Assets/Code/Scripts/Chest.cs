using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractableObjectParent
{
    [SerializeField] private InteractableObjectSO interactableObjectSO;
    [SerializeField] private Transform chestTopPoint;

    [SerializeField] private Chest secondChest;
    [SerializeField] private bool testing;


    private InteractableObject interactableObject;

    private void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.T)) {
            if(interactableObject != null)
            {
                interactableObject.SetInteractableObjectParent(secondChest);
            }
        }
        
    }

    public void Interact(PlayerController player)
    {
        if (interactableObject == null)
        {
            Transform interactableObjectTransform = Instantiate(interactableObjectSO.prefab, chestTopPoint);
            interactableObjectTransform.GetComponent<InteractableObject>().SetInteractableObjectParent(this);
        } else if(!player.HasInteractableObject())
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
}
