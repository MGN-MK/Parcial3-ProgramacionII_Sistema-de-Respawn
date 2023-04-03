using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnedStats : MonoBehaviour
{
    public GameObject arrow;
    public string PlayerTag;

    [Header("Buttons")]
    public KeyCode ShowAndHide = KeyCode.F;
    public KeyCode NextSpawner = KeyCode.I;
    public KeyCode PreviousSpawner = KeyCode.K;
    public KeyCode NextObj = KeyCode.J;
    public KeyCode PreviousObj = KeyCode.L;

    [Header("Texts")]
    public TextMeshProUGUI idSpawn;
    public TextMeshProUGUI idNumberSpawn;
    public TextMeshProUGUI idObj;
    public TextMeshProUGUI idNumberObj;

    private string idSpawntext;
    private string idNumberSpawntext;
    private string idObjtext;
    private string idNumberObjtext;

    private int idNumSpawn = 0;
    private int idNumObj = 0;
    private bool isActive = false;
    private GameObject activeGreenArrow;
    private GameObject spawner;
    private GameObject obj;
    private TextMeshProUGUI[] texts;
    private SpawnManager spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindAnyObjectByType<SpawnManager>();
        texts = GetComponentsInChildren<TextMeshProUGUI>();

        idSpawntext = idSpawn.text;
        idNumberSpawntext = idNumberSpawn.text;
        idObjtext = idObj.text;
        idNumberObjtext = idNumberObj.text;

        foreach (var text in texts)
        {
            text.gameObject.SetActive(isActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ShowAndHide))
        {
            isActive = !isActive;

            foreach(var text in texts)
            {
                text.gameObject.SetActive(isActive);
            }

            if(activeGreenArrow != null)
            {
                activeGreenArrow.SetActive(isActive);
            }
        }

        if (isActive)
        {
            SetStats();

            if (Input.GetKeyDown(NextSpawner))
            {
                if (idNumSpawn == spawnManager.allSpawnsGet.Length - 1)
                {
                    idNumSpawn = 0;
                }
                else
                {
                    idNumSpawn++;
                }
            }
            if (Input.GetKeyDown(PreviousSpawner))
            {
                if(idNumSpawn == 0)
                {
                    idNumSpawn = spawnManager.allSpawnsGet.Length - 1;
                }
                else
                {
                    idNumSpawn--;
                }
            }

            if (Input.GetKeyDown(NextObj))
            {
                if (idNumObj == spawnManager.allSpawnsGet[idNumSpawn].GetComponent<SpawnPointsBase>().spawned.Length - 1)
                {
                    idNumObj = 0;
                }
                else
                {
                    idNumObj++;
                }
            }
            if (Input.GetKeyDown(PreviousObj))
            {
                if (idNumObj == 0)
                {
                    idNumObj = spawnManager.allSpawnsGet[idNumSpawn].GetComponent<SpawnPointsBase>().spawned.Length - 1;
                }
                else
                {
                    idNumObj--;
                }
            }
        }
    }

    private void SetStats()
    {
        spawner = spawnManager.allSpawnsGet[idNumSpawn];
        obj = spawner.GetComponent<SpawnPointsBase>().spawned[idNumObj];

        if(activeGreenArrow != null)
        {
            activeGreenArrow.transform.position = obj.transform.position + new Vector3(0f, 2f, 0f);
            activeGreenArrow.transform.LookAt(GameObject.FindGameObjectWithTag(PlayerTag).transform);
        }
        else
        {
            activeGreenArrow = Instantiate(arrow, obj.transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
            activeGreenArrow.transform.LookAt(GameObject.FindGameObjectWithTag(PlayerTag).transform);
        }

        idSpawn.text = idSpawntext + spawner.name;
        idNumberSpawn.text = idNumberSpawntext + idNumSpawn;

        idObj.text = idObjtext + obj.name;
        idNumberObj.text = idNumberObjtext + idNumObj;
    }
}
