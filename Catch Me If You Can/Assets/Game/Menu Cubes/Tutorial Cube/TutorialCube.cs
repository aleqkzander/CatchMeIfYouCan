using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Open tutorial scene: Currently beeing refactored...");
        return;
        SceneManager.LoadScene(1);
    }
}
