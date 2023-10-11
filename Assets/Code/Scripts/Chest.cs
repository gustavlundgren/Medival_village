using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject key;


    public void Open()
    {
        Instantiate(key,new Vector3(transform.position.x, 1, transform.position.z), transform.rotation);
    }
}
