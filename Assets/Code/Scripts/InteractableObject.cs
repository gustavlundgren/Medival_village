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

        if (this.interactableObjectSO.objectName == "Bow")
        {
            Quaternion rot = Quaternion.Euler(new Vector3(0,-90,0));
            transform.localPosition = new Vector3(0.35f, 0.3f, -0.2f);
            transform.localRotation = rot;
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }

    public IInteractableObjectParent GetInteractableObjectParent() { return interactableObjectParent; }
}
