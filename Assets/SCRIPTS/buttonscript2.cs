using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonscript2 : MonoBehaviour
{
    public GameObject show;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("touchmethere", true);
            show.SetActive(true);
        }
        else
        {
            animator.SetBool("touchmethere", false);
        }
    }
}
