using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CharacterControllerMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform targetedPuzzle;
    private Ray itemSelected;//Did we hit something
    private RaycastHit hitItem;//Allows us store what we hit
    private bool puzzleClicked;
    private bool pieceClicked;
    public Texture2D defaultCursorTexture;
    public Texture2D interactableCursorTexture;
    private Piece pieceSelected;
    private Vector3 piecePosition;
    private bool mapsShown = false;
    [SerializeField] private Image inventoryImage;
    //[SerializeField] private GameObject maps;
    [SerializeField] private Maps mapsScript;
    public Inventory inventoryItem;
    public DayRoomDoor dayRoomDoor;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (defaultCursorTexture)
            Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
        //mapsScript = maps.GetComponent<Maps>();
        //int testing = 0;
    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown("escape"))
        {
            //TODO This will eventually change to a pause menu which will then be able to take you to main menu
            SceneManager.LoadScene(0);
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Time.timeScale == 1)
        {
            if (Physics.Raycast(ray, out hit, 25))
            {
                if (hit.collider.CompareTag("Puzzle") || hit.collider.CompareTag("Piece"))
                {
                    if (interactableCursorTexture)
                        Cursor.SetCursor(interactableCursorTexture, Vector2.zero, CursorMode.Auto);
                }
                else
                {
                    if (defaultCursorTexture)
                        Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                //out hit allows us to get more information about what we hit by passig it by reference
                if (Physics.Raycast(ray, out hit, 25))
                {
                    if (hit.collider.CompareTag("Puzzle"))
                    {
                        targetedPuzzle = hit.transform;
                        puzzleClicked = true;
                        Puzzle puzzleSelected = hit.collider.GetComponent<Puzzle>();
                        if (puzzleSelected)
                        {
                            puzzleSelected.puzzleActivated = true;
                            puzzleSelected.OpenPuzzle();
                            MovementController(false);
                        }

                    }
                    else if (hit.collider.CompareTag("Piece"))
                    {
                        pieceClicked = true;
                        pieceSelected = hit.collider.GetComponent<Piece>();
                        if (pieceSelected)
                        {
                            pieceSelected.found = true;
                            inventoryItem.addItemToInventory(pieceSelected.imageMat, pieceSelected.pieceName);
                            if (pieceSelected.pieceName == "KeyE")
                                dayRoomDoor.keyFound = true;
                            pieceSelected.DestroyGameObj();
                           
                            pieceSelected.enabled = false;
                            inventoryItem.showNewItem();
                        }
                    }
                    else if(hit.collider.CompareTag("DayRoomDoor"))
                    {
                        dayRoomDoor.openDoors();
                    }
                    else
                    {
                        puzzleClicked = false;
                        pieceClicked = false;
                        navMeshAgent.destination = hit.point;
                        navMeshAgent.isStopped = false;//Tried find path to that location
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //Display/Hide Inventory
            if(inventoryImage.enabled)
                inventoryItem.disableInventory();
            else
                inventoryItem.enableInventory();
            //inventoryImage.enabled = !inventoryImage.enabled;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            //Display/Hide Pause Menu
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            mapsShown = !mapsShown;
            if (mapsShown)
            {
                mapsScript.DisplayMaps(navMeshAgent.transform.position.y);
                MovementController(false);
                //Time.timeScale = 0;
            }
            else
            {
                mapsScript.HideMaps();
                MovementController(true);
                //Time.timeScale = 1;
            }
                
        }
    }
    public void MovementController(bool enableVal)
    {
        if (enableVal)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }
}
