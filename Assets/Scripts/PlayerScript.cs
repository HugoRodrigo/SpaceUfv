using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 1;
    public Vector2 screenLimite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
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
