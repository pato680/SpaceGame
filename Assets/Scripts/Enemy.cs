using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] shoots;
    public Transform position1, position2, position3;
    [SerializeField]
    public float shootSpeed, enemySpeed;
    //
    private float minY, maxY;
    private bool shooted = false;
    private static int positionOfEnemyToSpawn = 0;
    private void Start()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        maxY = topCorner.y;
        minY = bottomCorner.y;
    }

    void Update()
    {
        if(positionOfEnemyToSpawn == 0) positionOfEnemyToSpawn = Random.Range(1, 3);
        //if (positionOfEnemyToSpawn == 2) print("ES 2 CARAJO");
        if (positionOfEnemyToSpawn == 1)
        {
            shootSpeed = 5f;
            enemySpeed = 1f;
            Transform[] positions = { position1, position2, position3 };
            MoveEnemy(enemySpeed, positions, shootSpeed);
        }
        else if (positionOfEnemyToSpawn == 2)
        {
            shootSpeed = 15f;
            enemySpeed = 10f;
            Transform[] positions = { position1 };
            MoveEnemy(enemySpeed, positions, shootSpeed);
        }
    }
    void MoveEnemy(float enemySpeed, Transform[] positions, float shootSpeed)
    {
        transform.Translate(Vector3.up * Time.deltaTime * enemySpeed);

        if (!shooted)
        {
            if (transform.position.y < maxY - 0.5)
            {
                ShootPositions(positions, shoots[1], shootSpeed);
            }
        }
        
        if (transform.position.y < minY - 4)
        {
            Destroy(gameObject);
        }
    }
    void ShootPositions(Transform[] bulletPositions, GameObject bullet, float shootSpeed)
    {
        shooted = true;
        foreach(Transform t in bulletPositions)
        {
            var enemyShoot = Instantiate(bullet, t.position, t.rotation);
            enemyShoot.GetComponent<EnemyShoot>().ShootParameters(shootSpeed);
        }
    }
}
