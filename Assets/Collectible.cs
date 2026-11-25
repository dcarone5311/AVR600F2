using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    AudioSource audioSource;
    Animator animator;

    [SerializeField]
    GameObject particles;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        animator.SetTrigger("isCollected");
        particles.SetActive(true);
        GetComponent<Collider>().enabled = false; //turn off collider so that we dont collect twice

        GameManager.GM.gemsCollected++; //add 1 to score
        Invoke("Despawn", 1f);
        
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }
}
