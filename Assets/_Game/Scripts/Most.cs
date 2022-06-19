using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most : MonoBehaviour
{
    public GameObject preperExplode;
    public GameObject explosion;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    

    public IEnumerator Destroy() {
        Instantiate(preperExplode, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

