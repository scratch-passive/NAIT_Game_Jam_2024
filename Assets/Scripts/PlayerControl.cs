using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public Vector2 moveVal = new(0, 0);
    public float moveSpeed = 1;
    private Animator anim;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveVal.x, moveVal.y) * moveSpeed;
        /*
        // old way of moving
        // only move if the input isn't 0
        if(moveVal.x != 0 || moveVal.y != 0)
        {
            transform.Translate(moveSpeed * Time.deltaTime * new Vector3(1, 0, 0));
        }
        */
    }

    // called from the player input component "send messages" whenever the player presses a movement key
    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
        //Debug.Log(moveVal);
        // convert the direction to an angle to move

        if(moveVal.x != 0 || moveVal.y != 0)
        {
            float rotation_angle = Mathf.Atan2(moveVal.y, moveVal.x) * Mathf.Rad2Deg;
            //Debug.Log("Rotation angle: " + rotation_angle + ", Right: " + transform.right + ", Up: " + transform.up);
            transform.rotation = Quaternion.Euler(0, 0, rotation_angle);
            //anim.Play("Move");
            // starts the moving animation
            anim.SetBool("IsMoving", true);
        }
        else
        {
            // stops the moving animation
            anim.SetBool("IsMoving", false);
        }
    }
}
