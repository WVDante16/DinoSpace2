using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    //Variables privadas
    private ParticleSystem thisParticleSystem;

    private void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        //Checar si el sistema esta activo
        if (thisParticleSystem.isPlaying)
        {
            return;
        }

        //Si ya no esta activo el sistema, destruir el objeto
        Destroy(gameObject);
    }
}
