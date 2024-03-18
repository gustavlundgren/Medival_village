using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out Target target))
        {
            if (!target.GetInteractableObject())
            {
                target.SpawnKey();
            }

            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            StartCoroutine(despawn());

        }

    }

    IEnumerator despawn()
    {
        yield return new WaitForSecondsRealtime(2);

        Destroy(gameObject);
    }
}
