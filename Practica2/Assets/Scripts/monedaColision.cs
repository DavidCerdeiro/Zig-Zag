using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedaColision : MonoBehaviour
{
    public AudioSource sonidoMoneda;
    public ParticleSystem particulas;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            particulas.transform.position = this.gameObject.transform.position;
            sonidoMoneda.Play();
            particulas.Play();
            Destroy(this.gameObject);
        };
    }

}
