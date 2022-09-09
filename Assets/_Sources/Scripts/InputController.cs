using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;

    public float Horizontal = 0;
    public float Vertical = 0;

    public bool JumpSignalActive = false;
    public bool RunSignalActive = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.UpArrow)) JumpSignalActive = true;
        RunSignalActive = Input.GetKey(KeyCode.Tab);
    }
}
