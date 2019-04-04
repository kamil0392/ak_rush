using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public void tryAgain()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
