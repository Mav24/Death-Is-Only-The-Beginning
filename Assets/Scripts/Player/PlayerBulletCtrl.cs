using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCtrl : MonoBehaviour
{
    [SerializeField] float speed = 40;


    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
