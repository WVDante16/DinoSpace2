using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Variables publicas
    [Header("Estadisticas")]
    public float life = 1f;
    public float speed = 2f;
    public bool canShoot = false;

    [Header("Asignaciones")]
    public Transform attackPoint;
    public GameObject enemyBulletGO;

    [Header("Puntaje")]
    public int pointsToKill;

    private void Start()
    {
        if (canShoot)
        {
            //Invocar metodo de disparos en un tiempo aleatorio
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    private void Update()
    {
        //Obtener la posicion del enemigo
        Vector2 position = transform.position;

        //Obtener la nueva posicion del enemigo
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //Actualizar la posicion del enemigo
        transform.position = position;

        //Obtener los limites inferiores de la pantalla
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Destruir al enemigo si sale de la pantalla
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        //Restar vida del enemigo si le impacta un proyectil del jugador
        if (_other.tag == "P_Bullet")
        {
            life--;
        }

        //Destruir al enemigo si su vida es 0
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Funcion de disparo del enemigo
    void StartShooting()
    {
        //Invocar la bala del enemigo
        Instantiate(enemyBulletGO, attackPoint.position, attackPoint.rotation);

        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }
}
