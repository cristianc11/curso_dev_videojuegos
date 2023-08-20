using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlPlayer : MonoBehaviour
{
    [Header("MovimientoHorizontal")]
    public float fuerzaHorizontal;   
        float valorHorizontal;   
        Animator animator;

    [Header("Salto")]
    public float fuerzaSalto;
    public float alturaRayo;
    public LayerMask capaPiso;
        Rigidbody2D rigidbody2D;

    public bool tocandoPiso;
    public float fuerzaVertical;
    public LayerMask piso;
    public int Puntaje;
    public TMP_Text textoVidaPlayer;
    public TMP_Text textoPuntosPlayer;
    public int vidaTotal;
    public int vidaActual;
    public Vector3 posicionInicial;
    public int restarVida;



    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();


        if (fuerzaHorizontal <= 0) {fuerzaHorizontal = 1;}
        if (fuerzaSalto <= 0){fuerzaSalto = 5f;}
        if (alturaRayo <= 0){alturaRayo = 1.5f;}



    }

    // Update is called once per frame
    void Update()
    {
        //MoviminetoHorizontal
        valorHorizontal = Input.GetAxisRaw("Horizontal");
        if (valorHorizontal != 0)
        {
            if (valorHorizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (valorHorizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            transform.position += Vector3.right * valorHorizontal * fuerzaHorizontal * Time.deltaTime;
        }
        animator.SetFloat("Correr", Mathf.Abs(valorHorizontal));

        //MovimientoVertical
        Debug.DrawRay(transform.position, Vector3.down * alturaRayo, Color.blue, 0.1f);
        if (Physics2D.Raycast(transform.position, Vector2.down, alturaRayo, piso))
        {
            tocandoPiso = true;
            //Debug.Log("Hit"); 
            rigidbody2D.gravityScale = 1f;
        }
        else
        {
            tocandoPiso = false;
            rigidbody2D.gravityScale = 2f;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && tocandoPiso)
        {
            //Debug.Log("Salto");
            rigidbody2D.velocity = Vector2.up * fuerzaVertical;
            
        }
        PlayerDead();
    }
        // Debug.DrawRay(transform.position, Vector2.down * alturaRayo, Color.red, 0.01f);
        // if (Physics2D.Raycast(transform.position, Vector2.down, alturaRayo, capaPiso)) {
        // Debug.Log("Tocando Piso");
        // if (Input.GetKeyDown(KeyCode.UpArrow)) {
        // rigidbody2D.velocity = Vector2.up * fuerzaSalto;
        // Debug.Log("Salta");
    public void Vida(int vidaRecibe)
    {
        vidaActual += vidaRecibe;
        textoVidaPlayer.text = "Vida:" + vidaActual.ToString();
        Debug.Log("Cambio de vida: " + vidaRecibe);
    }

    public void RestarVida(int restarVida) {
        vidaActual -= restarVida;
    }

    public void PlayerDead()
    {
        if (vidaActual <= 0)
        {
            vidaActual = 100;
            transform.position = posicionInicial;
            textoVidaPlayer.text = "Vida:" + vidaActual.ToString();

        }

    }

    public void Sumarpuntaje(int Puntossumados)
    {
        Puntaje += Puntossumados;
        textoPuntosPlayer.text = Puntaje.ToString();

    }
}
        //}

    //}
//}
