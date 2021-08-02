using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Sphere> spheres;
    public StartingPoint startingPoint;
    public SideCamera sideCamera;
    public CameraController cameraController;
    public CheckpointSystem checkpointSystem;
    public FinishLine finishLine;
    public HUD hud;
    public List<Fluid> fluids;
    public string menuSceneName;
    public string selectedCharacterDataName;
    public string nextLevelName;
    private int selectedCharacter;

    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName, 0);
        checkpointSystem.SetSpheres(spheres);
        if(fluids != null)
        {
            for (int i = 0; i < fluids.Count; i++)
            {
                fluids[i].SetSpheres(spheres);
            }
        }        
        
        spheres[selectedCharacter].SetPlayerStatus(true);
        cameraController.SetPlayerTransform(spheres[selectedCharacter].transform);
        if(sideCamera != null)
        {
            sideCamera.SetPlayerTransform(spheres[selectedCharacter].transform);
        }
        ArrangeSpheres();
    }


    void Update()
    {
        hud.UpdateSphereOrder(checkpointSystem.SphereOrder);
        hud.UpdateEndResult(finishLine.PlayerReachedEnd, finishLine.FinishOrder, finishLine.PlayerIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(menuSceneName);
    }
 
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    private void ArrangeSpheres()
    {
        if(startingPoint != null)
        {
            startingPoint.SetCurrentArrangement();
            for (int i = 0; i < spheres.Count; i++)
            {
                spheres[i].transform.position = startingPoint.CurrentArrangement[i];
            }
        }       
    }

    public void RespawnRequest()
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            if (spheres[i].IsPlayer)
            {
                spheres[i].Respawn();
            }
        }
    }
}
