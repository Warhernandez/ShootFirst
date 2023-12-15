using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue = 1; // The score value to give the player when the target is hit.
    private Explodable Explodable;
    //public Animator animator;

    private void Start()
    {
        Explodable = GetComponent<Explodable>();
    }
    public void HitTarget()
    {
        //PlayHitAnimation();
        //For handling animations and stuff later down the line.
        gameObject.SetActive(false);
    }

    public void Shatter()
    {

        Explodable.explode();
        ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
        ef.doExplosion(transform.position);
    }
}
