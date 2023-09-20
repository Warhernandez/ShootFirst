using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue = 1; // The score value to give the player when the target is hit.

    public void HitTarget()
    {
        //For handling animations and stuff later down the line.
        gameObject.SetActive(false);
    }
}
