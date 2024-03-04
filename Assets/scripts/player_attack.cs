using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public bool cooling = false;
    RaycastHit2D ray;
    public bool rigth = true;
    public float attack = 1;
    public Transform Ebar;
    public int steam = 5;
    int eabillity = 1;
    public moving moving;
    public Transform cog;
    // Start is called before the first frame update
    void Start()
    {
        moving = this.GetComponent<moving>();
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            switch (eabillity)
            {
                case (1):
                    int i = 0;
                    //t = Instantiate(cog, moving.Hbar.transform.position, moving.Hbar.transform.rotation) as ;
                    //t.transform.parent = moving.Hbar;
                    if (steam >= 5 && moving.hp < moving.Mhp)
                    {
                        steam = steam - 5;
                        Instantiate(cog, moving.Hbar);

                        foreach (Transform child in moving.Hbar)
                        {
                            
                            if (i < moving.Children.Count && child.gameObject == moving.Children[i])
                            {
                                 print(i);
                            }
                            else
                            {
                                moving.Children.Add(child.gameObject);
                            }
                             i++;
                        }
                        moving.hp = moving.Children.Count;
                    }
                    break;
            }
        }
    }
    IEnumerator cool()
    {
        cooling = true;
        yield return new WaitForSeconds(0.5f);
        cooling = false;
    }
    public void energy(int decrese)
    {
        steam = steam - decrese;
        switch (steam)
        {
            case (0):

                break;
            case (1):

                break;
            case (2):

                break;
            case (3):

                break;
            case (4):

                break;
        }

    }
}
