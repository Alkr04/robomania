using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public bool cooling = false;
    RaycastHit2D ray;
    public bool rigth = true;
    public float attack = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !cooling)
        {
            if (rigth)
            {
                if (ray = Physics2D.BoxCast(this.gameObject.transform.position, transform.localScale/2, 0, Vector2.right,attack))
                {
                    //print("rigth");
                    print(ray.transform.tag);
                    if (ray.collider.tag == "enemy")
                    {
                        ray.transform.GetComponent<enemy_health>().hp -= 1;
                        ray.transform.GetComponent<enemy_health>().damage();
                    }
                }
            }
            else
            {
                if (ray = Physics2D.BoxCast(this.gameObject.transform.position, transform.localScale/2, 0, Vector2.left, 1f))
                {
                    //print("left");
                    if (ray.collider.tag == "enemy")
                    {
                        ray.transform.GetComponent<enemy_health>().hp -= 1;
                        ray.transform.GetComponent<enemy_health>().damage();
                    }
                }
            }
            StartCoroutine(cool());
        }
    }
    IEnumerator cool()
    {
        cooling = true;
        yield return new WaitForSeconds(0.5f);
        cooling = false;
    }
}
