using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SettingsCube : MonoBehaviour
{
    public GameObject MainMenuPlayer;
    public TMP_InputField NicknameEntry;
    public Slider CameraSensitivitySlider;

    private void Start()
    {
        MainMenuPlayer.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        NicknameEntry.text = DataManager.Instance.User.Name;
        SetCameraSensitivityValue(DataManager.Instance.Settings.CameraSensitivity);
    }

    public void Cube_SaveSettings()
    {
        if (!string.IsNullOrEmpty(NicknameEntry.text))
        {
            DataManager.Instance.User.Name = NicknameEntry.text;
        }

        DataManager.Instance.Settings.CameraSensitivity = CameraSensitivitySlider.value;
        DataManager.Instance.SaveGame();

        MainMenuPlayer.GetComponent<ThirdPersonController>().CameraSensitivity = 
            DataManager.Instance.Settings.CameraSensitivity;
    }

    public void Cube_ResetSavegame()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Savegame deleted. Exit game");
        Application.Quit();
    }

    public void Cube_ChangeSliderText()
    {
        CameraSensitivitySlider.GetComponentInChildren<TMP_Text>().text =
            $"Camera sensitivity: {CameraSensitivitySlider.value.ToString("00.00")}";
    }

    private void SetCameraSensitivityValue(float value)
    {
        CameraSensitivitySlider.value = value;

        CameraSensitivitySlider.GetComponentInChildren<TMP_Text>().text = 
            $"Camera sensitivity: {value}";
    }
}
