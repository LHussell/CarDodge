using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCountSpawner : MonoBehaviour
{

    GameObject number;
    int score;

    void Start()
    {
        score = ScoreCounter.instance.score;
        number = Instantiate(Resources.Load("Numbers/0") as GameObject, transform.position, transform.rotation);
        number.transform.localScale += new Vector3(-0.7f, -0.7f, -0.7f);
    }

    private void FixedUpdate()
    {
        var currentScore = ScoreCounter.instance.score;
        if (score != currentScore)
        {
            Destroy(number);
            number = Instantiate(Resources.Load("Numbers/" + currentScore) as GameObject, transform.position, gameObject.transform.rotation);
            number.transform.localScale += new Vector3(-0.7f, -0.7f, -0.7f);
        }
    }
}
