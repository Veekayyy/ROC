using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;
using System.Linq;

enum TypeDungeon {
    Nature,
    Enfer
}

public class Dungeon
{
    const int _sizeRoom = 25;
    const int _sizeRoomBoss = 45;

    private Generator _dungeonGenerator;

    private Tilemap _ground = new Tilemap();
    private Tilemap _collision = new Tilemap();
    private Tilemap _air = new Tilemap();
    private bool[,] _dungeonCollision;
    private Dictionary<Vector3, GameObject> _lstEnnemy;
    private Dictionary<Vector3, GameObject> _lstEnnemyInstantiate;

    private TypeDungeon _dungeonType;

    public Dungeon(int _widthDungeon, int _heightDungeon)
    {
        InitLayers();
        _lstEnnemy = new Dictionary<Vector3, GameObject>();
        _lstEnnemyInstantiate = new Dictionary<Vector3, GameObject>();

        int[] roomBase = new int[_sizeRoom * _sizeRoom];
        int[] roomBoss = new int[_sizeRoomBoss * _sizeRoomBoss];

        for (int i = 0; i < _sizeRoom * _sizeRoom; i++)
            roomBase[i] = 0;

        for (int i = 0; i < _sizeRoomBoss * _sizeRoomBoss; i++)
            roomBoss[i] = 0;

        List<Room> lstRoomNormal = new List<Room>();
        lstRoomNormal.Add(new Room(_sizeRoom, roomBase));

        List<Room> lstRoomImportant = new List<Room>();
        lstRoomImportant.Add(new Room(_sizeRoom, roomBase));
        lstRoomImportant.Add(new Room(_sizeRoomBoss, roomBoss));

        _dungeonGenerator = new Generator(_widthDungeon, _heightDungeon, lstRoomNormal, lstRoomImportant);

        int rnd = new System.Random().Next(2);
        _dungeonType = (TypeDungeon)rnd;
    }

    public void GenerateDungeon()
    {
        _dungeonGenerator.Generate();

        // des qu on voit 1, mettre l'index d'un plancher
        int[,] dungeonGround = _dungeonGenerator.GenerateGround();

        // des qu'on voit qqc autre que 0, c'est l'index de la tile
        int[,] dungeonCollision = _dungeonGenerator.GenerateCollision();

        // des qu'on voit pas 0, index de la tile
        int[,] dungeonAir = _dungeonGenerator.GenerateAir();

        GenerateTiles(dungeonGround, dungeonCollision, dungeonAir);
    }

    private void GenerateTiles(int[,] ground, int[,] collision, int[,] air)
    {
        Tile aTile = new Tile();
        Sprite[] allSprites = Resources.LoadAll<Sprite>("Tiles/" + _dungeonType.ToString());

        for (int i = 0; i < ground.GetLength(0); i++)
        {
            for (int j = 0; j < ground.GetLength(1); j++)
            {
                if (ground[i, j] == 0)
                {
                    aTile.sprite = allSprites[0];
                    aTile.name = "0";
                    _ground.SetTile(new Vector3Int(i, j, 0), aTile);
                }

                if (collision[i, j] != 0)
                {
                    aTile.sprite = allSprites[collision[i, j]];
                    aTile.name = collision[i,j].ToString();
                    _collision.SetTile(new Vector3Int(i, j, 0), aTile);
                }

                if (air[i, j] != 0)
                {
                    aTile.sprite = allSprites[air[i, j]];
                    aTile.name = air[i, j].ToString();
                    _collision.SetTile(new Vector3Int(i, j, 0), aTile);
                }
            }
        }
    }

    public void EnnemyDead(GameObject go)
    {
        Vector3 pos = Vector3.zero;

        foreach(KeyValuePair<Vector3,GameObject> ennemy in _lstEnnemyInstantiate)
        {
            if (ennemy.Value == go) pos = ennemy.Key;
        }

        _lstEnnemyInstantiate.Remove(pos);
        _lstEnnemy.Remove(pos);
    }

    public Vector3 GetPlayerPos()
    {
        return _dungeonGenerator.GetPosStart();
    }

    public Vector3 GetChestPos()
    {
        return _dungeonGenerator.GetChestPos();
    }

    public void GenerateEnnemies(GameObject theEnnemy)
    {
        List<Vector3> lstEnnemy = _dungeonGenerator.GetPointsOfSpawn();

        foreach (Vector3 position in lstEnnemy)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Vector3 pos = position - new Vector3(x, y, 0);
                    GameObject go = InstanciateEnnemy(theEnnemy, pos);
                    go.SetActive(false);

                    _lstEnnemy.Add(pos, go);
                }
            }
        }
    }

    public void ShowEnnemies()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);
        Dictionary<Vector3, GameObject> lst = new Dictionary<Vector3, GameObject>();

        foreach(KeyValuePair<Vector3,GameObject> ennemy in _lstEnnemy)
        {
            Vector3 pos = ennemy.Key;

            if ((pos.x > screenBounds.x || pos.x < screenOrigo.x || pos.y > screenBounds.y || pos.y < screenOrigo.y))
            {
                if (_lstEnnemyInstantiate.ContainsKey(pos))
                {
                    GameObject go = _lstEnnemyInstantiate[pos];

                    _lstEnnemyInstantiate.Remove(pos);
                    pos = go.transform.position;

                    go.SetActive(false);
                }
            }
            else if (!_lstEnnemyInstantiate.ContainsKey(pos))
            {
                _lstEnnemyInstantiate.Add(pos, ennemy.Value);
                ennemy.Value.SetActive(true);
            }

            lst.Add(pos, ennemy.Value);
        }

        _lstEnnemy = lst;

        Debug.Log(_lstEnnemyInstantiate.Count);
    }

    private GameObject InstanciateEnnemy(GameObject go, Vector3 pos)
    {
        GameObject ennemy = GameObject.Instantiate(go);

        ennemy.transform.position = pos;
        ennemy.name = ennemy.GetComponent<Ennemy>().nom;
        ennemy.transform.parent = GameObject.FindGameObjectWithTag("lstEnnemy").transform;

        return ennemy;
    }

    private void InitLayers()
    {
        _ground = GameObject.FindGameObjectWithTag("layerGround").GetComponent<Tilemap>();
        _collision = GameObject.FindGameObjectWithTag("layerCollision").GetComponent<Tilemap>();
        _air = GameObject.FindGameObjectWithTag("layerAir").GetComponent<Tilemap>();
    }
}
