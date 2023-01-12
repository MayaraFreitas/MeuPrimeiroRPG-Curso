using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHelth;
    [SerializeField] private Animator anim;

    public void OnHit()
    {
        treeHelth--;
        anim.SetTrigger("isHit");

        if(treeHelth <= 0)
        {
            // Cria o toco e instancia os drops (madeita)
            anim.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.CompareTag("Axe"))
        {
            Debug.Log("HIT");
            OnHit();
        }
    }
}
