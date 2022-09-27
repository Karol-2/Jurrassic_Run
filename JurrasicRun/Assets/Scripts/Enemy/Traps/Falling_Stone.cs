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
    private SpriteRenderer sprite;
    private Coroutine coroutine;
    private bool destroyed = false;
    private bool falling = false;

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            //gameObject.transform = new Vector3(0,0,0);
            rb.bodyType = RigidbodyType2D.Static;
            sprite.enabled = false;
            falling = false;

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
        audioSource.enabled = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        falling = true;
    }
}
