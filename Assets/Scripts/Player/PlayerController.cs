using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables publicas
    public float MoveSpeed;

    [Header("Disparar")]
    public Transform firePoint; //Punto que origina los proyectiles
    public GameObject bullet; //Proyectil que dispara el jugador
    public float shootDelay; //Delay de disparo

    //Variables privadas
    private Rigidbody2D RB2D;
    private bool canShoot;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    private float shootDelayCounter; //Contador de retraso de la bala

    private void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
        canShoot = true;
    }

    private void Update()
    {
        //Llamada al metodo que mueve al jugador
        MovePlayer();

        //Input para mantener disparos y aplicar delay del disparo
        if (canShoot)
        {
            //Resta al contador de retraso de disparos usando el tiempo
            shootDelayCounter -= Time.deltaTime;

            //Checar si se acabo el contador de delay
            if (shootDelayCounter <= 0)
            {
                //Reiniciar el contador
                shootDelayCounter = shootDelay;

                //Instanciar proyectil
                Instantiate(bullet, firePoint.position, firePoint.rotation);
            }
        }
    }

    private void FixedUpdate()
    {
        RB2D.velocity = new Vector2(horizontalMove, RB2D.velocity.y);
    }

    //Funciones para volver true los booleanos al estar presionando un boton
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }

    //Funciones para volver false los booleanos al soltar un boton
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }

    //Funcion que mueve al jugador
    private void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -MoveSpeed;
        }
        else if (moveRight)
        {
            horizontalMove = MoveSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
    }
}
