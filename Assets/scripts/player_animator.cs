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
    Vector3 pslash = new Vector3(30, 3.5f, 0);
    public Sprite[] startmove;
    public Sprite[] moving;
    bool m = false;
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

    public IEnumerator attack(bool rigth)
    {
        if (!rigth)
        {
            rsprites.flipX = true;
            rslashrender.flipX = true;
            pslash.x = -30;
        }
        else
        {
            rsprites.flipX = false;
            rslashrender.flipX = false;
            pslash.x = 32.7f;
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
        yield return null;
    }
    public IEnumerator Move(bool rigth)
    {
        print("fe");
        for (int i = 0; i < startmove.Length; i++)
        {
            rsprites.sprite = startmove[i];
            yield return new WaitForSeconds(0.3f);
        }
        while (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            int i = 0;
            rsprites.sprite = moving[i];
            yield return new WaitForSeconds(0.3f);
            if (i > moving.Length) i = 0;
        }
        rsprites.sprite = idl;
        m = false;
        yield return null;
    }
}

