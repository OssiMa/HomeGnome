using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edge : MonoBehaviour {

    public GameObject other;
    public Vector3 offset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = other.transform.position - offset;
    }
}
