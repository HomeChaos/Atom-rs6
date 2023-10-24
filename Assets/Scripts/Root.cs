using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private OperatorsScriptableObject _operators;
        [SerializeField] private UIController _uiController;
        [SerializeField] private PanelChooseOperators _panelChooseOperatorsA;
        [SerializeField] private PanelChooseOperators _panelChooseOperatorsD;
        [SerializeField] private MapsScriptableObject _maps;
        [SerializeField] private Dropdown _mapDropdown;

        [ContextMenu("Update dropdown maps")]
        private void UpdateDropdownMaps()
        {
            _mapDropdown.options.Clear();
            
            foreach (var map in _maps.Maps)
            {
                _mapDropdown.options.Add(new Dropdown.OptionData(map.Name));
            }
        }

        private void Awake()
        {
            _uiController.Init(_operators);
            _panelChooseOperatorsA.Init(_operators);
            _panelChooseOperatorsD.Init(_operators);
        }
    }
}