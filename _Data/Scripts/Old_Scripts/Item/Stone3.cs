﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone3 : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Anim3()
    {
        anim.SetBool("Run", true);
    }

}
