using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    private float maxY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        maxY = topCorner.y;
        
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxY + 5)
        {
            Destroy(gameObject);
        }
    }
}
