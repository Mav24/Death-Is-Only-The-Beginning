using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletsCtrl : MonoBehaviour
{
    [SerializeField] float speed = 40f;
    [SerializeField] Rigidbody bulletrb;


    PlayerCtrl player;

    Vector2 movement;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerCtrl>();
        movement = (player.transform.position - transform.position).normalized * speed;

    }
    // Update is called once per frame
    void Update()
    {
        bulletrb.velocity = new Vector2(movement.x, movement.y);
        
       
        //transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
