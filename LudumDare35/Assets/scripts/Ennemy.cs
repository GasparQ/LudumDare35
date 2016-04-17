using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour {
    public int hitPoints = 10;
    public float speed = 0.5f;
    public Vector2 direction = Vector2.left;
    public float maxX;
    public float minX;
    public int damages = 1;
    public AnimationClip dyingAnimation;
    private Vector3 veryFirstPos;
    private bool dead = false;
    private Rigidbody2D rb;
    private Animator animator;

	// Use this for initialization
	void Start () {
        veryFirstPos = transform.position;
        rb = transform.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!dead)
        {
            rb.velocity = new Vector3(direction.x * speed, rb.velocity.y);
            if (transform.position.x > veryFirstPos.x + maxX)
            {
                direction = Vector2.left;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (transform.position.x < veryFirstPos.x + minX)
            {
                direction = Vector2.right;
                transform.rotation = new Quaternion(0, -90, 0, 0);
            }
            if (hitPoints <= 0)
                StartCoroutine("onDying");
        }
	}

    IEnumerator onDying()
    {
        dead = true;
        if (dyingAnimation != null)
        {
            animator.SetBool("Dead", true);
            Destroy(gameObject.GetComponent<Collider2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            yield return new WaitForSeconds(dyingAnimation.length);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Blob hitted = coll.gameObject.GetComponent<Blob>();

        if (hitted != null)
        {
            hitted.hitPoints -= damages;
        }
    }
}
