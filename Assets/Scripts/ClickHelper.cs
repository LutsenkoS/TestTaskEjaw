using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHelper : MonoBehaviour//, IPointerClickHandler
{
    private GameData _gameData;
    private GeometryObjectModel _model;
    private DataController _dataController;
    private bool _prefabLoaded;
    private float _startTime;
    private bool _lockFigure;

    void Start()
    {
        _dataController = FindObjectOfType<DataController>();
        _gameData = Resources.Load<GameData>("GameData");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClick(Input.mousePosition);
        }
        if (_prefabLoaded)
            if (Time.time - _startTime > _gameData.ObservableTime)
            {
                if (!_lockFigure)
                    _lockFigure = true;
                _model.SetColor();
                _startTime = Time.time;
            }
    }

    private void OnMouseClick(Vector3 pos)
    {
        if (!_prefabLoaded)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
            GameObject GO = LoadAssetBundles.LoadAssetBundle(_dataController.prefabs[Random.Range(0, _dataController.prefabs.Length)].Name);
            _model = Instantiate(GO, new Vector3(worldPos.x, worldPos.y, 0), Quaternion.identity).GetComponent<GeometryObjectModel>();
            _prefabLoaded = true;
            _startTime = Time.time;
            return;
        }
        Ray _ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit _hit;
        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.CompareTag("Figure"))
            {
                if (!_lockFigure)
                    _hit.collider.GetComponent<GeometryObjectModel>().Clicked();
            }
        }
    }
}

