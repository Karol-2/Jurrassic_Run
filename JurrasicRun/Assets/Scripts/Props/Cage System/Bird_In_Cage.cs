using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_In_Cage : MonoBehaviour
{
    [SerializeField] private AudioClip[] dodoSounds;
    [SerializeField] private int timeOfSilence;
    
    public bool birdSaved = false;
    private AudioClip currentSound;
    public GameObject linkedCage;
    private Rigidbody2D rb;
    public AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (linkedCage.GetComponent<SpriteRenderer>().enabled == false)
        {
            
            rb.bodyType = RigidbodyType2D.Dynamic;
            transform.gameObject.tag = "Box";
            birdSaved = true;
        }
        if (!audioSource.isPlaying)
            StartCoroutine(RandomSound());
    }

  
    private IEnumerator RandomSound()
    {
        if (audioSource.isPlaying)
        {
            yield break;
        } 
        currentSound = dodoSounds[Random.Range(0,dodoSounds.Length)];
        audioSource.clip = currentSound;
        audioSource.Play();
        yield return new WaitForSeconds(timeOfSilence);
        yield return 0;
    }


}
