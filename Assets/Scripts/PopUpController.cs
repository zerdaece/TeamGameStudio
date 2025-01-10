using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private TMP_Text descriptionText; // Reference to the description text
    [SerializeField] private Button LeftButton;
    [SerializeField] private Button RightButton;

    public void Setup(string description, string LeftButtonText, string RightButtonText, System.Action LeftButtonAction, System.Action RightButtonAction)
    {
        // Set the description text
        descriptionText.text = description;

        // Set button texts
        LeftButton.GetComponentInChildren<TMP_Text>().text = LeftButtonText;
        RightButton.GetComponentInChildren<TMP_Text>().text = RightButtonText;

        // Assign button actions
        LeftButton.onClick.RemoveAllListeners();
        LeftButton.onClick.AddListener(() => LeftButtonAction?.Invoke());

        RightButton.onClick.RemoveAllListeners();
        RightButton.onClick.AddListener(() => RightButtonAction?.Invoke());
    }
}

