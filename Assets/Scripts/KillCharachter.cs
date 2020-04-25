using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KillCharachter : MonoBehaviour
{
    public GameObject player;
    public GameObject fake_parent;

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
    }
}
