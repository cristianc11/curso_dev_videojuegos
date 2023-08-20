using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    public int fuerzaAtaque;
    public int fuerzaEmpuje;

    private void Start()
    {
        if (fuerzaAtaque <= 0) { fuerzaAtaque = 1; }
        if (fuerzaEmpuje <= 0) { fuerzaEmpuje = 1; }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.left * fuerzaEmpuje, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<ControlPlayer>().RestarVida(fuerzaAtaque);

            Debug.Log("Hit Player");
        }

        }
}
