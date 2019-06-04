using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float jumpForce;
    public bool grounded;
    private Rigidbody2D rb;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * 0.1f;
        //gå fram och bak
        anim.SetFloat("Speed",x);
        rb.MovePosition(rb.position + new Vector2(x, 0));
        //hoppa 
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && grounded == true)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    //kan hoppa om man är på marken
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            grounded = !false;
        }
    }

    //kan inte hoppa om man är i luften
    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            grounded = !true;
        }
    }
}
