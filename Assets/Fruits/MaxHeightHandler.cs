using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaxHeightHandler : MonoBehaviour
{
    private bool _inGame = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(EnableInGame());
        }
    }

    private IEnumerator EnableInGame()
    {
        yield return new WaitForSeconds(2f);
        _inGame = true;
    }

    private void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void Check(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish") && _inGame)
        {
            RestartScene();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //TODO Make it fancier
        Check(other);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Check(other);
    }
}
