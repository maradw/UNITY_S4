using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovementController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform[] checkpointsPatrol;
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float velocityModifier = 1f;
    [SerializeField] private float rayDistance;
    private Transform currentPositionTarget;
    private int patrolPos = 0;


    private void Start() {
        currentPositionTarget = checkpointsPatrol[patrolPos];
        transform.position = currentPositionTarget.position;
    }
    private void Awake()
    {
        
    }

    private void Update() {
        CheckNewPoint();

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);
    }

    private void CheckNewPoint(){
        if(Mathf.Abs((transform.position - currentPositionTarget.position).magnitude) < 0.25){
            patrolPos = patrolPos + 1 == checkpointsPatrol.Length? 0: patrolPos+1;
            currentPositionTarget = checkpointsPatrol[patrolPos];
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized*velocityModifier;
            CheckFlip(myRBD2.velocity.x);
        }

        Debug.DrawRay(transform.position, (currentPositionTarget.position - transform.position).normalized * velocityModifier*rayDistance, Color.magenta);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (currentPositionTarget.position - transform.position).normalized * velocityModifier * rayDistance, rayDistance);

        
        if (hit.collider.tag == "Player")
        {
            
            Debug.Log("Hitting: " + hit.collider.tag);
            myRBD2.velocity = (currentPositionTarget.position - transform.position) * 2;
          // transform.position = 
            
        }

       
    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
}
