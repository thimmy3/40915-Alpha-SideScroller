using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace CodysCode
{
    public class MenuHandler : MonoBehaviour
    {

        public Resolution[] resolutions;
        public TMP_Dropdown resolution;
        public GameObject pausePanel;
        public bool isPaused;
        public GameObject optionsMenu ;
       // public bool OptionMenuActive;
        private void Start()
        {
           // pausePanel.SetActive(false);
           // optionsMenu.SetActive(false);
            resolutions = Screen.resolutions;
            resolution.ClearOptions();
            List<string> options = new List<string>();
            int currentResolutionIndex = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;
                options.Add(option);
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;

                }

            }
            resolution.AddOptions(options);
            resolution.value = currentResolutionIndex;
            resolution.RefreshShownValue();



        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution res = resolutions[resolutionIndex];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen);

        }

        public void Quality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);

        }

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;

        }

        public void Paused()
        {
            isPaused = true;

            Time.timeScale = 0;

            pausePanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        }

        public void UnPaused()
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;


        }
        private void TogglePause()
        {
            if (!isPaused)
            {
                Paused();



            }

            else if(isPaused)
            {
                UnPaused();

            }
            else 
            {
               Debug.LogError("THeres a problem Here");
            }


        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !optionsMenu.activeSelf)
            {
                TogglePause();
/*
                if (!isPaused)
                    Paused();

                else
                {
                    UnPaused();
                }
                */
            }
        }

        public void LoadScene(int scene)
        {
            SceneManager.LoadScene(scene);


        }

    }
}
