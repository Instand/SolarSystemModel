using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SolarSystem.Model;
using SolarSystem.Core;

namespace SolarSystem.GUI
{
    /// <summary>
    /// Represents options controller
    /// </summary>
    public class Options : MonoBehaviour
    {
        [SerializeField]
        private GameObject graphicsButton;
        private Text graphicsText = null;

        [SerializeField]
        private GameObject antialiasingButton;
        private Text antialiasingText = null;
        private string[] qualityNames;
        private int currentGraphicsLevel = 0;
        private int antialiasing = 0;

        [SerializeField]
        private Slider speedSlider;

        [SerializeField]
        private Slider scaleSlider;

        // Use this for initialization
        private void Start()
        {
            qualityNames = QualitySettings.names;
            currentGraphicsLevel = QualitySettings.GetQualityLevel();

            graphicsText = graphicsButton.GetComponentInChildren<Text>();
            graphicsText.text = qualityNames[currentGraphicsLevel];

            antialiasingText = antialiasingButton.GetComponentInChildren<Text>();
            antialiasingText.text = GetAntialiasingString(antialiasing);
        }

        //returns string representation of antialiasing
        private string GetAntialiasingString(int value)
        {
            switch (value)
            {
                case 0:
                    return "None";

                case 2:
                    return "x2";

                case 4:
                    return "x4";

                case 8:
                    return "x8";

                default:
                    return "None";
            }
        }

        //next step
        private void AddAntialiasing()
        {
            switch (antialiasing)
            {
                case 0:
                    antialiasing = 2;
                    break;

                case 2:
                    antialiasing = 4;
                    break;

                case 4:
                    antialiasing = 8;
                    break;

                case 8:
                    antialiasing = 0;
                    break;

                default:
                    break;
            }
        }

        private void CheckAntialiasing()
        {
            if (antialiasing > 8)
                antialiasing = 0;
        }

        /// <summary>
        /// Antialiasing button clicked
        /// </summary>
        public void OnAntialiasingClicked()
        {
            //ui
            AddAntialiasing();
            CheckAntialiasing();
            antialiasingText.text = GetAntialiasingString(antialiasing);

            //apply
            QualitySettings.antiAliasing = antialiasing;
        }

        /// <summary>
        /// Change graphics
        /// </summary>
        public void OnGraphicsClicked()
        {
            ++currentGraphicsLevel;

            if (currentGraphicsLevel >= qualityNames.Length)
                currentGraphicsLevel = 0;

            //apply
            QualitySettings.SetQualityLevel(currentGraphicsLevel, true);

            //ui
            graphicsText.text = qualityNames[currentGraphicsLevel];
        }

        /// <summary>
        /// Change solar system speed
        /// </summary>
        /// <param name="value"></param>
        public void OnSolarSpeedChanged()
        {
            var result = Values.startSpeed * speedSlider.value * 0.02f;

            SolarMathModel.SetSolarSystemSpeed(result);
        }

        /// <summary>
        /// Change solar system scale
        /// </summary>
        /// <param name="value"></param>
        public void OnSolarScaleChanged()
        {
            var result = Values.startSize * scaleSlider.value * 0.02f;

            SolarMathModel.ChangeSolarSystemScale(result);
        }
    }
}
