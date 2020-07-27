using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    public float speed;
    //public float speed = -15f;
    private Rigidbody2D rb;
    private float minY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        minY = bottomCorner.y;

        rb.velocity = transform.right * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY - 5)
        {
            Destroy(gameObject);
        }
    }
}
