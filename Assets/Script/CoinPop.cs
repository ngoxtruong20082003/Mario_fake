using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPop : MonoBehaviour
{

   public float jumpForce = 5f;
    public float gravity = -12f;
    public float lifeTime = 0.6f;

    private float verticalVelocity;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        verticalVelocity = jumpForce;   

        if (GameManager.Instance != null)
            GameManager.Instance.AddPoin(10);     
    }

    // Update is called once per frame
    void Update()
    {
       // Gravity
        verticalVelocity += gravity * Time.deltaTime;

        // Di chuyển
        transform.position += new Vector3(0, verticalVelocity * Time.deltaTime, 0);

        // Đếm thời gian
        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        } 
    }
}
