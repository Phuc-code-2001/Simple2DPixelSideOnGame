using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public Rigidbody2D rb;
    public Animator animator;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }



}
