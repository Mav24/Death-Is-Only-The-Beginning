using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    [SerializeField] float delay = 1f;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, delay);
    }
}
