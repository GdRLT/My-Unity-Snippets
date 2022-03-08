using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    #region Singleton
    private static Options _instance;
    public static Options Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    public Toggle panelToggle;
    public GameObject optionPanel;
    public Slider music;
    public Slider sound;
    public Toggle autoLoot;
    public AudioManager audioManager;
    public void ToggleAutoLoot()
    {
        GetComponent<AutoLoot>().autoLootToogle = autoLoot.isOn;
    }
    public void SetMusicVolume(float sliderValue)
    {
        audioManager.audioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSFXVolume(float sliderValue)
    {
        audioManager.audioMixer.SetFloat("Sounds", Mathf.Log10(sliderValue) * 20);
    }

    public void ActivePanel(bool act)
    {
        optionPanel.SetActive(act);
    }

    private void Update()
    {
        HideIfClickedOutside(optionPanel.gameObject, panelToggle.gameObject);
    }
    private void HideIfClickedOutside(GameObject panel,GameObject toggle)
    {
        if (Input.GetMouseButton(0)
            && panel.activeSelf
            && !RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(),Input.mousePosition)
            && !RectTransformUtility.RectangleContainsScreenPoint(toggle.GetComponent<RectTransform>(), Input.mousePosition))
        {
            panelToggle.isOn = false;
        }
    }
}
