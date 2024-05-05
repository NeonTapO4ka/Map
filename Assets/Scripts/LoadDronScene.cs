using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDronScene : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("DroneScene");
    }
}
