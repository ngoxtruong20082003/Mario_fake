using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public float speed = 5f;
    private Vector3 target; 

    // Start is called before the first frame update
    void Start()
    {
        target = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            if(target == posA.position)
            {
                target = posB.position;
            }
            else
            {
                if(target == posB.position)
                {
                    target = posA.position;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            //Debug.Log("la con");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            //Debug.Log("Thoat con");
        }
    }
}
