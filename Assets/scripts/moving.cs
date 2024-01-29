using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    RaycastHit2D ray;
    public int speed = 5;
    Rigidbody2D body;
    public float force = 5;
    bool djump = false;
    int jumpm = 1;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(Vector2.left * speed * Time.deltaTime);//
            bool move = true;
            if (Physics2D.BoxCast(this.gameObject.transform.position, transform.localScale / 2, 0, transform.TransformDirection(Vector2.left)/*, out ray, transform.rotation, 0.1f*/))
            {
                print("tesst");
                if (ray.collider.CompareTag("wall") || ray.collider.CompareTag("ground"))
                {
                    move = false;
                }
                else
                {

                }
            }
            if (move)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //gör en rey cast ner för att se om man har landat
                body.AddForce(transform.up * force);
        }
    }
}
