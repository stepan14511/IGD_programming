using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderEnemies : MonoBehaviour
{
    public GameObject node1;
    public GameObject node2;
    public float speed;

    private GameObject last_node;
    private GameObject next_node;
    private Vector3 last_vector;

    private void Start()
    {
        transform.position = node1.transform.position;
        last_node = node1;
        next_node = node2;
        last_vector = next_node.transform.position - transform.position;
        last_vector = last_vector.normalized;
    }

    private void FixedUpdate()
    {
        Vector3 vector = next_node.transform.position - transform.position;
        vector = vector.normalized;

        if((last_vector != vector) || vector == Vector3.zero)
        {
            GameObject temp = next_node;
            next_node = last_node;
            last_node = temp;

            last_vector = next_node.transform.position - transform.position;
            last_vector = last_vector.normalized;
        }
        else
        {
            transform.position += vector * speed * Time.deltaTime;
            last_vector = vector;
        }

    }
}