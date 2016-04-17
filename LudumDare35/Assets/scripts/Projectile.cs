using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float secondsAfterDestroy = -1f;
    public int damages;
    public AnimationClip onDestroy;
    private Animator animator;

	// Use this for initialization
	void Start () {
        if (secondsAfterDestroy > 0f)
            StartCoroutine(destroyAfterFew());
        animator = gameObject.GetComponent<Animator>();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Ennemy hitted = coll.gameObject.GetComponent<Ennemy>();

        DestroyObject(gameObject.GetComponent<Rigidbody2D>());
        if (hitted != null)
        {
            hitted.hitPoints -= damages;
        }
        StartCoroutine(destroyAnimated());
    }

    public IEnumerator destroyAnimated()
    {
        if (onDestroy != null && animator != null)
        {
            animator.SetBool("Dead", true);
            DestroyObject(gameObject.GetComponent<Collider2D>());
            yield return new WaitForSeconds(onDestroy.length);
        }
        else
            yield return new WaitForSeconds(0.05f);
        DestroyImmediate(gameObject);
    }

    public IEnumerator destroyAfterFew()
    {
        yield return new WaitForSeconds(secondsAfterDestroy);
        StartCoroutine(destroyAnimated());
    }
}
