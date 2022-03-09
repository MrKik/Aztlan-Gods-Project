using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCount : MonoBehaviour
{
    public TextMeshProUGUI txtCountCocoa;
    private int initialCocoa = 0;
    // Start is called before the first frame update
    void Start()
    {
        txtCountCocoa.text = initialCocoa.ToString();
    }

    public void UpdateCocoa(int currentCocoa)
    {
        txtCountCocoa.text = currentCocoa.ToString();
    }
}