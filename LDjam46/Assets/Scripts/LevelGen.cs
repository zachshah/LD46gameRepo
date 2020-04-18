using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    enum gridSpace { empty, floor, wall };
    gridSpace[,] grid;
    int roomHeight;
    int roomWidth;
    public Vector2 roomSizeWorldUnits = new Vector2(30, 30);
    public float worldUnitsInOneGridCell = 5;
    struct walker
    {
        public Vector2 dir;
        public Vector2 pos;
    }
    List<walker> walkers;
    public float walkerDirChangeChance = 0.3f;
    float walkerSpawnChance = 0.05f;
    float walkerDestroyChance = 0.05f;
    int maxWalkers = 10;
    float percentToFill = 0.2f;
    public GameObject wallObj;
    public GameObject floorObj;
    public GameObject wallHolder;
    public GameObject spawnWall;

    private Vector3 startRot;

    public List<GameObject> wallList = new List<GameObject>();
 
 
         

void Start()
    {
        startRot = new Vector3(90, 0, 0);
        Setup();
        CreateFloors();
        CreateWalls();
        // RemoveSingleWalls();
        SpawnLevel();
        transform.eulerAngles = startRot;
        wallHolder.transform.position += new Vector3(0, worldUnitsInOneGridCell, 0);
        this.transform.position += new Vector3(0, -2.5f, 0);

        listWallObj();
        swapWallWithObj();
    }
    void listWallObj()
    {
        foreach (GameObject wallObj in GameObject.FindGameObjectsWithTag("Wall"))
        {

            wallList.Add(wallObj);
        }
    }
    void swapWallWithObj()
    {
        for (int i = 0; i < 4; i++)
        {
            int randomWall = Random.Range(0, wallList.Count);
            GameObject specialWall = wallList[randomWall];
            Instantiate(spawnWall, specialWall.transform.position, specialWall.transform.rotation);
            Destroy(specialWall);
            Debug.Log(randomWall);
        }
    }

    void Setup()
    {
        roomHeight = Mathf.RoundToInt(roomSizeWorldUnits.x / worldUnitsInOneGridCell);
        roomWidth = Mathf.RoundToInt(roomSizeWorldUnits.y / worldUnitsInOneGridCell);

        grid = new gridSpace[roomWidth, roomHeight];

        for (int x = 0; x < roomWidth - 1; x++)
        {
            for (int y = 0; y < roomHeight - 1; y++)
            {
                grid[x, y] = gridSpace.empty;
            }
        }

        walkers = new List<walker>();

        walker newWalker = new walker();
        newWalker.dir = RandomDirection();

        Vector2 spawnPos = new Vector2(Mathf.RoundToInt(roomWidth / 2f), Mathf.RoundToInt(roomHeight / 2f));

        newWalker.pos = spawnPos;

        walkers.Add(newWalker);


    }

    void CreateFloors()
    {
        int iterations = 0;
        do
        {
            foreach (walker myWalker in walkers)
            {
                grid[(int)myWalker.pos.x, (int)myWalker.pos.y] = gridSpace.floor;
            }

            int numberChecks = walkers.Count;
            for (int i = 0; i < numberChecks; i++)
            {
                if (Random.value < walkerDestroyChance && walkers.Count > 1)
                {
                    walkers.RemoveAt(i);
                    break;
                }
            }

            for (int i = 0; i < walkers.Count; i++)
            {
                if (Random.value < walkerDirChangeChance)
                {
                    walker thisWalker = walkers[i];
                    thisWalker.dir = RandomDirection();
                    walkers[i] = thisWalker;
                }
            }

            numberChecks = walkers.Count;
            for (int i = 0; i < numberChecks; i++)
            {
                if (Random.value < walkerSpawnChance && walkers.Count < maxWalkers)
                {
                    walker newWalker = new walker();
                    newWalker.dir = RandomDirection();
                    newWalker.pos = walkers[i].pos;
                    walkers.Add(newWalker);
                }
            }

            for (int i = 0; i < walkers.Count; i++)
            {
                walker thisWalker = walkers[i];
                thisWalker.pos += thisWalker.dir;
                walkers[i] = thisWalker;
            }

            for (int i = 0; i < walkers.Count; i++)
            {
                walker thisWalker = walkers[i];
                thisWalker.pos.x = Mathf.Clamp(thisWalker.pos.x, 1, roomWidth - 2);
                thisWalker.pos.y = Mathf.Clamp(thisWalker.pos.y, 1, roomHeight - 2);
                walkers[i] = thisWalker;
            }

            if ((float)NumberOfFloors() / (float)grid.Length > percentToFill)
            {
                break;
            }
            iterations++;
        } while (iterations < 100000);
    }

    void SpawnLevel()
    {
        for (int x = 0; x < roomWidth; x++)
        {
            for (int y = 0; y < roomHeight; y++)
            {
                switch (grid[x, y])
                {
                    case gridSpace.empty:
                        //Spawn(x, y, wallObj);
                        break;
                    case gridSpace.floor:
                        Spawn(x, y, floorObj);
                        break;
                    case gridSpace.wall:
                        Spawn(x, y, wallObj);
                        break;
                }
            }
        }
    }

    void Spawn(float x, float y, GameObject Spawn)
    {
        Vector2 offset = roomSizeWorldUnits / 2f;
        Vector2 spawnPos = new Vector2(x, y) * worldUnitsInOneGridCell - offset;

        if (Spawn == wallObj)
        {
            var whatIsSpawned = Instantiate(Spawn, spawnPos, Quaternion.identity);
            whatIsSpawned.transform.parent = wallHolder.transform;
        }
        else
        {
            var whatIsSpawned = Instantiate(Spawn, spawnPos, Quaternion.identity);
            whatIsSpawned.transform.parent = this.gameObject.transform;
        }
    }

    void CreateWalls()
    {
        for (int x = 0; x < roomWidth - 1; x++)
        {
            for (int y = 0; y < roomHeight - 1; y++)
            {
                if (grid[x, y] == gridSpace.floor)
                {
                    if (grid[x, y + 1] == gridSpace.empty)
                    {
                        grid[x, y + 1] = gridSpace.wall;
                    }
                    if (grid[x, y - 1] == gridSpace.empty)
                    {
                        grid[x, y - 1] = gridSpace.wall;
                    }
                    if (grid[x + 1, y] == gridSpace.empty)
                    {
                        grid[x + 1, y] = gridSpace.wall;
                    }
                    if (grid[x - 1, y] == gridSpace.empty)
                    {
                        grid[x - 1, y] = gridSpace.wall;
                    }
                }
            }
        }
    }

    Vector2 RandomDirection()
    {
        int choice = Mathf.FloorToInt(Random.value * 3.99f);

        switch (choice)
        {
            case 0:
                return Vector2.down;
            case 1:
                return Vector2.left;
            case 2:
                return Vector2.up;
            default:
                return Vector2.right;
        }
    }

    int NumberOfFloors()
    {
        int count = 0;
        foreach (gridSpace space in grid)
        {
            if (space == gridSpace.floor)
            {
                count++;
            }
        }
        return count;
    }

}
