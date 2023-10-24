using UnityEngine;
using UnityEngine.UI;

public class DrawComponent : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject[] _brushColor;
    [SerializeField] private bool _onDrawing;
    [SerializeField] private bool _onFocus;
    
    private LineRenderer currentLineRenderer;
    private Vector2 lastPos;
    private GameObject _brush;

    private void Start()
    {
        _brush = _brushColor[0];
    }

    public void OnFocus()
    {
        _onFocus = true;
    }

    public void OnEndFocus()
    {
        _onFocus = false;
    }

    public void ChangeColor(Dropdown d)
    {
        _brush = _brushColor[d.value];
    }

    public void DisableDrawingMode()
    {
        _onDrawing = !_onDrawing;
    }

    private void Update()
    {
        Drawing();
    }

    private void Drawing()
    {
        if (!_onDrawing) return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && _onFocus)
        {
            CreateBrush();
        }
        else if (Input.GetKey(KeyCode.Mouse0) && _onFocus)
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    private void CreateBrush()
    {
        GameObject brushInstance = Instantiate(_brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        
        Vector2 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    private void PointToMousePos()
    {
        Vector2 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }

    private  void AddAPoint(Vector2 pointPos)
    {
        try
        {
            currentLineRenderer.positionCount++;
            int positionIndex = currentLineRenderer.positionCount - 1;
            currentLineRenderer.SetPosition(positionIndex, pointPos);
        }
        catch (System.Exception)
        {

        }       
    }
}


