using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject alikopterPrefab;
    [SerializeField] private Vector3 prefabOffSet;

   

    
    private GameObject alikopter;
    private ARTrackedImageManager aRTrackedImageManager;
   

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            alikopter = Instantiate(alikopterPrefab,image.transform);
            alikopter.transform.position += prefabOffSet;

        }
    }
}