using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    private enum PanelState { NotShown, Shown }
    private PanelState CurrentPanelState;
    [SerializeField] private List<RectTransform> rankingImages;
    [SerializeField] private Vector3[] rankingPosition;
    [SerializeField] private Vector3[] finishRankingPosition;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject ranks;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] finishTexts;
    [SerializeField] private Button launchButton;
    [SerializeField] private Button respawnButton;
    [SerializeField] private List<Button> playerButtons;
    [SerializeField] private Image cameraIcon;
    [SerializeField] private AudioSource winAudio;
    [SerializeField] private Vector3 hidePosition;
    private bool endReached;
    private int playerIndex;
    private List<int> finishOrder;
    private List<int> sphereOrder;

    void Start()
    {
        sphereOrder = new List<int>();
    }

    void LateUpdate()
    {        
        if(CurrentPanelState == PanelState.NotShown)
        {
            AdjustRanking();
            ShowPlayerResult(playerIndex);
        }
        else if(CurrentPanelState == PanelState.Shown)
        {
            ShowRanking();
        }   
    }

    public void UpdateSphereOrder(List<int> order)
    {
        sphereOrder = order;
    }

    public void UpdateEndResult(bool endReached, List<int> finishOrder, int playerIndex)
    {
        this.endReached = endReached;
        this.finishOrder = finishOrder;
        this.playerIndex = playerIndex;
    }

    public void AdjustRanking()
    {
        if (sphereOrder != null && sphereOrder.Count > 1)
        {
            for (int i = 0; i < rankingImages.Count; i++)
            {                
                rankingImages[i].anchoredPosition = rankingPosition[sphereOrder[i]];
            }
            sphereOrder.Clear();
        }
        
    }

    public void DisableButton()
    {
        launchButton.interactable = false;
        respawnButton.interactable = true;
    }

    private void ShowPlayerResult(int number)
    {
        if (endReached)
        {
            panel.SetActive(true);
            text.text = finishTexts[number];
            if (number == 0)
            {
                winAudio.Play();
            }
            for (int i = 0; i < rankingImages.Count; i++)
            {
                rankingImages[i].position = hidePosition;
            }
            ranks.SetActive(false);
            for (int i = 0; i < playerButtons.Count; i++)
            {
                playerButtons[i].transform.position = hidePosition;
            }
            cameraIcon.transform.position = hidePosition;
            CurrentPanelState = PanelState.Shown;
        }
        
    }
   
    private void ShowRanking()
    {
        if (finishOrder.Count == 5)
        {
            for (int i = 0; i < rankingImages.Count; i++)
            {
                rankingImages[finishOrder[i]].anchoredPosition = finishRankingPosition[i];
            }
        }
    }
}
