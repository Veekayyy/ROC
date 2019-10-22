using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject _coffre;
    [SerializeField]
    private GameObject _ennemi;
    [SerializeField]
    private Camera _camera;

    private Vector3 _lastPos;
    private Dungeon dng;

    // Start is called before the first frame update
    void Start()
    {
        dng = new Dungeon(300, 300);
        dng.GenerateDungeon();

        Vector3 posJoueur = dng.GetPlayerPos();

        GameObject lst = GameObject.FindGameObjectWithTag("lstEnnemy");

        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = posJoueur;

        dng.GenerateEnnemies(_ennemi);

        GameObject coffre = Instantiate(_coffre);
        coffre.transform.position = dng.GetChestPos();

        _lastPos = _camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_lastPos != _camera.transform.position)
        {
            _lastPos = _camera.transform.position;

            dng.ShowEnnemies();
        }
    }

    public void EnnemyDead(GameObject go)
    {
        dng.EnnemyDead(go);
    }
}
