using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 1;
    public Vector2 screenLimite;
    public GameObject projectile;
    public Transform[] shootPositon;
    public Vector2[] shootDirection;
    public float shootSpeed = 300;
    public float shootCD = .5f;
    float shootTimer = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        Moviment();
        Shoot();
    }
    void Shoot()
    {
        if(Input.GetAxisRaw("Jump") != 0 && shootTimer>= shootCD)
        {
            for (int i = 0; i < shootPositon.Length; i++)
            {
                GameObject shoot = Instantiate(projectile);
                shoot.transform.position = shootPositon[i].position;
                shoot.transform.up = shootDirection[i].normalized;
                shoot.GetComponent<Rigidbody2D>().AddForce(shootDirection[i].normalized * shootSpeed);
            }
            shootTimer = 0;
        }
    }
    void Moviment()
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(hMove, vMove).normalized * speed * Time.deltaTime);
        if (transform.position.x > screenLimite.x) transform.position = new Vector3(-screenLimite.x + .2f, transform.position.y);
        if (transform.position.x < -screenLimite.x) transform.position = new Vector3(screenLimite.x - .2f, transform.position.y);
        if (transform.position.y > screenLimite.y) transform.position = new Vector3(transform.position.x, -screenLimite.y + .2f);
        if (transform.position.y < -screenLimite.y) transform.position = new Vector3(transform.position.x, screenLimite.y -+ .2f);
    }
}
