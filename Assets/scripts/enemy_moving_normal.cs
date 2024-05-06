using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_moving_normal : MonoBehaviour
{
    public bool rigth = false;
    public int damage = 1;
    public AudioClip bonk;
    public AudioSource sorce;
    // Start is called before the first frame update
    void Start()
    {
        sorce = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        turn();
        if(collision.gameObject.tag == "Player")
        {
            sorce.PlayOneShot(bonk);
            //collision.transform.GetComponent<moving>().damage = damage;
            collision.transform.GetComponent<moving>().hurt(damage);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigth)
        {
            transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * 5 * Time.deltaTime);
        }
    }
    public void turn()
    {
        if (rigth)
        {
            rigth = false;
        }
        else
        {
            rigth = true;
        }

    }
}
