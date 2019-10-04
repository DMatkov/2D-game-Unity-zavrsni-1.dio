using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Coroutine : MonoBehaviour
{
    public static IEnumerator Cekaj2()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene("Prototype_1");
        Time.timeScale = 1;

    }
}