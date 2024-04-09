using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreController : MonoBehaviour
{
    float velocity= 3f;
    [SerializeField] private Rigidbody2D myRBDOgre;
    [SerializeField] private GameObject player;
    bool isEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
            myRBDOgre = GetComponent<Rigidbody2D>(); 

    }

 
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.tag == "Player")
        {
            isEnter = true;
            //myRBDOgre.velocity = new Vector2(velocity * 1, velocity * 1);
            FollowChracter();
        }
        else
        {
            isEnter = false;
        }


    }
    private void FixedUpdate()
    {
       
    }
    void FollowChracter()
    {
        myRBDOgre.position = Vector2.MoveTowards(transform.position, player.transform.position, velocity * Time.deltaTime);
    }
}
