using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    #region Tooltip
    [Tooltip("Populate with the music vol level")]
    #endregion
    [SerializeField] private TextMeshProUGUI musicLevelText;
    #region Tooltip
    [Tooltip("Populate with the sounds vol level")]
    #endregion
    [SerializeField] private TextMeshProUGUI soundsLevelText;

    private void Start()
    {
        // Initially hide the pause menu
        gameObject.SetActive(false);
    }

    private IEnumerator InitializeUI()
    {
        // Wait a frame to ensure the previous music and sound levels have been set
        yield return null;

        // Initialise UI text
        soundsLevelText.SetText(SoundEffectManager.Instance.soundsVolume.ToString());
        musicLevelText.SetText(MusicManager.Instance.musicVolume.ToString());
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;

        // Initialise UI text
        StartCoroutine(InitializeUI());
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    // Quit and load main menu - linked to from pause menu UI button
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    // Increase music volume - linked to from music vol incraese button in UI
    public void IncreaseMusicVolume()
    {
        MusicManager.Instance.IncreaseMusicVolume();
        musicLevelText.SetText(MusicManager.Instance.musicVolume.ToString());
    }

    // Decrease music volume
    public void DecreaseMusicVolume()
    {
        MusicManager.Instance.DecreaseMusicVolume();
        musicLevelText.SetText(MusicManager.Instance.musicVolume.ToString());
    }

    // Increase music volume - linked to from music vol incraese button in UI
    public void IncreaseSoundsVolume()
    {
        SoundEffectManager.Instance.IncreaseSoundVolume();
        soundsLevelText.SetText(SoundEffectManager.Instance.soundsVolume.ToString());
    }

    // Decrease music volume
    public void DecreaseSoundsVolume()
    {
        SoundEffectManager.Instance.DecreaseSoundVolume();
        soundsLevelText.SetText(SoundEffectManager.Instance.soundsVolume.ToString());
    }

    #region Validation
#if UNITY_EDITOR

    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicLevelText), musicLevelText);
        HelperUtilities.ValidateCheckNullValue(this, nameof(soundsLevelText), soundsLevelText);
    }

#endif
    #endregion
}
