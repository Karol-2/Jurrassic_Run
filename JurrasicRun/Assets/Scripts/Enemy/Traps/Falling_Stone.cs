using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Stone : MonoBehaviour
{
    [SerializeField] private float timeStageI;
    [SerializeField] private float timeStageII;
    [SerializeField] private ParticleSystem particles;

    private BoxCollider2D bc;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Transform transform;
    private Coroutine coroutine;

    private bool destroyed = false;
    private bool falling = false;
    private Vector2 startingPosition;

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        startingPosition = new Vector2 (transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when it hits the ground
        if(collision.CompareTag("Ground"))
        {
            StopAllCoroutines();
            //Debug.Log("hit the ground");
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = startingPosition;
            falling = false;
            audioSource.enabled = true;


        }
    }

    void Update()
    {
        if (falling == false)
        {
            coroutine = StartCoroutine(stageI());
        }
    }

    IEnumerator stageI()
    {

        var emissing = particles.emission;
        emissing.rateOverTime = 5;
        yield return new WaitForSeconds(timeStageI);
        coroutine = StartCoroutine(stageII());
    }
    IEnumerator stageII()
    {
        var emissing = particles.emission;
        emissing.rateOverTime = 10;
        yield return new WaitForSeconds(timeStageII);
        //falling
        audioSource.enabled = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        falling = true;
    }
}
