using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbody;
    private float minY;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        minY = bottomCorner.y;

        rigidbody.velocity = transform.right * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY - 2) Destroy(gameObject);
    }
    public void ShootParameters(float speed)
    {
        this.speed = speed;
    }
}
