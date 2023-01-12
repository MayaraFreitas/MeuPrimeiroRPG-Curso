using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    public List<Transform> paths = new List<Transform>();

    private static float initialSpeed;

    private int pathIndex;
    private Animator anim;

    private void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        OnMove();
    }

    void OnMove()
    {
        if (DialogControl.instance.IsShowing)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[pathIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, paths[pathIndex].position) < 0.1f)
        {
            if (pathIndex < paths.Count - 1)
            {
                //pathIndex++;
                pathIndex = Random.Range(0, (paths.Count - 1));
            }
            else
            {
                pathIndex = 0;
            }
        }

        Vector2 direction = paths[pathIndex].position - transform.position;
        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
