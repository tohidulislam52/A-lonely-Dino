using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _Tiles;
    [SerializeField] private Transform _PlayerTran;
    [SerializeField] private List<GameObject> _BackTile = new List<GameObject>();
    private float _Xvalu=300;
    private float _tileLenth = 300;
    private int _TileNumber = 2;

    void Start()
    {
        for (int i = 0; i < _TileNumber; i++)
        {
            AddTile(i);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(_PlayerTran.position.x > _Xvalu  - (_TileNumber *_tileLenth))
        {
            Debug.Log(_Xvalu  - (_TileNumber *_tileLenth));
            AddTile(Random.Range(0,_Tiles.Length));
            RemoveTile();
        }
    }

    private void AddTile( int Num)
    {
        GameObject tile = Instantiate(_Tiles[Num], new Vector3(_Xvalu,0,0),Quaternion.identity,transform);
        _BackTile.Add(tile);
        _Xvalu+=300;
    }

    private void RemoveTile()
    {
        Destroy(_BackTile[0]);
        _BackTile.RemoveAt(0);

    }
}
