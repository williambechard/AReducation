using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UI_Overlay_Manager : MonoBehaviour
{

     
    [SerializeField] private TMPro.TMP_Text Materium_Text;
    [SerializeField] private Image Ship_Status;
    [SerializeField] private Image Engine_Status;
    [SerializeField] private Image Wave_Status;

    public GameObject WarningOverlay;
    public GameObject AlertIcon;
    public GameObject ShipAlerts;
    public GameObject SpaceAlerts;
    public float maxMarqueeTime;
    public float marqueeSpeed;
    public TextMeshProUGUI IncidentMessage;
    public Image IncidentPanelRenderer;
    public GameObject EmergencyPanel;
    Color origShipColor;

    public float ScrollSpeed = 10;
    private TextMeshProUGUI m_cloneTextObject;
    private RectTransform m_textRectTransform;
    
   

    private void Awake()
    {
        m_textRectTransform = IncidentMessage.GetComponent<RectTransform>();
        origShipColor = Ship_Status.color;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.OnMateriumChange += OnMateriumChange;
        GameManager.OnShipStatusChange += OnShipStatusChange;
        GameManager.OnEngineStatusChange += OnEngineStatusChange;
        GameManager.OnWaveStatusChange += OnWaveStatusChange;
       // GameLoop.OnIncident += OnIncident;
        IncidentPanelRenderer = IncidentMessage.GetComponentInParent<Image>();

        

    }

    public void OnIncident(string msg)
    {

        IncidentPanelRenderer.color = new Color(IncidentPanelRenderer.color.r, IncidentPanelRenderer.color.g, IncidentPanelRenderer.color.b, 1);

        //add AlertIcon
        if (AlertIcon != null)
        {
            GameObject g = Instantiate(AlertIcon);
            g.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
           
            g.transform.SetParent(ShipAlerts.transform);
            g.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
           
            //LayoutRebuilder.ForceRebuildLayoutImmediate(ShipAlerts.GetComponentInChildren<RectTransform>());
            //Canvas.ForceUpdateCanvases();
        }

        StopCoroutine("MarqueeText"); //just incase another marquee is already going
        StartCoroutine(MarqueeText(msg));

        
    }
    
    IEnumerator MarqueeText(string msg)
    {
        IncidentMessage.text = msg;
        float width = IncidentMessage.preferredWidth;

    

        //m_textRectTransform.localPosition = new Vector3(m_textRectTransform.localPosition.x + (width*2), m_textRectTransform.localPosition.y,m_textRectTransform.localPosition.z);
        Vector3 startPosition = m_textRectTransform.position;
        m_textRectTransform.position = new Vector3(width * 1.35f, m_textRectTransform.position.y, m_textRectTransform.position.z);
        IncidentMessage.rectTransform.sizeDelta = new Vector2(width, IncidentMessage.rectTransform.sizeDelta.y);
        float time = 0;
        float scrollPosition = 0;

        m_cloneTextObject = Instantiate(IncidentMessage) as TextMeshProUGUI;
        RectTransform cloneRectTransform = m_cloneTextObject.GetComponent<RectTransform>();
        cloneRectTransform.SetParent(m_textRectTransform);

        /*
        cloneRectTransform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);
        cloneRectTransform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
        cloneRectTransform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);*/

        //cloneRectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, width, cloneRectTransform.rect.width);

        EmergencyPanel.SetActive(true);
        while (!GameManager.Instance.isPaused && time < maxMarqueeTime)
        {
            time += Time.deltaTime;

            //scroll
            //m_textRectTransform.position = new Vector3(-scrollPosition % width, startPosition.y, startPosition.z);
            m_textRectTransform.position -= new Vector3(ScrollSpeed * 20 * Time.deltaTime, 0,0);
            scrollPosition += ScrollSpeed * 20 * Time.deltaTime;
        
            yield return new WaitForEndOfFrame();
        }
        IncidentPanelRenderer.gameObject.SetActive(false);
        IncidentMessage.text = "";
        EmergencyPanel.SetActive(false);
        Debug.Log("DONE WITH MARQUEE");
        
    }

    public void OnMateriumChange()
    {
        Materium_Text.text = GameManager.Instance.MateriumAmount.ToString();
    }

    public void OnShipStatusChange()
    {
        Ship_Status.fillAmount = GameManager.Instance.ShipStatus /100;
        Ship_Status.color = Color.red;
        StopCoroutine("ReturnShipColor");
        Invoke("ReturnShipColor", .15f);
    }

    void ReturnShipColor()
    {
        Ship_Status.color = origShipColor;
    }

    public void OnEngineStatusChange()
    {
        Engine_Status.fillAmount = GameManager.Instance.EngineStatus / 100;
    }

    public void OnWaveStatusChange()
    {
        Wave_Status.fillAmount = GameManager.Instance.WaveStatus / 100;

        if(GameManager.Instance.WaveStatus > 100)
        {
            //send warning message
            WarningOverlay.SetActive(true);
            AudioManager.Instance.PlaySFXOneShot("Wave");
            Invoke("stopWarning", 3.5f);
        }
    }

    void stopWarning()
    {
        WarningOverlay.SetActive(false);

        //next event
        //GameManager.Instance.GLoop.nextIncident();
    }
    
    private void OnDestroy()
    {
        GameManager.OnMateriumChange -= OnMateriumChange;
        GameManager.OnShipStatusChange -= OnShipStatusChange;
        GameManager.OnEngineStatusChange -= OnEngineStatusChange;
        GameManager.OnWaveStatusChange -= OnWaveStatusChange;
        //GameLoop.OnIncident -= OnIncident;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
