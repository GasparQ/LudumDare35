using UnityEngine;
using System.Collections;

public class Blob : MonoBehaviour {

    public float metamorphRate = 0.5f;
    public float speed = 2f;
    public float jumpStrength = 2f;
    public float fireRate = 0.5f;
    public GameObject[] metamorphs;
    public int hitPoints = 100;
    private int currIndex;
    private Rigidbody2D rb;
    private SpriteRenderer render;
    private Animator animator;
    private float nextMetamorph;
    private float nextFire;
    private Vector3 direction = Vector3.right;

	// Use this for initialization
	void Start () {
        if (metamorphs.Length == 0)
            throw new MissingComponentException("Enter at least one metamorphosis");
        currIndex = 0;
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        nextMetamorph = 0f;
        nextFire = 0f;
        UpdateRenders();
	}
	
	// Update is called once per frame
	void Update () {
        if (isGrounded() && Input.GetAxis("Jump") > 0)
        {
            rb.velocity = new Vector2(0, jumpStrength);
        }
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (rb.velocity.x < 0)
        {
            render.flipX = false;
            //transform.rotation = new Quaternion(0, 0, 0, 0);
            direction = Vector3.left;
        }
        else if (rb.velocity.x > 0)
        {
            render.flipX = true;
            //transform.rotation = new Quaternion(0, -90, 0, 0);
            direction = Vector3.right;
        }
        if (Time.time >= nextMetamorph)
        {
            if (Input.GetKey("up"))
            {
                nextMetamorph = Time.time + metamorphRate;
                currIndex = (currIndex + 1) % metamorphs.Length;
            }
            else if (Input.GetKey("down"))
            {
                nextMetamorph = Time.time + metamorphRate;
                if (currIndex == 0)
                    currIndex = metamorphs.Length;
                currIndex = (currIndex - 1);
            }
        }
        if (Time.time >= nextFire && Input.GetKey("e"))
        {
            nextFire = Time.time + fireRate;
            metamorphs[currIndex].GetComponent<GenericBlob>().Shoot(transform.position, transform.rotation, direction, render.flipX);
        }
        UpdateRenders();
	}

    private void UpdateRenders()
    {
        render.sprite = metamorphs[currIndex].GetComponent<SpriteRenderer>().sprite;
        animator.runtimeAnimatorController = metamorphs[currIndex].GetComponent<Animator>().runtimeAnimatorController;
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y * 0.55f + 0.1f, LayerMask.GetMask("Ground"));
        return (hit.rigidbody != null);
    }

	void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "spike")
            hitPoints = 0;
    }
}
