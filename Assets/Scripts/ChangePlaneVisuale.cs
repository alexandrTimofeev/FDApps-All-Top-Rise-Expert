using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ChangePlaneVisuale : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> PaperPlanes;
    [SerializeField] private GameObject SimplePlane;
    [SerializeField] private GameObject FuturePlane;

    private int currentState = 0; 

    public void TogglePlaneVisual()
    {
        switch (currentState)
        {
            case 0: 
                foreach (var mesh in PaperPlanes)
                {
                    if (mesh != null)
                        mesh.enabled = false;
                }

                if (SimplePlane != null)
                    SimplePlane.SetActive(true);

                if (FuturePlane != null)
                    FuturePlane.SetActive(false);

                currentState = 1;
                break;

            case 1: 
                if (SimplePlane != null)
                    SimplePlane.SetActive(false);

                if (FuturePlane != null)
                    FuturePlane.SetActive(true);

                currentState = 2;
                break;
        }
    }

    public void ResetToMeshes()
    {
        if (SimplePlane != null)
            SimplePlane.SetActive(false);

        if (FuturePlane != null)
            FuturePlane.SetActive(false);

        foreach (var mesh in PaperPlanes)
        {
            if (mesh != null)
                mesh.enabled = true;
        }

        currentState = 0;
    }

    public int GetCurrentState()
    {
        return currentState;
    }
}