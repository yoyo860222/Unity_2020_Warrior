using UnityEngine;

public class door : MonoBehaviour
{
    [Header("鑰匙")]
    public GameObject Key;

    [Header("開門音效")]
    public AudioClip soundOpen;

    private Animator Ani;
    private AudioSource Aud;

    private void Start()
    {
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Warrior" && Key == null)
        {
            Ani.SetTrigger("開門");
            Aud.PlayOneShot(soundOpen, 4.0f);
        }

    }
    



}


