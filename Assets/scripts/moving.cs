using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    RaycastHit2D ray;
    public int speed = 5;
    Rigidbody2D body;
    public float force = 5;
    public bool djump = false;
    int jumpm = 0;
    ContactFilter2D nofilter;
    float distoground;
    public float lazer = 1f;
    public player_attack attack;
    public int hp = 3;
    public int Mhp = 3;
    //public int damage;
    //Stack<Transform> health = new Stack<Transform>();
    public Transform Hbar;
    public List<GameObject> Children = new List<GameObject>();
    public AudioClip boing;
    public AudioSource sorce;
    public GameObject died;
    public player_animator panim;
    public Transform smoke;
    Vector2 smo = new Vector2(-0.317f, 0.542f); 
    


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        distoground = GetComponent<Collider2D>().bounds.extents.y;
        attack = this.GetComponent<player_attack>();
        //Transform[] H = Hbar.GetComponentsInChildren<Transform>();
        /*foreach(Transform Hbar in transform)
        {
            health.Push(Hbar.transform);
        }*/
        foreach(Transform child in Hbar) Children.Add(child.gameObject);
        //print(Children.Count);
        hp = Children.Count;
        /*for (int i = 1; i < H.Length; i++)
        {
            health.Push(H[i]);
        }*/
        //Hbar = FindObjectOfType<health>();
        died = GameObject.Find("Died_screen");
        died.SetActive(false);
        panim = GetComponent<player_animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            attack.rigth = true;
            bool move = true;
            if (ray = Physics2D.BoxCast(this.gameObject.transform.position, transform.localScale/2, 0, Vector2.right,0.3f))
            {
                if (ray.collider.CompareTag("wall") || ray.collider.CompareTag("ground"))
                {
                    move = false;
                }
            }
            if (move)
            {
                smo.x = -0.317f;
                panim.smove(attack.rigth);
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(Vector2.left * speed * Time.deltaTime);//
            attack.rigth = false;
            bool move = true;
            if (ray = Physics2D.BoxCast(this.gameObject.transform.position, transform.localScale/2, 0, Vector2.left, 0.3f/*, LayerMask.GetMask("wall"), LayerMask.GetMask("ground")*/))
            {
                
                //print(ray.collider.tag);
                if (ray.collider.CompareTag("wall") || ray.collider.CompareTag("ground"))
                {
                    move = false;
                }
            }
            if (move)
            {
                smo.x = 0.317f;
                panim.smove(attack.rigth);
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
        smoke.transform.localPosition = smo;
    }
    /*bool ground()
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

    }*/
    void Update()
    {
        /*if (ground())
        {
            print("grounded");
            jumpm = 0;
        }*/
        if (Input.GetKeyDown(KeyCode.Space) && jumpm < 1 && !djump|| Input.GetKeyDown(KeyCode.Space) && jumpm < 2 && djump)
        {
            //Debug.Log("jtest");
            sorce.PlayOneShot(boing);
            body.AddForce(transform.up * force);
            jumpm++;
            //g�r en rey cast ner f�r att se om man har landat
        }
        /*
        if (ray = Physics2D.Raycast(transform.position, Vector2.down,lazer, LayerMask.GetMask("ground")))
        {
            //print("");
            //Debug.Log("testing");
             Debug.DrawRay(transform.position, Vector2.down*lazer, Color.red, 30, false);
            if (ray.collider.gameObject.tag == "ground")
             {
                //if jump does not work and the lazer is not visible change the lazer float
                print("test");
                jumpm = 0;
             }
        }
        */
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground" || collision.gameObject.tag == "wall")
        {
            jumpm = 0;
        }
    }
    public void hurt(int damage)
    {
        for (int i = 0; i < damage; i++ )
        {
            hp--;
            Destroy(Children[hp]);
            Children.Remove(Children[hp]);
            //print("test");
            if(hp <= 0)
            {
                //Destroy(this.gameObject);
                died.SetActive(true);
                this.enabled = false;
            }
        }

    }
    
}
