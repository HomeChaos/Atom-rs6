using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Operators", menuName = "ScriptableObject/Operators", order = 0)]
public class OperatorsScriptableObject : ScriptableObject
{
    [SerializeField] private string _pathToCSV;
    [SerializeField] private List<Sprite> _operatorsIcons;
    [SerializeField] private List<Sprite> _devices;
    [SerializeField] private List<Sprite> _gadgets;
    [SerializeField] private Sprite _defaultIcon;
    [SerializeField] private Sprite _defaultDevices;
    [Space]
    [Header("Data")]
    [SerializeField] private List<Operator> _operatorsD = new List<Operator>();
    [SerializeField] private List<Operator> _operatorsA = new List<Operator>();

    public List<Operator> OperatorsD => _operatorsD;
    public List<Operator> OperatorsA => _operatorsA;

    [ContextMenu("CreateData")]
    private void CreateData()
    {
        if (CheckPath(_pathToCSV, out string path))
            ParseData(path);
        else
            throw new Exception("Неверный путь до файла *.csv");
    }

    private bool CheckPath(string pathToCsv, out string path)
    {
        path = Application.dataPath + "/" + pathToCsv;
        
        return path.EndsWith(".csv", StringComparison.OrdinalIgnoreCase);
    }

    private void ParseData(string filePath)
    {
        _operatorsD = new List<Operator>();
        _operatorsA = new List<Operator>();
        string[] csvData = System.IO.File.ReadAllLines(filePath);

        foreach (var line in csvData)
        {
            string[] rowData = line.Split(';');
            
            if (rowData[0] == "id")
                continue;

            var newOperator = new Operator();

            string type = rowData[1];
            string operName = rowData[2];

            int device = int.Parse(rowData[3]);
            Sprite icon = FindIcon(rowData[2]);
            Sprite iconDevice = FindDevice(rowData[2]);
            Sprite iconGadgetFirst = FindGadget(rowData[4]);
            Sprite iconGadgetSecond = FindGadget(rowData[5]);
            
            newOperator.Init(operName, device, icon, iconDevice, iconGadgetFirst, iconGadgetSecond);

            if (type == "d")
                _operatorsD.Add(newOperator);
            else
                _operatorsA.Add(newOperator);
        }
    }

    private Sprite FindIcon(string operatorName)
    {
        var sprite = _operatorsIcons.FirstOrDefault(x => x.name == operatorName);
        return sprite != null ? sprite : _defaultIcon;
    }

    private Sprite FindDevice(string operatorName)
    {
        var sprite = _devices.FirstOrDefault(x => x.name == $"d_{operatorName.ToLower()}");
        return sprite != null ? sprite : _defaultDevices;
    }

    private Sprite FindGadget(string gadgetName)
    {
        var sprite = _gadgets.FirstOrDefault(x => x.name == gadgetName);
        return sprite != null ? sprite : _defaultDevices;
    }


    [Serializable]
    public class Operator
    {
        [SerializeField] private string _name;
        [SerializeField] private int _device;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Sprite _iconDevice;
        [SerializeField] private Sprite _iconGadgetFirst;
        [SerializeField] private Sprite _iconGadgetSecond;

        public string Name => _name;
        public int Device => _device;
        public Sprite Icon => _icon;
        public Sprite IconDevice => _iconDevice;
        public Sprite IconGadgetFirst => _iconGadgetFirst;
        public Sprite IconGadgetSecond => _iconGadgetSecond;
        public bool Active { get; set; } = false;

        public void Init(string name, int device, Sprite icon, Sprite iconDevice, Sprite iconGadgetFirst, Sprite iconGadgetSecond)
        {
            _name = name;
            _device = device;
            _icon = icon;
            _iconDevice = iconDevice;
            _iconGadgetFirst = iconGadgetFirst;
            _iconGadgetSecond = iconGadgetSecond;
        }
    }
}