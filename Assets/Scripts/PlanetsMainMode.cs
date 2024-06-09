using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using RotaryHeart.Lib.SerializableDictionary;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class PlanetPrefabDictionary : SerializableDictionaryBase<string, GameObject> { }


public class PlanetsMainMode : MonoBehaviour
{

    [SerializeField] PlanetPrefabDictionary planetPrefabs;
    [SerializeField] ARTrackedImageManager imageManager;
    [SerializeField] TMP_Text planetName;
    [SerializeField] Toggle infoButton;
    [SerializeField] GameObject detailsPanel;
    [SerializeField] TMP_Text detailsText;
    Camera camera;
    int layerMask;

    private void Start()
    {
        camera = Camera.main;
        layerMask = 1 << LayerMask.NameToLayer("PlacedObjects");
    }

    private void OnEnable()
    {
        detailsPanel.SetActive(false);
        planetName.text = "";
        infoButton.interactable = false;
        UIController.ShowUI("Main");
        foreach (ARTrackedImage image in imageManager.trackables)
        {
            InstantiatePlanet(image);
        }
        imageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    void InstantiatePlanet(ARTrackedImage image)
    {
        string name =image.referenceImage.name.Split('-')[0];
        if (image.transform.childCount == 0)
        {
            GameObject planet =Instantiate(planetPrefabs[name]);
            planet.transform.SetParent(image.transform,false);
        }
        else
        {
            Debug.Log($"{name} already instantiated");
        }
    }

    void OnTrackedImageChanged (ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage newImage in eventArgs.added)
        {
            InstantiatePlanet(newImage);
        }
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    private void Update()
    {
        if (imageManager.trackables.count == 0)
        {
            InteractionController.EnableMode("Scan");
        }
        else
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Planet planet = hit.collider.GetComponentInParent<Planet>();
                planetName.text = planet.planetName;
                detailsText.text = planet.description;
                infoButton.interactable = true;
            }

            else;
            {
                planetName.text = "";
                detailsText.text = "";
                infoButton.interactable = false;
            }

        }
    }

}
