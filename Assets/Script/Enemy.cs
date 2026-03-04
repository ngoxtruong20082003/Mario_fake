using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float distance = 5f;
    private Vector3 startPos;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;

        if(movingRight)
        {
            transform.Translate(Vector2.right*speed*Time.deltaTime);
            if(transform.position.x >= rightBound)
            {
                movingRight = false;
                Filp();
            }
            
        }
        else
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);
            if(transform.position.x <= leftBound)
            {
                movingRight = true;
                Filp();
            }        
        }
    }

    void Filp()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
