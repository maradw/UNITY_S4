using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    //[SerializeField] private Rigidbody2D bulletRGB;
    public GameObject bullet;
    //public GameObject bullet2;
    private float _horizontal;
    private float _vertical;
    float velocity = 5f;
    //public UnityEvent Onclick;

    public static event Action<int> OnPlayerDamaged;

    private void Update() {

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);

        Vector2 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        CheckFlip(mouseInput.x);
    
        Debug.DrawRay(transform.position, mouseInput.normalized * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0)){

            Debug.Log("Left Click");

          
            //Instantiate(bullet2, transform.position, transform.rotation);
        }
        else if(Input.GetMouseButtonDown(1)){
            Debug.Log("Right Click");
           

            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
    public void OnMovement(InputAction.CallbackContext move)
    {
       
        _horizontal = move.ReadValue<Vector2>().x;
       _vertical = move.ReadValue<Vector2>().y;
    }
    public void FixedUpdate()
    {
        myRBD2.velocity = new Vector2(_horizontal * velocityModifier, _vertical * velocityModifier);
    }
    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "animal")
        {
            OnPlayerDamaged?.Invoke(1);

        }
        else if (collision.gameObject.tag == "ogre")
        {
            OnPlayerDamaged?.Invoke(2);

        }
        else if (collision.gameObject.tag == "wizard")
        {
            OnPlayerDamaged?.Invoke(3);
        }

    }
}
