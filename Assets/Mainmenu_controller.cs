using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mainmenu_controller : MonoBehaviour
{
    void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void ExitGame()
    {
        #if UNITY_EDITOR
        
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        {
                Application.Quit();

#endif

        }
    


}
