using UnityEngine;

public class PlayerStateController : MonoBehaviour
{

    public static PlayerStateController instance = null;

    public int score = 0;
    public int coins = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void AddScorePoint()
    {
        score++;
    }

    public void AddCoin()
    {
        coins++;
    }
}
