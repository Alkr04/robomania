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
    float distoground;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        distoground = GetComponent<Collider2D>().bounds.extents.y;
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
    bool ground()
    {
        Debug.DrawRay(transform.position, -Vector3.up, Color.yellow, 20);
        ray = Physics2D.Raycast(transform.position, -Vector2.up, distoground + 0.1f);
        print(ray);
        if (ray.collider.CompareTag("ground"))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    void Update()
    {
        /*if (ground())
        {
            print("grounded");
            jumpm = 0;
        }*/
        if (Input.GetKeyDown(KeyCode.Space) && jumpm < 1 && !djump|| Input.GetKeyDown(KeyCode.Space) && jumpm < 2 && djump)
        {
            body.AddForce(transform.up * force);
            jumpm++;
            //gör en rey cast ner för att se om man har landat
        }
        if (ray = Physics2D.Raycast(transform.position, Vector2.down,0.5f, LayerMask.GetMask("ground")))
        {
             //print(ray.point*5);
             Debug.DrawRay(transform.position, Vector2.down*0.5f, Color.red, 30, false);
            if (ray.collider.gameObject.tag == "ground")
             {
                print("test");
                jumpm = 0;
             }
        }
        
    }
}
