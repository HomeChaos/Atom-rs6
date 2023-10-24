using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChooseOperators : MonoBehaviour
{
    [SerializeField] private Toggle[] _check;
    [SerializeField] private Text _text;
    [SerializeField] private UIController _UIController;
    [SerializeField] private GameObject _sendler;
    [SerializeField] private bool _isD;
    
    private OperatorsScriptableObject _operators;

    public void Init(OperatorsScriptableObject operators)
    {
        _operators = operators;
    }

    public void OnClick()
    {
        List<string> opers = new List<string>();

        foreach(var item in _check)
        {
            if (item.isOn)
            {
                opers.Add(item.name);
            }
        }

        if (opers.Count != 5)
            return;

        if (_isD)
        {
            foreach (var item in _operators.OperatorsD)
                item.Active = false;

            foreach (var item in _operators.OperatorsD)
            {
                foreach (var name in opers)
                {
                    if (item.Name == name)
                    {
                        item.Active = true;
                        break;
                    }
                }
            }

            _UIController.ChangeIconD();
        }
        else
        {
            foreach (var item in _operators.OperatorsA)
                item.Active = false;

            foreach (var item in _operators.OperatorsA)
            {
                foreach (var name in opers)
                {
                    if (item.Name == name)
                    {
                        item.Active = true;
                        break;
                    }
                }
            }

            _UIController.ChangeIconA();
        }

        _sendler.SetActive(false);
    }

    public void ChangeCountOpers()
    {
        int count = 0;
        foreach(var item in _check)
            if(item.isOn)
                count++;

        if (count == 5)
            _text.text = "Окей";
        else
            _text.text = $"Выбрано {count}";
    }

    public void OnClearAllOpers()
    {
        foreach (var item in _check)
            item.isOn = false;
    }

    public void OnExit(GameObject go)
    {
        go.SetActive(false);
    }
}
