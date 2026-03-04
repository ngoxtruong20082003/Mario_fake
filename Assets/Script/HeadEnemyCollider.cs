using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadEnemyCollider : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
            GameManager.Instance.AddPoin(5);

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            
        }
    }
}
