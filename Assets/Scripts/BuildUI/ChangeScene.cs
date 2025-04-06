using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameObject taskOne;
    public GameObject taksTwo;
    public GameObject taskThree;
    public GameObject taskFour;

    private GameObject currentCanvas;

    private void Start()
    {
        currentCanvas = taskOne;
        currentCanvas.SetActive(true);
        taksTwo.SetActive(false);
        taskThree.SetActive(false);
        taskFour.SetActive(false);
    }

    public void ChangeCanvas(GameObject canvas)
    {
        currentCanvas.SetActive(false);
        currentCanvas = canvas;
        currentCanvas.SetActive(true);
    }
}
