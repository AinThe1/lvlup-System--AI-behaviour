using UnityEngine;
using UnityEngine.SceneManagement;

public class FuctionButtons : MonoBehaviour
{
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}