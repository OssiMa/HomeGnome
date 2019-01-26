using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guy : MonoBehaviour {

    public bool atDoor = false;
    public bool inHouse = false;
    public GameObject house;

    GameObject sprite;
    bool firstRotation = false;
    float rotationCD = 0;

    private void Start()
    {
        sprite = transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && inHouse == false)
        {
            gameObject.transform.position = transform.position + new Vector3(-0.2f, 0, 0);
            Rotate();
        }
        else if (Input.GetKey(KeyCode.RightArrow) && inHouse == false)
        {
            gameObject.transform.position = transform.position + new Vector3(0.2f, 0, 0);
            Rotate();
        }
        else
        {
            sprite.transform.rotation = new Quaternion(0,0,0,0);
        }


        if(Input.GetKey(KeyCode.UpArrow) && atDoor == true)
        {
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            house.transform.GetChild(0).gameObject.SetActive(true);
            inHouse = true;
        }
        if (Input.GetKey(KeyCode.DownArrow) && inHouse == true)
        {
            GetComponentInChildren<SpriteRenderer>().enabled = true;
            house.transform.GetChild(0).gameObject.SetActive(false);
            inHouse = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "House")
        {
            atDoor = true;
            house = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "House")
        {
            atDoor = false;
            house = null;
        }
    }

    void Rotate()
    {
        if (Time.time < rotationCD + 0.5f)
            return;
        if(firstRotation)
        {
            sprite.transform.rotation = new Quaternion(0, 0, 0, 0);
            sprite.transform.Rotate(0, 0, 20);
            firstRotation = false;
        }

        else
        {
            sprite.transform.rotation = new Quaternion(0, 0, 0, 0);
            sprite.transform.Rotate(0,0,-20);
            firstRotation = true;
        }
        rotationCD = Time.time;
    }
}
