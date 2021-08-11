using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
     EventSystem m_EventSystem;
     
    // Start is called before the first frame update
    public Transform selectionPoint;
    
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
        
    }
    void Start()
    {
         m_Raycaster = GetComponent<GraphicRaycaster>();
       
          m_EventSystem = GetComponent<EventSystem>();

           m_PointerEventData = new PointerEventData(m_EventSystem);

           m_PointerEventData.position = selectionPoint.position;
        
        
    }

    public bool OnEntered(GameObject button)
    {
        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();
     
        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            if (result.gameObject == button)
            {
                return true;
            }
        }
        return false;
    }
}
