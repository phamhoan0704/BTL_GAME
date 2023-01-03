using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class optionsMenu_controller : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public GameObject optionsMenu;
    private bool menuState = false;
    // Start is called before the first frame update
    void Start()
    {

        optionsMenu.SetActive(menuState);

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            menuState = !menuState;
            optionsMenu.SetActive(menuState);
        }

    }
}
