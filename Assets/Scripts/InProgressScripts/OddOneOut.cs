using UnityEngine;

public class OddOneOut : MonoBehaviour
{
    public float shootingRange = 100f;
    public LayerMask targetLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, shootingRange, targetLayer);

        if (hit.collider != null)
        {
            Target target = hit.collider.GetComponent<Target>();
            if (target != null)
            {
                if (target.CompareTag("OddOneOut"))
                {
                    Debug.Log("You hit the odd one out!");
                }
                else
                {
                    Debug.Log("You hit the wrong target.");
                }
            }
        }
    }
}
