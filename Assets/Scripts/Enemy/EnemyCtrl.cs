using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootDelay = .5f;

    public bool canShoot = true;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("EndPoint");
    }
    private void Update()
    {
        if (canShoot)
        {
            StartCoroutine(Shoot());
            canShoot = false;
        }
        

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * moveSpeed);
    }

    IEnumerator Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;

        
    }
}
