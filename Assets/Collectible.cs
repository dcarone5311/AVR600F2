using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    AudioSource audioSource;
    Animator animator;
    public GameObject particles;

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
        Invoke("Despawn", 1f);
        
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }
}
