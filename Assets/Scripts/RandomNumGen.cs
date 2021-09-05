using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumGen : MonoBehaviour
{
    public static RandomNumGen instance;

    System.Random random;

    private void Awake()
    {

        random = new System.Random();


        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public int GetRandomNumber(int min, int max)
    {
        return random.Next(min, max);
    }


}
