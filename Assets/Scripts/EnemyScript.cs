using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1;
    public Vector2 screenLimite = new Vector2(9, 5);
    int direction = 1;

    public GameObject projectile;
    public float shootDistance = 1;
    public float shootSpeed = 300;
    public float shootCD = .8f;
    float shootTimer = 0;
    Vector2 shootDirection = Vector2.left;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        Move();
        Shoot();
    }
    void Shoot()
    {
        if (shootTimer > shootCD)
        {
            GameObject shoot = Instantiate(projectile);
            shoot.transform.position = transform.position + Vector3.left * shootDistance;
            shoot.transform.up = shootDirection.normalized;
            shoot.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * shootSpeed);
            shootTimer = 0;
        }
    }
    void Move()
    {
        transform.Translate(new Vector2(-speed * Time.deltaTime, direction * speed * 2 * Time.deltaTime));
        if (transform.position.y > screenLimite.y || transform.position.y < -screenLimite.y)
        {
            direction *= -1;
            transform.position = new Vector2(transform.position.x, Mathf.Sign(transform.position.y) * screenLimite.y);
        }
        if (transform.position.x < -screenLimite.x) transform.position = new Vector2(screenLimite.x, transform.position.y);
    }
}
