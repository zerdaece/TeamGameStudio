using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PopUp : MonoBehaviour
{
    [SerializeField] private GameObject popupPrefab; // Assign in the Inspector
    private static PopUp instance;

    private void Awake()
    {
        // Set up the static instance
        instance = this;
    }

    public static void ShowPopup(string description, string LeftButtonText, string RightButtonText, System.Action button1Action, System.Action button2Action)
    {
        if (instance == null)
        {
            Debug.LogError("PopUp instance is not set up in the scene!");
            return;
        }

        // Instantiate the popup prefab
        GameObject popup = Instantiate(instance.popupPrefab, FindObjectOfType<Canvas>().transform);

        // Get the PopupController script on the instantiated popup
        PopupController popupController = popup.GetComponent<PopupController>();
        if (popupController != null)
        {
            // Set up the popup with dynamic content
            popupController.Setup(description, LeftButtonText, RightButtonText, button1Action, button2Action);
        }

        // Activate the popup GameObject
        popup.SetActive(true);
    }
public static void ClosePopUp()
{
    GameObject popup = GameObject.Find("Popup(Clone)");
    Destroy(popup);
}
}

