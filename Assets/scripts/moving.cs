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
    int jumpm = 0;
    ContactFilter2D nofilter;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(Vector2.left * speed * Time.deltaTime);//
            bool move = true;
            /*if (ray = Physics2D.BoxCast(this.gameObject.transform.position, transform.localScale / 2, 0, transform.TransformDirection(Vector2.left), 0.1f))
            {
                print(ray);
                if (ray.collider.CompareTag("wall") || ray.collider.CompareTag("ground"))
                {
                    move = false;
                }
                else
                {

                }
            }*/
            if (move)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpm < 1 && !djump|| Input.GetKeyDown(KeyCode.Space) && jumpm < 2 && djump)
        {
            if (ray = Physics2D.Raycast(this.gameObject.transform.position, Vector2.down, 10))
            {
                print("test");
                Debug.DrawLine(this.gameObject.transform.position, ray.point, Color.red, 2.5f, false);
                if (ray.collider.CompareTag("ground"))
                {

                }
            }
            //gör en rey cast ner för att se om man har landat
            body.AddForce(transform.up * force);
            jumpm++;
        }
        
    }
}
