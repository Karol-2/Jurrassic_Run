using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_In_Cage : MonoBehaviour
{
    [SerializeField] private AudioClip[] dodoSounds;
    [SerializeField] private int timeOfSilence;
    private AudioSource currentSound;
    public GameObject linkedCage;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (linkedCage.GetComponent<SpriteRenderer>().enabled == false)
        {
            //sounde of freedom
            rb.bodyType = RigidbodyType2D.Dynamic;
            transform.gameObject.tag = "Box";
        }
        // play sounds of being in cage
    }

    private void CallAudio()
    {
        Invoke("RandomSound", timeOfSilence);
    }
    private void RandomSound()
    {
        currentSound.clip = dodoSounds[Random.Range(0,
            dodoSounds.Length)];
        audioSource.clip = currentSound.clip;
        audioSource.Play();
        CallAudio();
    }


}
