using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private InteractableObjectSO interactableObjectSO;

    private IInteractableObjectParent interactableObjectParent;

    public InteractableObjectSO GetInteractableObjectSO() { return interactableObjectSO; } 

    public void SetInteractableObjectParent(IInteractableObjectParent interactableObjectParent) 
    { 
        if(this.interactableObjectParent != null)
        {
            this.interactableObjectParent.ClearInteractableObject();
        }

        this.interactableObjectParent = interactableObjectParent;

        if(interactableObjectParent.HasInteractableObject())
        {
            Debug.LogError("IInteractableObjectParent already has a interactable Object");
        }

        interactableObjectParent.SetInteractableObject(this);

        transform.parent = interactableObjectParent.GetInteractableObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IInteractableObjectParent GetInteractableObjectParent() { return interactableObjectParent; }
}
