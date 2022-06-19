using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaga : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<CharacterController2D>() == false) {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        
    }
}
