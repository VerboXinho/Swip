using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject tBox;
    public float power = 10f;
    public float maxDrag = 5f;
    public GameObject ball;
    public Rigidbody2D rb;
    public LineRenderer lr;
    [SerializeField]private int currentLevel;
    public TextMeshProUGUI levelText;
    Vector3 clampedForce;
    Vector3 dragStartPos;
    Touch touch;
    [SerializeField] bool isMoving = true;

    private void Start()
    {
        StartCoroutine(WaitForMove());
        tBox.SetActive(false);
        levelText.text = "" + currentLevel;
    }
    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(2);
        isMoving = false;
    }
    private void Update()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (!isMoving)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    DragStart();
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    Dragging();
                }


                if (touch.phase == TouchPhase.Ended)
                {
                    DragRelease();
                }
            }
        }
    }

    void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }
    void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
    }
    void DragRelease()
    {
        lr.positionCount = 0;

        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;

        Vector3 force = dragStartPos - dragReleasePos;
        clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
        isMoving = true;
    }
    // Nazwaæ potem GoToMenu
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
