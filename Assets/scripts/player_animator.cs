using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animator : MonoBehaviour
{
    public Sprite[] sattack;
    public SpriteRenderer rsprites;
    public Sprite idl;
    public Sprite[] slash;
    public GameObject slasher;
    public SpriteRenderer rslashrender;
    public SpriteRenderer lslashrender;
    public player_attack Attack;
    Vector3 pslash = new Vector3(30, 0.6196142f, 0);
    public Sprite[] startmove;
    public Sprite[] moving;
    bool m = false;
    bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        //rsprites = GetComponent<SpriteRenderer>();
        slasher.SetActive(false);
        Attack = this.GetComponent<player_attack>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stattack(bool rigth)
    {
        StartCoroutine(attack(rigth));
    }
    public void smove(bool rigth)
    {
        if (!m)
        {
            m = true;
            StartCoroutine(Move(rigth));
        }
    }
    public void turn(bool rigth)
    {
        //print("t");
        if (Input.GetKey(KeyCode.A))
        {
            rsprites.flipX = true;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rsprites.flipX = false;
        }
    }

    public IEnumerator attack(bool rigth)
    {
        attacking = true;
        if (!rigth)
        {
            rsprites.flipX = true;
            rslashrender.flipX = true;
            pslash.x = -6;
        }
        else
        {
            rsprites.flipX = false;
            rslashrender.flipX = false;
            pslash.x = 5f;
        }
        slasher.transform.localPosition = pslash;
        slasher.SetActive(true);
        for (int i = 0; i < sattack.Length; i++)
        {
            rsprites.sprite = sattack[i];
            rslashrender.sprite = slash[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.2f);
        rsprites.sprite = idl;
        slasher.SetActive(false);
        attacking = false;
        yield return null;
    }
    public IEnumerator Move(bool rigth)
    {
        for (int i = 0; i < startmove.Length; i++)
        {
            turn(rigth);
            rsprites.sprite = startmove[i];
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( () => { return !attacking;});
        }
        int y = 0;
        while (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            turn(rigth);
            rsprites.sprite = moving[y];
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil(() => { return !attacking;});
            //print(y);
            y++;
            if (y >= moving.Length)
            {
                y = 0;
            }
        }
        for (int i = startmove.Length-1; i >= 0; i--)
        {
            turn(rigth);
            rsprites.sprite = startmove[i];
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil(() => { return !attacking;});
        }
        rsprites.sprite = idl;
        m = false;
        yield return null;
    }
    
}


