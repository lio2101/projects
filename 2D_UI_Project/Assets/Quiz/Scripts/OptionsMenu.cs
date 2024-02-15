// OptionsMenu.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    Resolution[] availableResolutions;  // Array to store available resolutions
    [SerializeField] private Dropdown resolutionsDropdown;  // Dropdown UI component for selecting resolutions
    [SerializeField] private AudioMixer audioMixer;  // Reference to the AudioMixer component


    // Method to set the resolution based on the selected index in the dropdown
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = availableResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Method to set the volume level of the audio mixer
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    // Method to set the fullscreen mode
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    void Start()
    {
        availableResolutions = Screen.resolutions;  // Get available resolutions
        resolutionsDropdown.ClearOptions();  // Clear existing options in the dropdown

        List<string> options = new List<string>();  // List to store resolution options
        int currentResolutionIndex = 0;  // Variable to track the index of the current resolution

        for (int i = 0; i < availableResolutions.Length; i++)
        {
            string option = availableResolutions[i].width + " x " + availableResolutions[i].height;  // Create the resolution option string
            options.Add(option);  // Add the option to the list

            // Check if the current resolution matches the option being iterated
            if (availableResolutions[i].width == Screen.currentResolution.width &&
                availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;  // Set the index to the current resolution
            }
        }

        resolutionsDropdown.AddOptions(options);  // Add the resolution options to the dropdown
        Debug.Log("Number of options: " + options.Count);

        resolutionsDropdown.value = currentResolutionIndex;  // Set the initial value of the dropdown to the current resolution
        resolutionsDropdown.RefreshShownValue();  // Refresh the displayed value of the dropdown
    }

}
