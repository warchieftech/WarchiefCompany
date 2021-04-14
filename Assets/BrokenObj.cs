using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObj : MonoBehaviour
{
    void Start()
    {
        Invoke("Fin", 1);
    }
    void Fin()
    {
        Destroy(transform.gameObject);
    }
}
