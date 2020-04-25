using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSawsScript : MonoBehaviour
{

    public GameObject saw;
    public GameObject player;
    public GameObject fake_parent;
    public float saw_speed;
    public float delay;

    private float last_instantiate;

    void Start()
    {
        last_instantiate = Time.time;
    }

    void Update()
    {
        if(Time.time - last_instantiate > delay)
        {
            var sawGO = Instantiate(saw) as GameObject;
            sawGO.GetComponent<SawScript>().owner = gameObject;
            sawGO.GetComponent<SawScript>().player = player;
            sawGO.GetComponent<SawScript>().speed = saw_speed;
            sawGO.GetComponent<SawScript>().fake_parent = fake_parent;
            last_instantiate = Time.time;
        }
    }
}
