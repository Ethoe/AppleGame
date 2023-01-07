using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenTog;
    public ResItem[] resolutions;
    public Text resolutionLabel;
    private int selectedResolution;

    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = resolutions.Length - 1;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution >= resolutions.Length)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        ResItem curr = resolutions[selectedResolution];
        resolutionLabel.text = curr.horizontal.ToString() + "x" + curr.vertical.ToString();
    }

    public void ApplyGraphics()
    {
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }
}



[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}