using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootCtrl : MonoBehaviour
{
    [SerializeField] float speed = 40f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
