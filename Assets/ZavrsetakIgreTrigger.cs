using UnityEngine;
using UnityEngine.SceneManagement;

public class ZavrsetakIgreTrigger : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Igrac")
        {
            SceneManager.LoadScene("EndMenu");
        }
    }

    void Update()
    {
        bool escape = Input.GetKeyDown(KeyCode.Escape);

        if (escape) {
            SceneManager.LoadScene("Menu");
        }
    }
}
