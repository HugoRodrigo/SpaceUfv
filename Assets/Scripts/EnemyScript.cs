using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1;
    public Vector2 screenLimite = new Vector2(9, 5);
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.Translate(new Vector2(-speed * Time.deltaTime, direction * speed * 2 * Time.deltaTime));
        if (transform.position.y > screenLimite.y || transform.position.y < -screenLimite.y) direction *= -1;
        if (transform.position.x < -screenLimite.x) transform.position = new Vector2(screenLimite.x, transform.position.y);
    }
}
