using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Variables publicas
    [Header("Limites en X")]
    public float minX = -2f;
    public float maxX = 2f;

    [Header("Asignacion de enemigos")]
    public GameObject[] EnemyGO;

    [Header("Timer de generacion")]
    public float spawnTimer = 2f;

    private void Start()
    {
        //Invocar a la funcion que spawnea enemigos
        Invoke("SpawnEnemy", spawnTimer);
    }

    //Funcion para spawnear enemigos
    void SpawnEnemy()
    {
        //Posicion aleatoria tomando los limites en X
        float posX = Random.Range(minX, maxX);

        //Valor local que guarda la posicion del spawner
        Vector3 temp = transform.position;

        //Igualar la posicion temporal con la posicion local en X
        temp.x = posX;

        //Numero aleatorio para elegir un enemigo
        int REnemy = Random.Range(0, EnemyGO.Length);

        //Invocar al enemigo
        Instantiate(EnemyGO[REnemy], temp, Quaternion.identity);

        //Invocacion de la funcion para generar enemigos
        Invoke("SpawnEnemy", spawnTimer);
    }
}
