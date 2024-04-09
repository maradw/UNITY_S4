using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D m_RDB;
    private float velocity = 5f;
    // Start is called before the first frame update
    private void Awake()
    {
        m_RDB = GetComponent<Rigidbody2D>();

    }
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "animal")
        {
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "ogre")
        {
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "wizard")
        {
            Destroy(this.gameObject);
        }

    }
    private void FixedUpdate()
    {
        m_RDB.velocity = new Vector2(velocity * 1, 0);
    }           
                                    



}