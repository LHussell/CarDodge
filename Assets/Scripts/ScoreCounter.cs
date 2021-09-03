using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    public static ScoreCounter instance = null;

    public int score = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void AddPoint()
    {
        score++;
    }
}
