using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtil : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToinstantiate;

    public void InstantiateObject()
    {
        Instantiate(objectToinstantiate);
    }
}
