using UnityEngine;

public class Menu_manager : MonoBehaviour
{
    public GameObject Menu_background_container;
    private CanvasGroup canvasGroup;

    // Update is called once per frame
    void Start()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleMenu();
        }
    }
    private void ToggleMenu()
    {
        if (canvasGroup.alpha == 1f)
        {
            canvasGroup.alpha = 0f;
            Time.timeScale = 1;
        }
        else if (canvasGroup.alpha == 0f)
        {
            Time.timeScale = 0;
            canvasGroup.alpha = 1f;
        }
    }
}
