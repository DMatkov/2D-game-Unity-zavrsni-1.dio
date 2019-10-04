using UnityEngine;
using UnityEngine.SceneManagement;

//skripta za triggeranje siljaka
public class Opasno : MonoBehaviour
{

    
    void OnCollisionEnter2D(Collision2D siljci)
        {
            if (siljci.gameObject.tag == "Igrac")
            {
                StartCoroutine(Coroutine.Cekaj2());
            }
        }
    
}
