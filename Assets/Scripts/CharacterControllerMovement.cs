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
    [SerializeField] private Image inventoryImage;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //Camera camera = GetComponent<Camera>();
        //navMeshAgent.Warp(camera.transform.position);
        if (defaultCursorTexture)
            Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
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
        if (Physics.Raycast(ray, out hit, 1000))
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
            if (Physics.Raycast(ray, out hit, 100))
            {
                if(hit.collider.CompareTag("Puzzle"))
                {
                    targetedPuzzle = hit.transform;
                    puzzleClicked = true;
                    Puzzle puzzleSelected = hit.collider.GetComponent<Puzzle>();
                    if(puzzleSelected)
                    {
                        navMeshAgent.destination = puzzleSelected.GetTransform().position;
                        transform.rotation = puzzleSelected.positionObject.transform.rotation;
                        puzzleSelected.puzzleActivated = true;
                    }
                    
                }
                else if (hit.collider.CompareTag("Piece"))
                {
                    pieceClicked = true;
                    navMeshAgent.destination = hit.point;
                    piecePosition = hit.point;
                    pieceSelected = hit.collider.GetComponent<Piece>();
                    if (pieceSelected)
                    {
                        pieceSelected.found = true;

                    }
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
        else if (Input.GetKeyDown(KeyCode.I))
        {
            //Display/Hide Inventory
            inventoryImage.enabled = !inventoryImage.enabled;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            //Display/Hide Pause Menu
        }
    }
}
