using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);

        StartCoroutine(despawn());
    }

    IEnumerator despawn()
    {
        yield return new WaitForSecondsRealtime(2);

        Destroy(gameObject);
    }
}
