using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCode : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("_Meny");
    }
}
