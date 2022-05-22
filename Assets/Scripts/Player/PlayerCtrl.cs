using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrl : MonoBehaviour, Controls.IPlayerActions
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float movementSpeed;
    [SerializeField] GameObject bullet;

    private Vector2 movementValue;
    private Controls controls;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(movementValue.x, movementValue.y, 0) * movementSpeed;
    }
    private void Update()
    {
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementValue = context.ReadValue<Vector2>();
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(bullet,transform.position, Quaternion.identity);
        }
    }

    













    
} // Class

