using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    //particulas
    public Transform particulas;
    private ParticleSystem systemaParticulas;
    private Vector3 posicionParticulas;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Particulas
        systemaParticulas = particulas.GetComponent<ParticleSystem>();
        systemaParticulas.Stop();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal,0,vertical);
        rb.AddForce(movement * speed);
    }



    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Toca")){
            
            Debug.Log("Entraa tocaa");
            Vector3 posicion= other.gameObject.transform.position;
            Debug.Log("verde" + posicion);
            
            GameObject objetivo = GameObject.FindWithTag("lleva");
            Vector3 posicion1= objetivo.transform.position;
            Debug.Log("Amarillo" + posicion1);

            GameObject jugador = GameObject.FindWithTag("player");
            jugador.transform.position = posicion1;
        }

        else if (other.gameObject.CompareTag("BuboBlue")){

            Vector3 reset = new Vector3(-7,0,-17); 
            other.transform.position = reset;
        }

        else if (other.gameObject.CompareTag("pink")){
            
            Vector3 posiPink=other.gameObject.transform.position;
            posiPink.x+=1;
            other.transform.position=posiPink;
        }

        else if(other.gameObject.CompareTag("CuboParticula")){

            posicionParticulas = other.gameObject.transform.position;
            particulas.position = posicionParticulas;
            systemaParticulas = particulas.GetComponent<ParticleSystem>();
            
            systemaParticulas.Play();
        }
        
    }

}
