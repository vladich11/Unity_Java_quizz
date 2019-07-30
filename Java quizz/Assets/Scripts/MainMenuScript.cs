using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void StartAbout()
    {
        SceneManager.LoadScene("About");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
