using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnergySystem : MonoBehaviour
{
    public int maxEnergy = 6;
    public int currentEnergy;
    public Image energy;
    public Sprite fullEnergy;
    public Sprite f_1Energy;
    public Sprite f_2Energy;
    public Sprite f_3Energy;
    public Sprite f_4Energy;
    public Sprite f_5Energy;
    public Sprite emptyEnergy;

    [Header("Save/Load variables")]
    private string energyPrefsName = "energy";

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.DeleteKey(energyPrefsName);
        }

        LoadEnergyData();

        UpdateEnergyUI(true);
        Debug.Log(currentEnergy);
    }
    public void UpdateEnergyUI(bool moreEnergy)
    {
        Debug.Log(currentEnergy);
        if (moreEnergy)
        {
            currentEnergy++;
        }
        else
        {
            currentEnergy--;
        }

        //if (currentEnergy > maxEnergy)
        //{
        //    currentEnergy = maxEnergy;
        //}

        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);

        switch (currentEnergy)
        {
            case 0:
                energy.sprite = emptyEnergy;
                break;
            case 1:
                energy.sprite = f_5Energy;
                break;
            case 2:
                energy.sprite = f_4Energy;
                break;
            case 3:
                energy.sprite = f_3Energy;
                break;
            case 4:
                energy.sprite = f_2Energy;
                break;
            case 5:
                energy.sprite = f_1Energy;
                break;
            case 6:
                energy.sprite = fullEnergy;
                break;
        }
    }

    public void SaveEnergyData()
    {
        PlayerPrefs.SetInt(energyPrefsName, currentEnergy);
    }

    public void LoadEnergyData()
    {
        currentEnergy = PlayerPrefs.GetInt(energyPrefsName, -1);
    }
}