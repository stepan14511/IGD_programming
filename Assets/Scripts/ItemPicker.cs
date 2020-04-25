using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{

    public GameObject picker;
    public GameObject itemCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == picker) {
            Destroy(gameObject);
            itemCounter.SetActive(true);
        }
    }
}