using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Movement : MonoBehaviour

{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D box;

    [SerializeField]private LayerMask jumpableGround;

    private float drirx = 0f;
    private float movespeed = 7f;
    private float jumpspeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        drirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(drirx * movespeed , rb.velocity.y,0);
        if (Input.GetKeyDown("space") && grounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpspeed,0);
        }
        updateanimation();
        
    }
    private void updateanimation(){
        if(drirx>0f){
            anim.SetBool("running",true);
            sprite.flipX = false;
        }
        else if(drirx<0f){
            anim.SetBool("running",true);
            sprite.flipX = true;
        }
        else{
            anim.SetBool("running",false);
        }
    }

    private bool grounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector3.down, .1f, jumpableGround);
    }


}
