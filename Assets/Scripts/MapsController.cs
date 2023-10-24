using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MapsController : MonoBehaviour
{
    [SerializeField] private MapsScriptableObject _maps;
    [SerializeField] private Dropdown _currentMap;
    [SerializeField] private Dropdown _currentLayer;

    private Image _mapNow;
    private string _mapNowStr;

    private void Start()
    {
        _mapNow = GetComponent<Image>();
        _mapNowStr = "Яхта";
        _currentMap.onValueChanged.AddListener(ChangedMap);
        _currentLayer.onValueChanged.AddListener(delegate { ChangedLayer(_currentLayer); });
    }

    private void ChangedLayer(Dropdown currentLayer)
    {
        foreach(var map in _maps.Maps)
        {
            if(map.Name == _mapNowStr)
            {
                if (currentLayer.value < map.Layers.Count)
                    _mapNow.sprite = map.Layers[currentLayer.value];
                else
                    _mapNow.sprite = map.Layers[map.Layers.Count - 1];
                
                break;
            }
        }
    }

    private void ChangedMap(int index)
    {
        foreach(var item in _maps.Maps)
        {
            if(item.Name == _currentMap.options[_currentMap.value].text)
            {
                _mapNow.sprite = item.Layers[0];
                _mapNowStr = item.Name;
                _currentLayer.value = 0;
                break;
            }
        }
    }
}

