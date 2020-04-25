using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{

    public GameObject owner;
    public GameObject player;
    public GameObject fake_parent;
    public float speed;

    private Vector3 vector;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = owner.transform.position;
        vector = player.transform.position - gameObject.transform.position;
        vector = vector.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += vector * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            //Create fake parent to apply root motion without TP-ing into the center of the map.
            fake_parent.transform.position = player.transform.position;
            player.transform.parent = fake_parent.transform;
            player.GetComponent<Animator>().applyRootMotion = false;

            //Die animation + other staff
            player.GetComponent<Animator>().SetTrigger("die");
        }
        else
        {
            if (!(collision.gameObject == owner))
            {
                Destroy(gameObject);
            }
        }
    }
}
