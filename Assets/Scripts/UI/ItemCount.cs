using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemCount : MonoBehaviour
{
    // this is the script to update the UI element of the itemcount

    public TextMeshProUGUI txtCountCocoa;

    public void UpdateCocoa(int currentCocoa)
    {
        txtCountCocoa.text = currentCocoa.ToString();
    }
}