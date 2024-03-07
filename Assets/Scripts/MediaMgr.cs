using UnityEngine;
using UnityEngine.SceneManagement;

public class MediaMgr : MonoBehaviour
{
    public bool isShowingInfo = false;
    public GameObject infoPanel;
    
    void Start()
    {
        infoPanel = GameObject.Find("InfoPanel");
        infoPanel.SetActive(false);
    }

    void Update()
    {
       
    }
    
    public void ShowHideInfo()
    {
        Debug.Log("MediaMgr.ShowInfo() called");
        isShowingInfo = !isShowingInfo;
        infoPanel.SetActive(isShowingInfo);
    }
}