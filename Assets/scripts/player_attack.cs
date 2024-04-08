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
    public int msteam = 5;
    int eabillity = 1;
    public moving moving;
    public Transform cog;
    public Transform pointer;
    public Transform limiter;
    public AudioSource sorce;
    public AudioClip slash;
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
                        energy(5);
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
                pointer.transform.eulerAngles = new Vector3(0, 0,60);
                break;
            case (5):
                pointer.transform.eulerAngles = new Vector3(0, 0, 43);
                break;
            case (10):
                pointer.transform.eulerAngles = new Vector3(0, 0, 28);
                break;
            case (15):
                pointer.transform.eulerAngles = new Vector3(0, 0, 12);
                break;
            case (20):
                pointer.transform.eulerAngles = new Vector3(0, 0, -9);
                break;
            case (25):
                pointer.transform.eulerAngles = new Vector3(0, 0, -30);
                break;
            case (30):
                pointer.transform.eulerAngles = new Vector3(0, 0, -47);
                break;
            case (35):
                pointer.transform.eulerAngles = new Vector3(0, 0, -67);
                break;
        }

    }
    public void steam_upgrade()
    {
        msteam = msteam + 5;
        switch (msteam)
        {
            case (5):
                limiter.transform.eulerAngles = new Vector3(0, 0, -40);
                break;
            case (10):
                limiter.transform.eulerAngles = new Vector3(0, 0, -60);
                break;
            case (15):
                limiter.transform.eulerAngles = new Vector3(0, 0, -80);
                break;
            case (20):
                limiter.transform.eulerAngles = new Vector3(0, 0, -106);
                break;
            case (25):
                limiter.transform.eulerAngles = new Vector3(0, 0, -132);
                break;
            case (30):
                limiter.transform.eulerAngles = new Vector3(0, 0, -150);
                break;
            case (35):
                limiter.transform.eulerAngles = new Vector3(0, 0, -180);
                break;
        }
    }
}
