using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1;

    public void Hit(GameManager gameManager)
    {
        if (gameManager != null)
            gameManager.AddScore(scoreValue);

        Destroy(gameObject);
    }
}
