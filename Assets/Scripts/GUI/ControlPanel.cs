using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Model;
using SolarSystem.Controller;
using UnityEngine.UI;

namespace SolarSystem.GUI
{
    /// <summary>
    /// Manages solar control panel
    /// </summary>
    public sealed class ControlPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject planetPanel;
        private bool showing = false;
        private bool showInfo = false;
        private bool showOptions = false;

        [SerializeField]
        private RectTransform planetContent;

        [SerializeField]
        private Scrollbar scrollBar;

        [SerializeField]
        private RectTransform scrollView;
        private string buttonPrefabString = "PlanetButton";

        [SerializeField]
        private bool showPlanetText = false;
        private CameraAnimation animator;

        [SerializeField]
        private GameObject infoPanel;

        [SerializeField]
        private GameObject optionsPanel;

        //setup panel
        private void Awake()
        {
            showing = planetPanel.activeSelf;

            //create planets buttons
            var modelList = SolarMathModel.objects3D();

            //go to all and create buttons
            for (int i = 0; i < modelList.Count; ++i)
            {
                var visualObject = modelList[i];

                if (visualObject != null)
                {
                    var sprite = Resources.Load<Sprite>("Textures/" + visualObject.objectType().ToString());

                    if (sprite)
                    {
                        var prefab = Instantiate(Resources.Load<GameObject>("Prefabs/" + buttonPrefabString)) as GameObject;

                        if (prefab)
                        {
                            prefab.transform.SetParent(planetContent);

                            //set prefab image
                            var image = prefab.GetComponent<Image>();

                            if (image)
                                image.overrideSprite = sprite;

                            //set prefab text
                            var planetText = prefab.GetComponentInChildren<Text>();

                            if (planetText)
                            {
                                planetText.text = visualObject.objectType().ToString();
                                prefab.name = planetText.text;
                                prefab.GetComponent<PlanetButton>().SolarObject = visualObject;
                                prefab.GetComponent<Button>().onClick.AddListener(onPlanetButtonClicked);

                                if (!showPlanetText)
                                    planetText.enabled = false;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Init
        /// </summary>
        private void Start()
        {
            animator = SolarMathModel.CameraController.gameObject.GetComponent<CameraAnimation>();

            if (!animator)
                Debug.Log("No animator on camera");
        }

        /// <summary>
        /// Planet list button clicked
        /// </summary>
        public void showPlanets()
        {
            if (planetPanel)
            {
                showing = !showing;
                planetPanel.SetActive(showing);
            }
        }

        /// <summary>
        /// Planet button pressed
        /// </summary>
        public void onPlanetButtonClicked()
        {
            var planetButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<PlanetButton>();

            if (planetButton)
                animator.lookAt(planetButton.SolarObject.objectType());
        }

        /// <summary>
        /// Info button pressed
        /// </summary>
        public void onInfoButtonClicked()
        {
            optionsPanel.SetActive(false);
            showOptions = false;

            if (!showInfo)
                showInfo = true;
            else
                showInfo = false;

            infoPanel.SetActive(showInfo);
        }

        /// <summary>
        /// Options button clicked
        /// </summary>
        public void onOptionsClicked()
        {
            infoPanel.SetActive(false);
            showInfo = false;

            if (!showOptions)
                showOptions = true;
            else
                showOptions = false;

            optionsPanel.SetActive(showOptions);
        }
    }
}
