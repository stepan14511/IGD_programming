using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestOpenning : MonoBehaviour
{

    public GameObject player;
    public GameObject key_picked_up_shower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject == player) && (key_picked_up_shower.activeSelf))
        {
            Animator anim = gameObject.GetComponent<Animator>();

            anim.SetBool("open", true);
        }
    }
}
