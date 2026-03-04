using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blox : MonoBehaviour
{

    public GameObject coinPrefab;
    public Sprite usedSprite;

    public float bounceHeight = 0.2f;
    public float bounceSpeed = 0.1f;

    private bool used = false;
    private Vector3 originalPos;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Kiểm tra đập từ dưới lên
            if (collision.contacts[0].normal.y > 0 && !used)
            {
                used = true;

                SpawnCoin();
                StartCoroutine(Bounce());

                if (usedSprite != null)
                {
                    sr.sprite = usedSprite;
                }
            }
        }
    }

    void SpawnCoin()
    {
        Vector3 spawnPos = transform.position + Vector3.up * 1f;
        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }

    IEnumerator Bounce()
    {
        transform.position += Vector3.up * bounceHeight;
        yield return new WaitForSeconds(bounceSpeed);
        transform.position = originalPos;
    }
}
