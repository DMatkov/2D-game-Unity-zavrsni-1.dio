using UnityEngine;
using UnityEngine.SceneManagement;

public class ZavrsetakIgre : MonoBehaviour
{
    private void OnGUI()
    {
        //private GUIStyle button;
        GUIStyle gumbovi = new GUIStyle(GUI.skin.button);
        gumbovi.fontSize = 24;

        GUI.contentColor = Color.white;
        if (GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 200, 250, 90), "Restart", gumbovi)) {
            SceneManager.LoadScene(0); //prototype scena
        }

        if (GUI.Button(new Rect(Screen.width / 2 + 60, Screen.height / 2 + 200, 250, 90), "Quit", gumbovi)){
            Application.Quit();
        }
    }
}
