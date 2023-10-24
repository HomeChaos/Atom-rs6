using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private DrawComponent _drawComponent;
    [SerializeField] private Button _buttonDrawing;
    [Header("Защита")]
    [SerializeField] private Image _iconD0;
    [SerializeField] private Image[] _iconDevice0;
    [Space]
    [SerializeField] private Image _iconD1;
    [SerializeField] private Image[] _iconDevice1;
    [Space]
    [SerializeField] private Image _iconD2;
    [SerializeField] private Image[] _iconDevice2;
    [Space]
    [SerializeField] private Image _iconD3;
    [SerializeField] private Image[] _iconDevice3;
    [Space]
    [SerializeField] private Image _iconD4;
    [SerializeField] private Image[] _iconDevice4;
    [Header("Атака")]
    [SerializeField] private Image _iconA0;
    [SerializeField] private Image[] _iconDevice5;
    [Space]
    [SerializeField] private Image _iconA1;
    [SerializeField] private Image[] _iconDevice6;
    [Space]
    [SerializeField] private Image _iconA2;
    [SerializeField] private Image[] _iconDevice7;
    [Space]
    [SerializeField] private Image _iconA3;
    [SerializeField] private Image[] _iconDevice8;
    [Space]
    [SerializeField] private Image _iconA4;
    [SerializeField] private Image[] _iconDevice9;
    [Header("Дополнительные иконки")]
    [SerializeField] private Image[] _addIconD;
    [SerializeField] private Image[] _addIconA;
    [Header("Гаджеты")]
    [SerializeField] private Image[] _gadget0;
    [SerializeField] private Image[] _gadget1;
    [SerializeField] private Image[] _gadget2;
    [SerializeField] private Image[] _gadget3;
    [SerializeField] private Image[] _gadget4;
    [SerializeField] private Image[] _gadget5;
    [SerializeField] private Image[] _gadget6;
    [SerializeField] private Image[] _gadget7;
    [SerializeField] private Image[] _gadget8;
    [SerializeField] private Image[] _gadget9;

    private List<Vector3> _positionIconsD = new List<Vector3>();
    private List<Vector3> _positionIconsA = new List<Vector3>();
    private List<Vector3> _positionDeviceD = new List<Vector3>();
    private List<Vector3> _positionDeviceA = new List<Vector3>();
    private List<Vector3> _positionGadgetD = new List<Vector3>();
    private List<Vector3> _positionGadgetA = new List<Vector3>();

    private OperatorsScriptableObject _operators;

    public void Init(OperatorsScriptableObject operators)
    {
        _operators = operators;
    }
    
    public void SetPosition(Transform obj)
    {
        obj.position = Input.mousePosition;
    }

    private void Start()
    {
        _positionIconsD.Add(_iconD0.rectTransform.position);
        _positionIconsD.Add(_iconD1.rectTransform.position);
        _positionIconsD.Add(_iconD2.rectTransform.position);
        _positionIconsD.Add(_iconD3.rectTransform.position);
        _positionIconsD.Add(_iconD4.rectTransform.position);
        _positionIconsA.Add(_iconA0.rectTransform.position);
        _positionIconsA.Add(_iconA1.rectTransform.position);
        _positionIconsA.Add(_iconA2.rectTransform.position);
        _positionIconsA.Add(_iconA3.rectTransform.position);
        _positionIconsA.Add(_iconA4.rectTransform.position);

        AddPositionInList(_iconDevice0, _positionDeviceD);
        AddPositionInList(_iconDevice1, _positionDeviceD);
        AddPositionInList(_iconDevice2, _positionDeviceD);
        AddPositionInList(_iconDevice3, _positionDeviceD);
        AddPositionInList(_iconDevice4, _positionDeviceD);
        AddPositionInList(_iconDevice5, _positionDeviceA);
        AddPositionInList(_iconDevice6, _positionDeviceA);
        AddPositionInList(_iconDevice7, _positionDeviceA);
        AddPositionInList(_iconDevice8, _positionDeviceA);
        AddPositionInList(_iconDevice9, _positionDeviceA);

        AddPositionInList(_gadget0, _positionGadgetD);
        AddPositionInList(_gadget1, _positionGadgetD);
        AddPositionInList(_gadget2, _positionGadgetD);
        AddPositionInList(_gadget3, _positionGadgetD);
        AddPositionInList(_gadget4, _positionGadgetD);
        AddPositionInList(_gadget5, _positionGadgetA);
        AddPositionInList(_gadget6, _positionGadgetA);
        AddPositionInList(_gadget7, _positionGadgetA);
        AddPositionInList(_gadget8, _positionGadgetA);
        AddPositionInList(_gadget9, _positionGadgetA);
    }

    private void AddPositionInList(Image[] img, List<Vector3> list)
    {
        foreach (var item in img)
            list.Add(item.rectTransform.position);
    }

    private void DisableDisplay(Image[] image)
    {
        for (int i = 0; i < image.Length; i++)
            image[i].gameObject.SetActive(false);
    }

    private void ChangeDisplay(OperatorsScriptableObject.Operator operatorData, Image icon, Image addIcon, Image[] devises, Image[] gadgets)
    {
        icon.sprite = operatorData.Icon;
        addIcon.sprite = operatorData.Icon;

        DisableDisplay(devises);
        
        if (operatorData.Device > 0)
        {
            for (var i = 0; i < operatorData.Device; i++)
            {
                devises[i].gameObject.SetActive(true);
                devises[i].sprite = operatorData.IconDevice;
            }
        }

        DisableDisplay(gadgets);
        gadgets[0].gameObject.SetActive(true);
        gadgets[0].sprite = operatorData.IconGadgetFirst;
        gadgets[1].gameObject.SetActive(true);
        gadgets[1].sprite = operatorData.IconGadgetFirst;

        gadgets[2].gameObject.SetActive(true);
        gadgets[2].sprite = operatorData.IconGadgetSecond;
        gadgets[3].gameObject.SetActive(true);
        gadgets[3].sprite = operatorData.IconGadgetSecond;
    }
    
    public void ChangeIconD()
    {
        OnResetIconD();
        OnResetDeviceD();
        OnResetGadgetD();

        int k = 0;
        foreach (OperatorsScriptableObject.Operator item in _operators.OperatorsD)
        {
            if (item.Active)
            {
                switch (k)
                {
                    case 0:
                        ChangeDisplay(item, _iconD0, _addIconD[0], _iconDevice0, _gadget0);
                        k++;
                        break;
                    case 1:
                        ChangeDisplay(item, _iconD1, _addIconD[1], _iconDevice1, _gadget1);
                        k++;
                        break;
                    case 2:
                        ChangeDisplay(item, _iconD2, _addIconD[2], _iconDevice2, _gadget2);
                        k++;
                        break;
                    case 3:
                        ChangeDisplay(item, _iconD3, _addIconD[3], _iconDevice3, _gadget3);
                        k++;
                        break;
                    case 4:
                        ChangeDisplay(item, _iconD4, _addIconD[4], _iconDevice4, _gadget4);
                        k++;
                        break;
                }
            }
        }
    }

    public void ChangeIconA()
    {
        OnResetIconA();
        OnResetDeviceA();
        OnResetGadgetA();

        int k = 0;
        foreach (OperatorsScriptableObject.Operator item in _operators.OperatorsA)
        {
            if (item.Active)
            {
                switch (k)
                {
                    case 0:
                        ChangeDisplay(item, _iconA0, _addIconA[0], _iconDevice5, _gadget5);
                        k++;
                        break;
                    case 1:
                        ChangeDisplay(item, _iconA1, _addIconA[1], _iconDevice6, _gadget6);
                        k++;
                        break;
                    case 2:
                        ChangeDisplay(item, _iconA2, _addIconA[2], _iconDevice7, _gadget7);
                        k++;
                        break;
                    case 3:
                        ChangeDisplay(item, _iconA3, _addIconA[3], _iconDevice8, _gadget8);
                        k++;
                        break;
                    case 4:
                        ChangeDisplay(item, _iconA4, _addIconA[4], _iconDevice9, _gadget9);
                        k++;
                        break;
                }
            }
        }
    }


    #region Кнопки
    public void OnCloseApp()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnOffDraw()
    {
        _drawComponent.DisableDrawingMode();
        ChangeColorButtom();
    }

    public void OnResetIconD()
    {
        _iconD0.rectTransform.position = _positionIconsD[0];
        _iconD1.rectTransform.position = _positionIconsD[1];
        _iconD2.rectTransform.position = _positionIconsD[2];
        _iconD3.rectTransform.position = _positionIconsD[3];
        _iconD4.rectTransform.position = _positionIconsD[4];
    }

    public void OnResetIconA()
    {
        _iconA0.rectTransform.position = _positionIconsA[0];
        _iconA1.rectTransform.position = _positionIconsA[1];
        _iconA2.rectTransform.position = _positionIconsA[2];
        _iconA3.rectTransform.position = _positionIconsA[3];
        _iconA4.rectTransform.position = _positionIconsA[4];
    }

    public void OnResetDeviceD()
    {
        _iconDevice0[0].rectTransform.position = _positionDeviceD[0];
        _iconDevice0[1].rectTransform.position = _positionDeviceD[1];
        _iconDevice0[2].rectTransform.position = _positionDeviceD[2];
        _iconDevice0[3].rectTransform.position = _positionDeviceD[3];
        _iconDevice0[4].rectTransform.position = _positionDeviceD[4];

        _iconDevice1[0].rectTransform.position = _positionDeviceD[5];
        _iconDevice1[1].rectTransform.position = _positionDeviceD[6];
        _iconDevice1[2].rectTransform.position = _positionDeviceD[7];
        _iconDevice1[3].rectTransform.position = _positionDeviceD[8];
        _iconDevice1[4].rectTransform.position = _positionDeviceD[9];

        _iconDevice2[0].rectTransform.position = _positionDeviceD[10];
        _iconDevice2[1].rectTransform.position = _positionDeviceD[11];
        _iconDevice2[2].rectTransform.position = _positionDeviceD[12];
        _iconDevice2[3].rectTransform.position = _positionDeviceD[13];
        _iconDevice2[4].rectTransform.position = _positionDeviceD[14];

        _iconDevice3[0].rectTransform.position = _positionDeviceD[15];
        _iconDevice3[1].rectTransform.position = _positionDeviceD[16];
        _iconDevice3[2].rectTransform.position = _positionDeviceD[17];
        _iconDevice3[3].rectTransform.position = _positionDeviceD[18];
        _iconDevice3[4].rectTransform.position = _positionDeviceD[19];

        _iconDevice4[0].rectTransform.position = _positionDeviceD[20];
        _iconDevice4[1].rectTransform.position = _positionDeviceD[21];
        _iconDevice4[2].rectTransform.position = _positionDeviceD[22];
        _iconDevice4[3].rectTransform.position = _positionDeviceD[23];
        _iconDevice4[4].rectTransform.position = _positionDeviceD[24];
    }

    public void OnResetDeviceA()
    {
        _iconDevice5[0].rectTransform.position = _positionDeviceA[0];
        _iconDevice5[1].rectTransform.position = _positionDeviceA[1];
        _iconDevice5[2].rectTransform.position = _positionDeviceA[2];
        _iconDevice5[3].rectTransform.position = _positionDeviceA[3];
        _iconDevice5[4].rectTransform.position = _positionDeviceA[4];

        _iconDevice6[0].rectTransform.position = _positionDeviceA[5];
        _iconDevice6[1].rectTransform.position = _positionDeviceA[6];
        _iconDevice6[2].rectTransform.position = _positionDeviceA[7];
        _iconDevice6[3].rectTransform.position = _positionDeviceA[8];
        _iconDevice6[4].rectTransform.position = _positionDeviceA[9];

        _iconDevice7[0].rectTransform.position = _positionDeviceA[10];
        _iconDevice7[1].rectTransform.position = _positionDeviceA[11];
        _iconDevice7[2].rectTransform.position = _positionDeviceA[12];
        _iconDevice7[3].rectTransform.position = _positionDeviceA[13];
        _iconDevice7[4].rectTransform.position = _positionDeviceA[14];

        _iconDevice8[0].rectTransform.position = _positionDeviceA[15];
        _iconDevice8[1].rectTransform.position = _positionDeviceA[16];
        _iconDevice8[2].rectTransform.position = _positionDeviceA[17];
        _iconDevice8[3].rectTransform.position = _positionDeviceA[18];
        _iconDevice8[4].rectTransform.position = _positionDeviceA[19];

        _iconDevice9[0].rectTransform.position = _positionDeviceA[20];
        _iconDevice9[1].rectTransform.position = _positionDeviceA[21];
        _iconDevice9[2].rectTransform.position = _positionDeviceA[22];
        _iconDevice9[3].rectTransform.position = _positionDeviceA[23];
        _iconDevice9[4].rectTransform.position = _positionDeviceA[24];
    }

    public void OnResetGadgetD()
    {
        _gadget0[0].rectTransform.position = _positionGadgetD[0];
        _gadget0[1].rectTransform.position = _positionGadgetD[1];
        _gadget0[2].rectTransform.position = _positionGadgetD[2];
        _gadget0[3].rectTransform.position = _positionGadgetD[3];

        _gadget1[0].rectTransform.position = _positionGadgetD[4];
        _gadget1[1].rectTransform.position = _positionGadgetD[5];
        _gadget1[2].rectTransform.position = _positionGadgetD[6];
        _gadget1[3].rectTransform.position = _positionGadgetD[7];

        _gadget2[0].rectTransform.position = _positionGadgetD[8];
        _gadget2[1].rectTransform.position = _positionGadgetD[9];
        _gadget2[2].rectTransform.position = _positionGadgetD[10];
        _gadget2[3].rectTransform.position = _positionGadgetD[11];

        _gadget3[0].rectTransform.position = _positionGadgetD[12];
        _gadget3[1].rectTransform.position = _positionGadgetD[13];
        _gadget3[2].rectTransform.position = _positionGadgetD[14];
        _gadget3[3].rectTransform.position = _positionGadgetD[15];

        _gadget4[0].rectTransform.position = _positionGadgetD[16];
        _gadget4[1].rectTransform.position = _positionGadgetD[17];
        _gadget4[2].rectTransform.position = _positionGadgetD[18];
        _gadget4[3].rectTransform.position = _positionGadgetD[19];
    }

    public void OnResetGadgetA()
    {
        _gadget5[0].rectTransform.position = _positionGadgetA[0];
        _gadget5[1].rectTransform.position = _positionGadgetA[1];
        _gadget5[2].rectTransform.position = _positionGadgetA[2];
        _gadget5[3].rectTransform.position = _positionGadgetA[3];

        _gadget6[0].rectTransform.position = _positionGadgetA[4];
        _gadget6[1].rectTransform.position = _positionGadgetA[5];
        _gadget6[2].rectTransform.position = _positionGadgetA[6];
        _gadget6[3].rectTransform.position = _positionGadgetA[7];

        _gadget7[0].rectTransform.position = _positionGadgetA[8];
        _gadget7[1].rectTransform.position = _positionGadgetA[9];
        _gadget7[2].rectTransform.position = _positionGadgetA[10];
        _gadget7[3].rectTransform.position = _positionGadgetA[11];

        _gadget8[0].rectTransform.position = _positionGadgetA[12];
        _gadget8[1].rectTransform.position = _positionGadgetA[13];
        _gadget8[2].rectTransform.position = _positionGadgetA[14];
        _gadget8[3].rectTransform.position = _positionGadgetA[15];

        _gadget9[0].rectTransform.position = _positionGadgetA[16];
        _gadget9[1].rectTransform.position = _positionGadgetA[17];
        _gadget9[2].rectTransform.position = _positionGadgetA[18];
        _gadget9[3].rectTransform.position = _positionGadgetA[19];
    }

    public void ChangeColorButtom()
    {
        var colorNow = _buttonDrawing.GetComponent<Image>().color;
        if (colorNow == new Color(1, 1, 1, 1))
            _buttonDrawing.GetComponent<Image>().color = new Color(0.4862745f, 0.5072372f, 1f, 1f);
        else
            _buttonDrawing.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void ClearDrawLine()
    {
        var allLines = GameObject.FindGameObjectsWithTag("Line");
        for (int i = 0; i < allLines.Length; i++)
            Destroy(allLines[i]);
    }

    public void OnClearFirstLine()
    {
        var allLines = GameObject.FindGameObjectsWithTag("Line");
        if (allLines.Length > 0)
            Destroy(allLines[allLines.Length - 1]);
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            OnClearFirstLine();

        if (Input.GetKeyDown(KeyCode.C))
            ClearDrawLine();

        if (Input.GetKeyDown(KeyCode.D))
            OnOffDraw();

        if (Input.GetKeyDown(KeyCode.Q))
            OnCloseApp();
    }
}
