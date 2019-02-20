using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    Animator anim;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Open", false);
    }

    // Update is called once per frame
    void Update()
    {
        counter = GameObject.FindWithTag("Player").GetComponent<Player>().count;
        if (counter >= 3) {
            anim.SetBool("Open", true);
        }
    }
}
