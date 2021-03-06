using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostControler : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject part4;

    private Collider2D most;

    void Start()
    {
        most = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.layer == 6 || collider2D.gameObject.layer == 7) {
            StartCoroutine(Sekuency());
        }
    }

    private IEnumerator Sekuency() {
        most.enabled = false;
        
        StartCoroutine(part1.GetComponent<Most>().Destroy());

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(part2.GetComponent<Most>().Destroy());

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(part3.GetComponent<Most>().Destroy());

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(part4.GetComponent<Most>().Destroy());


    }

}
