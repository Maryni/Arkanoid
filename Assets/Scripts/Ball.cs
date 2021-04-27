using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private ScoreActions scoreActions;
    private float x;
    private Vector3 dir;
    void Start()
    {
        rigidbody.velocity = new Vector3((Random.Range(-0.55f,0.55f)),
            transform.position.y, 
            (Random.Range(0f, 1f))) * speed;
        //Debug.DrawLine(transform.localPosition, rigidbody.velocity*speed);
    }

    private float hitFactor(Vector3 ballPos, Vector3 racketPos, float racketWidth)
    {
        return (ballPos.x-racketPos.x)/racketWidth;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")  
        {
             x = hitFactor(transform.localPosition,
                collision.transform.localPosition,
                collision.collider.bounds.size.x);
            dir = new Vector3(x, transform.position.y, 1).normalized;
            Debug.DrawLine(transform.position, transform.position + dir * speed,Color.red);
            rigidbody.velocity = dir * speed;

            scoreActions.AddLeftScore();
        }
        if(collision.gameObject.name == "Wall_right")
        {
            dir = Vector3.Reflect(rigidbody.velocity, Vector3.right);
            //Debug.DrawLine(transform.position, transform.position + dir * speed,Color.green);
            dir = dir.normalized;
            rigidbody.velocity = dir * speed;
        }
        if (collision.gameObject.name == "Wall_left")
        {
            dir = Vector3.Reflect(rigidbody.velocity, Vector3.left);
            //Debug.DrawLine(transform.position, transform.position + dir * speed, Color.green);
            dir = dir.normalized;
            rigidbody.velocity = dir * speed;
        }
        if (collision.gameObject.name == "Wall_forward")
        {
            dir = Vector3.Reflect(rigidbody.velocity, Vector3.forward);
            //Debug.DrawLine(transform.position, transform.position + dir * speed, Color.green);
            dir = dir.normalized;
            rigidbody.velocity = dir * speed;
        }
        if (collision.gameObject.name == "Wall_back")
        {
            dir = Vector3.Reflect(rigidbody.velocity, Vector3.back);
            //Debug.DrawLine(transform.position, transform.position + dir * speed, Color.green);
            dir = dir.normalized;
            rigidbody.velocity = dir * speed;

            scoreActions.AddRightScore();
        }
        if (speed < 50) speed += 0.1f;
        
    }
}
