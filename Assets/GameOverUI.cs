using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{

    GameObject gameOverUI;
    bool isUIOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (StartMenu.instance.gameOver && !isUIOpen)
        {
            gameOverUI = Instantiate(Resources.Load("GameOverSign") as GameObject, gameObject.transform.position + new Vector3(0, 0, 1), transform.rotation);
            gameOverUI.transform.parent = gameObject.transform;
            isUIOpen = true;
        }
    }
}
