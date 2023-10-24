using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Maps", menuName = "ScriptableObject/Maps", order = 0)]
public class MapsScriptableObject : ScriptableObject
{
    [SerializeField] private List<Location> _maps;

    public List<Location> Maps => _maps;
        
        
    [System.Serializable]
    public class Location
    {
        [SerializeField] private string _name;
        [SerializeField] private List<Sprite> _layers;

        public string Name => _name;
        public List<Sprite> Layers => _layers;
    }
}