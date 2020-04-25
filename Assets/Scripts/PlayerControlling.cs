using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControlling : MonoBehaviour
{

    public float speed_X = 4f;
    public float jump_speed = 4f;

    private Rigidbody2D rb2D;
    private int available_jumps = 2;

    private bool getKeyDownSpace = false;
    private Animator animator;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetInteger("Level", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    private void Update()
    {
        //Getting enter pushed down and do the physics in the FixedUpdate().
        if (Input.GetKeyDown(KeyCode.Space))
        {
            getKeyDownSpace = true;
        }
        else
        {
            getKeyDownSpace |= false;
        }
    }

    private void FixedUpdate()
    {
        //Jump resets
        if (rb2D.velocity.y == 0)
        {
            available_jumps = 2;
            animator.SetBool("jump", false);
        }

        //Move RIGHT
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed_X * Time.deltaTime, 0, 0);
        }

        //Move LEFT
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed_X * Time.deltaTime, 0, 0);
        }
        
        //Jump physics
        if (getKeyDownSpace)
        {
            getKeyDownSpace = false;

            if (available_jumps > 0) {
                rb2D.velocity = Vector3.zero;
                rb2D.AddForce(transform.up * jump_speed, ForceMode2D.Impulse);
                available_jumps--;
                animator.SetBool("jump", true);
            }
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) &&
           !(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }
}
