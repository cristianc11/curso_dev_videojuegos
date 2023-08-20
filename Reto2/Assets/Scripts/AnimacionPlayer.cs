using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPlayer : MonoBehaviour
{

    Animator animator;
    public float movimientoHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        animator   = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");       
        animator.SetFloat("movimientoHorizontal", Mathf.Abs(movimientoHorizontal));

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            animator.SetTrigger("Saltar");
        }
    }
}
