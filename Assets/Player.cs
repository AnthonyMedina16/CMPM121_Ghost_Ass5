using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public int count = 0;
    CharacterController controller;
    Vector3 movement;
    GameObject particle1;
    GameObject particle2;
    GameObject particle3;
    public float gravity = 20;
    public GameObject Door;
    public Animator anim;
    public float rotationSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        particle1 = GameObject.Find("Effect1");
        particle2 = GameObject.Find("Effect2");
        particle3 = GameObject.Find("Effect3");
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movement = transform.TransformDirection(movement);
            movement = movement * speed;
        }
        //gravity
        movement.y = movement.y - (gravity * Time.deltaTime);
        controller.Move(movement * Time.deltaTime);
        //movement animation
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walking", true);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            anim.SetBool("walkingback", true);
        }
        else
        {
            anim.SetBool("walking", false);
            anim.SetBool("walkingback", false);
        }
        //player rotate
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * -rotationSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
        if(other.gameObject.name == "Key")
        {
            particle1.transform.position = other.gameObject.transform.position;
            particle1.SetActive(true);
         }
        if (other.gameObject.name == "Key2")
        {
            particle2.transform.position = other.gameObject.transform.position;
            particle2.SetActive(true);
        }
        if (other.gameObject.name == "Key3")
        {
            particle3.transform.position = other.gameObject.transform.position;
            particle3.SetActive(true);
        }
    }
}


