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
            isUIOpen = true;
        } else if (StartMenu.instance.gameOver)
        {
            gameOverUI.transform.rotation = gameObject.transform.rotation;
            var cameraCenter = gameObject.transform.position + gameObject.transform.forward * 2;
            var currentPos = gameObject.transform.position;
            var direction = currentPos - cameraCenter;
            var targetPosition = cameraCenter + direction.normalized * 0.3f;
            gameOverUI.transform.position = Vector3.Lerp(currentPos, targetPosition, 0.5f);
        }


    }
}
