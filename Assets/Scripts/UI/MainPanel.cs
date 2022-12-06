using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [Header("Music")]
    public Slider volume;
    public AudioMixer volumen;
    public Slider effects;
    public AudioMixer efectos;
    public AudioSource btn;
    public AudioClip btnsound;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject levelPanel;
    public GameObject level2Panel;
    public GameObject optionsPanel;
    public GameObject musicPanel;
    public GameObject creditsPanel;
    public GameObject segundomodo;

    public void Awake()
    {
        volume.onValueChanged.AddListener(ChangeVolume);
        effects.onValueChanged.AddListener(ChangeFX);
    }
    public void OpenPanel (GameObject panel)
    {
        mainPanel.SetActive(false);
        levelPanel.SetActive(false);
        level2Panel.SetActive(false);
        optionsPanel.SetActive(false);
        musicPanel.SetActive(false);
        creditsPanel.SetActive(false);
        segundomodo.SetActive(false);

        panel.SetActive(true);
        Botnsound();
    }
    public void ChangeVolume (float y)
    {
        volumen.SetFloat("VolumenMixer", y);
    }

    public void ChangeFX(float y)
    {
        efectos.SetFloat("EfectosMixer", y);
    }
    public void Botnsound()
    {
        btn.PlayOneShot(btnsound);
    }
}
