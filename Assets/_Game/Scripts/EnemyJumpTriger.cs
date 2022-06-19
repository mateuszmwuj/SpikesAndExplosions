using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpTriger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        var enemyMovement = collider2D.gameObject.GetComponent<EnemyMovement>();
        if (enemyMovement)
            enemyMovement.Jump();

        var dummyMovement = collider2D.gameObject.GetComponent<PlayerDummyMovement>();
        if (dummyMovement)
            dummyMovement.Jump();
    }


}
