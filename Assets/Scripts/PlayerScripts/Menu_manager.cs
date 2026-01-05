using UnityEngine;

public class Menu_manager : MonoBehaviour
{
    public GameObject Menu_background_container;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleMenu();
        }
    }
    private void ToggleMenu()
    {
        if (Menu_background_container.activeSelf == true)
        {
            Menu_background_container.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Menu_background_container.activeSelf == false)
        {
            Menu_background_container.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
