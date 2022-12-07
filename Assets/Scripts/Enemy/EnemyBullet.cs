using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //Variables publicas
    public float bulletSpeed;
    public EnemyController enemy;
    public GameObject impactFX; //Referencia a particula de impacto
    public float lifeTime; //Contador para autodestruccion

    //Variables privadas
    private Rigidbody2D bulletRB2D;

    private void Start()
    {
        //Inicializacion de referencias
        bulletRB2D = GetComponent<Rigidbody2D>();
        enemy = FindObjectOfType<EnemyController>();
    }

    private void Update()
    {
        //Cambiar la velocidad del RB2D para desplazar el proyectil
        bulletRB2D.velocity = new Vector2(0, -bulletSpeed);

        //Reduccion del lifeTime usando el tiempo
        lifeTime -= Time.deltaTime;

        //Destruccion de la bala 
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Funcion para evaluar la entrada al trigger
    private void OnTriggerEnter2D(Collider2D _other)
    {
        //Checar si la bala choca con un enemigo
        if (_other.tag == "Player")
        {
            //Instanciar particulas de impacto
            Instantiate(impactFX, transform.position, Quaternion.Euler(90f, 0f, 0f));

            //Destruir este GO cuando colisione
            Destroy(gameObject);
        }
    }
}
