using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxManager : MonoBehaviour
{
    public GameObject boxPrefab;
    bool gameRunning = true;
    public GameObject winScreen;
    public GameObject loseScreen;
    bool losing = false;

    public Text scoreText;
    public Text bestScoreText;
    private int score;
    private int bestScore;

    private Vector2 startPos;
    private Vector2 endPos;
    private bool doneTouch = true;

    private void Start()
    {
        generateNewBox(true);
        generateNewBox(true);
    }

    void Update()
    {
        if (gameRunning)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                up();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                down();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                right();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                left();
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    doneTouch = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    if (doneTouch == false) {
                        if (Vector2.Distance(startPos, touch.position) > 10) {
                            doneTouch = true;
                            endPos = touch.position;
                            float xDeviation = Mathf.Abs(startPos.x - endPos.x);
                            float yDeviation = Mathf.Abs(startPos.y - endPos.y);
                            if (yDeviation > xDeviation && endPos.y > startPos.y)
                            { // up
                                up();
                            }
                            else if (yDeviation > xDeviation && endPos.y < startPos.y)
                            { // down
                                down();
                            }
                            else if (yDeviation < xDeviation && endPos.x > startPos.x)
                            { // right
                                right();
                            }
                            else if (yDeviation < xDeviation && endPos.x < startPos.x)
                            { // left
                                left();
                            }
                        }
                    }
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    doneTouch = true;
                    break;
            }
        }
    }

    public void up() {
        if (gameRunning)
        {
            //
            for (int firstColumn = 4; firstColumn >= 1; firstColumn -= 1)
            {
                if (GameObject.Find("BOX 1" + firstColumn.ToString()))
                {
                    GameObject box = GameObject.Find("BOX 1" + firstColumn.ToString());
                    box.GetComponent<boxScript>().locked = false;
                    if (firstColumn != 4)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (firstColumn < 4)
                        {
                            if (!GameObject.Find("BOX 14"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 4, box.transform.position.z));
                                box.name = "BOX 14";
                                GameObject.Find("BOX 14").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 14").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 14").GetComponent<boxScript>().locked == false && (firstColumn == 3 || (firstColumn == 2 && !GameObject.Find("BOX 13")) || (firstColumn == 1 && !GameObject.Find("BOX 13") && !GameObject.Find("BOX 12"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 14"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 14").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 14").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 14").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (firstColumn < 3)
                                {
                                    if (!GameObject.Find("BOX 13"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 3, box.transform.position.z));
                                        box.name = "BOX 13";
                                        GameObject.Find("BOX 13").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 13").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 13").GetComponent<boxScript>().locked == false && (firstColumn == 2 || (firstColumn == 1 && !GameObject.Find("BOX 12"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 13"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 13").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 13").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 13").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (firstColumn < 2)
                                        {
                                            if (!GameObject.Find("BOX 12"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 2, box.transform.position.z));
                                                box.name = "BOX 12";
                                                GameObject.Find("BOX 12").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 12").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 12").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 12"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 12").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 12").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 12").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                                //
                            }
                        }
                    }
                }
            }
            //
            //
            for (int secondColumn = 4; secondColumn >= 1; secondColumn -= 1)
            {
                if (GameObject.Find("BOX 2" + secondColumn.ToString()))
                {
                    GameObject box = GameObject.Find("BOX 2" + secondColumn.ToString());
                    box.GetComponent<boxScript>().locked = false;
                    if (secondColumn != 4)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (secondColumn < 4)
                        {
                            if (!GameObject.Find("BOX 24"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 4, box.transform.position.z));
                                box.name = "BOX 24";
                                GameObject.Find("BOX 24").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 24").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 24").GetComponent<boxScript>().locked == false && (secondColumn == 3 || (secondColumn == 2 && !GameObject.Find("BOX 23")) || (secondColumn == 1 && !GameObject.Find("BOX 23") && !GameObject.Find("BOX 22"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 24"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 24").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 24").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 24").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (secondColumn < 3)
                                {
                                    if (!GameObject.Find("BOX 23"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 3, box.transform.position.z));
                                        box.name = "BOX 23";
                                        GameObject.Find("BOX 23").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 23").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 23").GetComponent<boxScript>().locked == false && (secondColumn == 2 || (secondColumn == 1 && !GameObject.Find("BOX 22"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 23"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 23").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 23").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 23").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (secondColumn < 2)
                                        {
                                            if (!GameObject.Find("BOX 22"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 2, box.transform.position.z));
                                                box.name = "BOX 22";
                                                GameObject.Find("BOX 22").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 22").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 22").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 22"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 22").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 22").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 22").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                            //
                        }
                    }
                }
            }
            //
            //
            for (int thirdColumn = 4; thirdColumn >= 1; thirdColumn -= 1)
            {
                if (GameObject.Find("BOX 3" + thirdColumn.ToString()))
                {
                    GameObject box = GameObject.Find("BOX 3" + thirdColumn.ToString());
                    box.GetComponent<boxScript>().locked = false;
                    if (thirdColumn != 4)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (thirdColumn < 4)
                        {
                            if (!GameObject.Find("BOX 34"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 4, box.transform.position.z));
                                box.name = "BOX 34";
                                GameObject.Find("BOX 34").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 34").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 34").GetComponent<boxScript>().locked == false && (thirdColumn == 3 || (thirdColumn == 2 && !GameObject.Find("BOX 33")) || (thirdColumn == 1 && !GameObject.Find("BOX 33") && !GameObject.Find("BOX 32"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 34"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 34").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 34").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 34").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (thirdColumn < 3)
                                {
                                    if (!GameObject.Find("BOX 33"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 3, box.transform.position.z));
                                        box.name = "BOX 33";
                                        GameObject.Find("BOX 33").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 33").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 33").GetComponent<boxScript>().locked == false && (thirdColumn == 2 || (thirdColumn == 1 && !GameObject.Find("BOX 32"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 33"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 33").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 33").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 33").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (thirdColumn < 2)
                                        {
                                            if (!GameObject.Find("BOX 32"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 2, box.transform.position.z));
                                                box.name = "BOX 32";
                                                GameObject.Find("BOX 32").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 32").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 32").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 32"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 32").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 32").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 32").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //
            //
            for (int fourthColumn = 4; fourthColumn >= 1; fourthColumn -= 1)
            {
                if (GameObject.Find("BOX 4" + fourthColumn.ToString()))
                {
                    GameObject box = GameObject.Find("BOX 4" + fourthColumn.ToString());
                    box.GetComponent<boxScript>().locked = false;
                    if (fourthColumn != 4)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (fourthColumn < 4)
                        {
                            if (!GameObject.Find("BOX 44"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 4, box.transform.position.z));
                                box.name = "BOX 44";
                                GameObject.Find("BOX 44").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 44").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 44").GetComponent<boxScript>().locked == false && (fourthColumn == 3 || (fourthColumn == 2 && !GameObject.Find("BOX 43")) || (fourthColumn == 1 && !GameObject.Find("BOX 43") && !GameObject.Find("BOX 42"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 44"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 44").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 44").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 44").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (fourthColumn < 3)
                                {
                                    if (!GameObject.Find("BOX 43"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 3, box.transform.position.z));
                                        box.name = "BOX 43";
                                        GameObject.Find("BOX 43").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 43").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 43").GetComponent<boxScript>().locked == false && (fourthColumn == 2 || (fourthColumn == 1 && !GameObject.Find("BOX 42"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 43"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 43").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 43").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 43").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (fourthColumn < 2)
                                        {
                                            if (!GameObject.Find("BOX 42"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 2, box.transform.position.z));
                                                box.name = "BOX 42";
                                                GameObject.Find("BOX 42").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 42").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 42").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 42"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 42").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 42").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 42").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //

            generateNewBox(true);
        }
    }
    public void down() {
        if (gameRunning)
        {
            //
            for (int firstColumn = 1; firstColumn <= 4; firstColumn += 1)
            {
                if (GameObject.Find("BOX 1" + firstColumn.ToString()))
                {
                    GameObject box = GameObject.Find("BOX 1" + firstColumn.ToString());
                    box.GetComponent<boxScript>().locked = false;
                    if (firstColumn != 1)  // IF NOT AT BOTTOM ALREADY
                    {
                        // BOX MOVE DOWN
                        if (firstColumn > 1)
                        {
                            if (!GameObject.Find("BOX 11"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 1, box.transform.position.z));
                                box.name = "BOX 11";
                                GameObject.Find("BOX 11").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 11").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 11").GetComponent<boxScript>().locked == false && (firstColumn == 2 || (firstColumn == 3 && !GameObject.Find("BOX 12")) || (firstColumn == 4 && !GameObject.Find("BOX 12") && !GameObject.Find("BOX 13"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 11"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 11").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 11").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 11").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (firstColumn > 2)
                                {
                                    if (!GameObject.Find("BOX 12"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 2, box.transform.position.z));
                                        box.name = "BOX 12";
                                        GameObject.Find("BOX 12").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 12").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 12").GetComponent<boxScript>().locked == false && (firstColumn == 3 || (firstColumn == 4 && !GameObject.Find("BOX 13"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 12"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 12").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 12").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 12").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (firstColumn > 3)
                                        {
                                            if (!GameObject.Find("BOX 13"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 3, box.transform.position.z));
                                                box.name = "BOX 13";
                                                GameObject.Find("BOX 13").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 13").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 13").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 13"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 13").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 13").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 13").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //
            //
            for (int secondColumn = 1; secondColumn <= 4; secondColumn += 1)
            {
                if (GameObject.Find("BOX 2" + secondColumn.ToString()))
                {
                    GameObject box = GameObject.Find("BOX 2" + secondColumn.ToString());
                    box.GetComponent<boxScript>().locked = false;
                    if (secondColumn != 1)  // IF NOT AT BOTTOM ALREADY
                    {
                        // BOX MOVE DOWN
                        if (secondColumn > 1)
                        {
                            if (!GameObject.Find("BOX 21"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 1, box.transform.position.z));
                                box.name = "BOX 21";
                                GameObject.Find("BOX 21").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 21").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 21").GetComponent<boxScript>().locked == false && (secondColumn == 2 || (secondColumn == 3 && !GameObject.Find("BOX 22")) || (secondColumn == 4 && !GameObject.Find("BOX 22") && !GameObject.Find("BOX 23"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 21"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 21").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 21").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 21").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (secondColumn > 2)
                                {
                                    if (!GameObject.Find("BOX 22"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 2, box.transform.position.z));
                                        box.name = "BOX 22";
                                        GameObject.Find("BOX 22").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 22").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 22").GetComponent<boxScript>().locked == false && (secondColumn == 3 || (secondColumn == 4 && !GameObject.Find("BOX 23"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 22"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 22").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 22").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 22").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (secondColumn > 3)
                                        {
                                            if (!GameObject.Find("BOX 23"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 3, box.transform.position.z));
                                                box.name = "BOX 23";
                                                GameObject.Find("BOX 23").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 23").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 23").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 23"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 23").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 23").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 23").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //
            //
            for (int thirdColumn = 1; thirdColumn <= 4; thirdColumn += 1)
            {
                if (GameObject.Find("BOX 3" + thirdColumn.ToString()))
                {
                    GameObject box = GameObject.Find("BOX 3" + thirdColumn.ToString());
                    box.GetComponent<boxScript>().locked = false;
                    if (thirdColumn != 1)  // IF NOT AT BOTTOM ALREADY
                    {
                        // BOX MOVE DOWN
                        if (thirdColumn > 1)
                        {
                            if (!GameObject.Find("BOX 31"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 1, box.transform.position.z));
                                box.name = "BOX 31";
                                GameObject.Find("BOX 31").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 31").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 31").GetComponent<boxScript>().locked == false && (thirdColumn == 2 || (thirdColumn == 3 && !GameObject.Find("BOX 32")) || (thirdColumn == 4 && !GameObject.Find("BOX 32") && !GameObject.Find("BOX 33"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 31"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 31").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 31").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 31").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (thirdColumn > 2)
                                {
                                    if (!GameObject.Find("BOX 32"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 2, box.transform.position.z));
                                        box.name = "BOX 32";
                                        GameObject.Find("BOX 32").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 32").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 32").GetComponent<boxScript>().locked == false && (thirdColumn == 3 || (thirdColumn == 4 && !GameObject.Find("BOX 33"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 32"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 32").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 32").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 32").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (thirdColumn > 3)
                                        {
                                            if (!GameObject.Find("BOX 33"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 3, box.transform.position.z));
                                                box.name = "BOX 33";
                                                GameObject.Find("BOX 33").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 33").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 33").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 33"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 33").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 33").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 33").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //
            //
            for (int fourthColumn = 1; fourthColumn <= 4; fourthColumn += 1)
            {
                if (GameObject.Find("BOX 4" + fourthColumn.ToString()))
                {
                    GameObject box = GameObject.Find("BOX 4" + fourthColumn.ToString());
                    box.GetComponent<boxScript>().locked = false;
                    if (fourthColumn != 1)  // IF NOT AT BOTTOM ALREADY
                    {
                        // BOX MOVE DOWN
                        if (fourthColumn > 1)
                        {
                            if (!GameObject.Find("BOX 41"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 1, box.transform.position.z));
                                box.name = "BOX 41";
                                GameObject.Find("BOX 41").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 41").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 41").GetComponent<boxScript>().locked == false && (fourthColumn == 2 || (fourthColumn == 3 && !GameObject.Find("BOX 42")) || (fourthColumn == 4 && !GameObject.Find("BOX 42") && !GameObject.Find("BOX 43"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 41"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 41").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 41").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 41").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (fourthColumn > 2)
                                {
                                    if (!GameObject.Find("BOX 42"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 2, box.transform.position.z));
                                        box.name = "BOX 42";
                                        GameObject.Find("BOX 42").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 42").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 42").GetComponent<boxScript>().locked == false && (fourthColumn == 3 || (fourthColumn == 4 && !GameObject.Find("BOX 43"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 42"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 42").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 42").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 42").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (fourthColumn > 3)
                                        {
                                            if (!GameObject.Find("BOX 43"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(box.transform.position.x, 3, box.transform.position.z));
                                                box.name = "BOX 43";
                                                GameObject.Find("BOX 43").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 43").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 43").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 43"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 43").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 43").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 43").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //

            generateNewBox(true);
        }
    }
    public void right() {
        if (gameRunning)
        {
            //
            for (int firstColumn = 4; firstColumn >= 1; firstColumn -= 1)
            {
                if (GameObject.Find("BOX " + firstColumn.ToString() + "1"))
                {
                    GameObject box = GameObject.Find("BOX " + firstColumn.ToString() + "1");
                    box.GetComponent<boxScript>().locked = false;
                    if (firstColumn != 4)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (firstColumn < 4)
                        {
                            if (!GameObject.Find("BOX 41"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(4, box.transform.position.y, box.transform.position.z));
                                box.name = "BOX 41";
                                GameObject.Find("BOX 41").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 41").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 41").GetComponent<boxScript>().locked == false && (firstColumn == 3 || (firstColumn == 2 && !GameObject.Find("BOX 31")) || (firstColumn == 1 && !GameObject.Find("BOX 21") && !GameObject.Find("BOX 31"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 41"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 41").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 41").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 41").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (firstColumn < 3)
                                {
                                    if (!GameObject.Find("BOX 31"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(3, box.transform.position.y, box.transform.position.z));
                                        box.name = "BOX 31";
                                        GameObject.Find("BOX 31").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 31").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 31").GetComponent<boxScript>().locked == false && (firstColumn == 2 || (firstColumn == 1 && !GameObject.Find("BOX 21"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 31"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 31").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 31").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 31").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (firstColumn < 2)
                                        {
                                            if (!GameObject.Find("BOX 21"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(2, box.transform.position.y, box.transform.position.z));
                                                box.name = "BOX 21";
                                                GameObject.Find("BOX 21").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 21").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 21").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 21"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 21").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 21").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 21").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //
            //
            for (int secondColumn = 4; secondColumn >= 1; secondColumn -= 1)
            {
                if (GameObject.Find("BOX " + secondColumn.ToString() + "2"))
                {
                    GameObject box = GameObject.Find("BOX " + secondColumn.ToString() + "2");
                    box.GetComponent<boxScript>().locked = false;
                    if (secondColumn != 4)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (secondColumn < 4)
                        {
                            if (!GameObject.Find("BOX 42"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(4, box.transform.position.y, box.transform.position.z));
                                box.name = "BOX 42";
                                GameObject.Find("BOX 42").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 42").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 42").GetComponent<boxScript>().locked == false && (secondColumn == 3 || (secondColumn == 2 && !GameObject.Find("BOX 32")) || (secondColumn == 1 && !GameObject.Find("BOX 22") && !GameObject.Find("BOX 32"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 42"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 42").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 42").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 42").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (secondColumn < 3)
                                {
                                    if (!GameObject.Find("BOX 32"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(3, box.transform.position.y, box.transform.position.z));
                                        box.name = "BOX 32";
                                        GameObject.Find("BOX 32").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 32").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 32").GetComponent<boxScript>().locked == false && (secondColumn == 2 || (secondColumn == 1 && !GameObject.Find("BOX 22"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 32"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 32").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 32").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 32").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (secondColumn < 2)
                                        {
                                            if (!GameObject.Find("BOX 22"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(2, box.transform.position.y, box.transform.position.z));
                                                box.name = "BOX 22";
                                                GameObject.Find("BOX 22").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 22").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 22").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 22"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 22").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 22").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 22").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //
            //
            for (int thirdColumn = 4; thirdColumn >= 1; thirdColumn -= 1)
            {
                if (GameObject.Find("BOX " + thirdColumn.ToString() + "3"))
                {
                    GameObject box = GameObject.Find("BOX " + thirdColumn.ToString() + "3");
                    box.GetComponent<boxScript>().locked = false;
                    if (thirdColumn != 4)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (thirdColumn < 4)
                        {
                            if (!GameObject.Find("BOX 43"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(4, box.transform.position.y, box.transform.position.z));
                                box.name = "BOX 43";
                                GameObject.Find("BOX 43").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 43").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 43").GetComponent<boxScript>().locked == false && (thirdColumn == 3 || (thirdColumn == 2 && !GameObject.Find("BOX 33")) || (thirdColumn == 1 && !GameObject.Find("BOX 23") && !GameObject.Find("BOX 33"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 43"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 43").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 43").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 43").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (thirdColumn < 3)
                                {
                                    if (!GameObject.Find("BOX 33"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(3, box.transform.position.y, box.transform.position.z));
                                        box.name = "BOX 33";
                                        GameObject.Find("BOX 33").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 33").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 33").GetComponent<boxScript>().locked == false && (thirdColumn == 2 || (thirdColumn == 1 && !GameObject.Find("BOX 23"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 33"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 33").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 33").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 33").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (thirdColumn < 2)
                                        {
                                            if (!GameObject.Find("BOX 23"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(2, box.transform.position.y, box.transform.position.z));
                                                box.name = "BOX 23";
                                                GameObject.Find("BOX 23").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 23").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 23").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 23"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 23").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 23").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 23").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //
            //
            for (int fourthColumn = 4; fourthColumn >= 1; fourthColumn -= 1)
            {
                if (GameObject.Find("BOX " + fourthColumn.ToString() + "4"))
                {
                    GameObject box = GameObject.Find("BOX " + fourthColumn.ToString() + "4");
                    box.GetComponent<boxScript>().locked = false;
                    if (fourthColumn != 4)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (fourthColumn < 4)
                        {
                            if (!GameObject.Find("BOX 44"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(4, box.transform.position.y, box.transform.position.z));
                                box.name = "BOX 44";
                                GameObject.Find("BOX 44").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 44").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 44").GetComponent<boxScript>().locked == false && (fourthColumn == 3 || (fourthColumn == 2 && !GameObject.Find("BOX 34")) || (fourthColumn == 1 && !GameObject.Find("BOX 24") && !GameObject.Find("BOX 34"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 44"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 44").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 44").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 44").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (fourthColumn < 3)
                                {
                                    if (!GameObject.Find("BOX 34"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(3, box.transform.position.y, box.transform.position.z));
                                        box.name = "BOX 34";
                                        GameObject.Find("BOX 34").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 34").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 34").GetComponent<boxScript>().locked == false && (fourthColumn == 2 || (fourthColumn == 1 && !GameObject.Find("BOX 24"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 34"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 34").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 34").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 34").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (fourthColumn < 2)
                                        {
                                            if (!GameObject.Find("BOX 24"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(2, box.transform.position.y, box.transform.position.z));
                                                box.name = "BOX 24";
                                                GameObject.Find("BOX 24").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 24").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 24").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 24"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 24").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 24").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 24").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                            //
                        }
                    }
                }
                //
            }
            //

            generateNewBox(true);
        }
    }
    public void left() {
        if (gameRunning)
        {
            //
            for (int firstColumn = 1; firstColumn <= 4; firstColumn += 1)
            {
                if (GameObject.Find("BOX " + firstColumn.ToString() + "1"))
                {
                    GameObject box = GameObject.Find("BOX " + firstColumn.ToString() + "1");
                    box.GetComponent<boxScript>().locked = false;
                    if (firstColumn != 1)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (firstColumn > 1)
                        {
                            if (!GameObject.Find("BOX 11"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(1, box.transform.position.y, box.transform.position.z));
                                box.name = "BOX 11";
                                GameObject.Find("BOX 11").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 11").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 11").GetComponent<boxScript>().locked == false && (firstColumn == 2 || (firstColumn == 3 && !GameObject.Find("BOX 21")) || (firstColumn == 4 && !GameObject.Find("BOX 21") && !GameObject.Find("BOX 31"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 11"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 11").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 11").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 11").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (firstColumn > 2)
                                {
                                    if (!GameObject.Find("BOX 21"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(2, box.transform.position.y, box.transform.position.z));
                                        box.name = "BOX 21";
                                        GameObject.Find("BOX 21").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 21").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 21").GetComponent<boxScript>().locked == false && (firstColumn == 3 || (firstColumn == 4 && !GameObject.Find("BOX 31"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 21"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 21").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 21").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 21").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (firstColumn > 3)
                                        {
                                            if (!GameObject.Find("BOX 31"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(3, box.transform.position.y, box.transform.position.z));
                                                box.name = "BOX 31";
                                                GameObject.Find("BOX 31").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 31").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 31").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 31"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 31").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 31").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 31").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //
            //
            for (int secondColumn = 1; secondColumn <= 4; secondColumn += 1)
            {
                if (GameObject.Find("BOX " + secondColumn.ToString() + "2"))
                {
                    GameObject box = GameObject.Find("BOX " + secondColumn.ToString() + "2");
                    box.GetComponent<boxScript>().locked = false;
                    if (secondColumn != 1)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (secondColumn > 1)
                        {
                            if (!GameObject.Find("BOX 12"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(1, box.transform.position.y, box.transform.position.z));
                                box.name = "BOX 12";
                                GameObject.Find("BOX 12").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 12").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 12").GetComponent<boxScript>().locked == false && (secondColumn == 2 || (secondColumn == 3 && !GameObject.Find("BOX 22")) || (secondColumn == 4 && !GameObject.Find("BOX 22") && !GameObject.Find("BOX 32"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 12"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 12").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 12").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 12").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (secondColumn > 2)
                                {
                                    if (!GameObject.Find("BOX 22"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(2, box.transform.position.y, box.transform.position.z));
                                        box.name = "BOX 22";
                                        GameObject.Find("BOX 22").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 22").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 22").GetComponent<boxScript>().locked == false && (secondColumn == 3 || (secondColumn == 4 && !GameObject.Find("BOX 32"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 22"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 22").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 22").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 22").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (secondColumn > 3)
                                        {
                                            if (!GameObject.Find("BOX 32"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(3, box.transform.position.y, box.transform.position.z));
                                                box.name = "BOX 32";
                                                GameObject.Find("BOX 32").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 32").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 32").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 32"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 32").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 32").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 32").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //
            //
            for (int thirdColumn = 1; thirdColumn <= 4; thirdColumn += 1)
            {
                if (GameObject.Find("BOX " + thirdColumn.ToString() + "3"))
                {
                    GameObject box = GameObject.Find("BOX " + thirdColumn.ToString() + "3");
                    box.GetComponent<boxScript>().locked = false;
                    if (thirdColumn != 1)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (thirdColumn > 1)
                        {
                            if (!GameObject.Find("BOX 13"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(1, box.transform.position.y, box.transform.position.z));
                                box.name = "BOX 13";
                                GameObject.Find("BOX 13").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 13").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 13").GetComponent<boxScript>().locked == false && (thirdColumn == 2 || (thirdColumn == 3 && !GameObject.Find("BOX 23")) || (thirdColumn == 4 && !GameObject.Find("BOX 23") && !GameObject.Find("BOX 33"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 13"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 13").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 13").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 13").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (thirdColumn > 2)
                                {
                                    if (!GameObject.Find("BOX 23"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(2, box.transform.position.y, box.transform.position.z));
                                        box.name = "BOX 23";
                                        GameObject.Find("BOX 23").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 23").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 23").GetComponent<boxScript>().locked == false && (thirdColumn == 3 || (thirdColumn == 4 && !GameObject.Find("BOX 33"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 23"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 23").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 23").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 23").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (thirdColumn > 3)
                                        {
                                            if (!GameObject.Find("BOX 33"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(3, box.transform.position.y, box.transform.position.z));
                                                box.name = "BOX 33";
                                                GameObject.Find("BOX 33").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 33").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 33").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 33"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 33").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 33").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 33").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //
            //
            for (int fourthColumn = 1; fourthColumn <= 4; fourthColumn += 1)
            {
                if (GameObject.Find("BOX " + fourthColumn.ToString() + "4"))
                {
                    GameObject box = GameObject.Find("BOX " + fourthColumn.ToString() + "4");
                    box.GetComponent<boxScript>().locked = false;
                    if (fourthColumn != 1)  // IF NOT AT TOP ALREADY
                    {
                        // BOX MOVE UP
                        if (fourthColumn > 1)
                        {
                            if (!GameObject.Find("BOX 14"))
                            {
                                box.GetComponent<boxScript>().Move(new Vector3(1, box.transform.position.y, box.transform.position.z));
                                box.name = "BOX 14";
                                GameObject.Find("BOX 14").GetComponent<boxScript>().Refresh();
                            }
                            else if ((GameObject.Find("BOX 14").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 14").GetComponent<boxScript>().locked == false && (fourthColumn == 2 || (fourthColumn == 3 && !GameObject.Find("BOX 24")) || (fourthColumn == 4 && !GameObject.Find("BOX 24") && !GameObject.Find("BOX 34"))))
                            {
                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 14"));
                                box.name = "DELETING";
                                GameObject.Find("BOX 14").GetComponent<boxScript>().number *= 2;
                                GameObject.Find("BOX 14").GetComponent<boxScript>().locked = true;
                                GameObject.Find("BOX 14").GetComponent<boxScript>().Refresh();
                            }
                            else
                            {
                                if (fourthColumn > 2)
                                {
                                    if (!GameObject.Find("BOX 24"))
                                    {
                                        box.GetComponent<boxScript>().Move(new Vector3(2, box.transform.position.y, box.transform.position.z));
                                        box.name = "BOX 24";
                                        GameObject.Find("BOX 24").GetComponent<boxScript>().Refresh();
                                    }
                                    else if ((GameObject.Find("BOX 24").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 24").GetComponent<boxScript>().locked == false && (fourthColumn == 3 || (fourthColumn == 4 && !GameObject.Find("BOX 34"))))
                                    {
                                        box.GetComponent<boxScript>().delete(GameObject.Find("BOX 24"));
                                        box.name = "DELETING";
                                        GameObject.Find("BOX 24").GetComponent<boxScript>().number *= 2;
                                        GameObject.Find("BOX 24").GetComponent<boxScript>().locked = true;
                                        GameObject.Find("BOX 24").GetComponent<boxScript>().Refresh();
                                    }
                                    else
                                    {
                                        if (fourthColumn > 3)
                                        {
                                            if (!GameObject.Find("BOX 34"))
                                            {
                                                box.GetComponent<boxScript>().Move(new Vector3(3, box.transform.position.y, box.transform.position.z));
                                                box.name = "BOX 34";
                                                GameObject.Find("BOX 34").GetComponent<boxScript>().Refresh();
                                            }
                                            else if ((GameObject.Find("BOX 34").GetComponent<boxScript>().number == box.GetComponent<boxScript>().number) && GameObject.Find("BOX 34").GetComponent<boxScript>().locked == false)
                                            {
                                                box.GetComponent<boxScript>().delete(GameObject.Find("BOX 34"));
                                                box.name = "DELETING";
                                                GameObject.Find("BOX 34").GetComponent<boxScript>().number *= 2;
                                                GameObject.Find("BOX 34").GetComponent<boxScript>().locked = true;
                                                GameObject.Find("BOX 34").GetComponent<boxScript>().Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                    }
                }
            }
            //

            generateNewBox(true);
        }
    }

    void generateNewBox(bool resetScore) {
        List<int> availablePositions = new List<int>();
        availablePositions.Add(11);
        availablePositions.Add(21);
        availablePositions.Add(31);
        availablePositions.Add(41);
        availablePositions.Add(12);
        availablePositions.Add(22);
        availablePositions.Add(32);
        availablePositions.Add(42);
        availablePositions.Add(13);
        availablePositions.Add(23);
        availablePositions.Add(33);
        availablePositions.Add(43);
        availablePositions.Add(14);
        availablePositions.Add(24);
        availablePositions.Add(34);
        availablePositions.Add(44);
        foreach (GameObject b in GameObject.FindGameObjectsWithTag("box"))
        {
            b.GetComponent<boxScript>().locked = false;
            availablePositions.Remove(b.GetComponent<boxScript>().coords);
        }
        if (availablePositions.Count == 0)
        {
            if (losing == false) {
                losing = true;
                print("ENDGAME");
                gameRunning = false;
                loseScreen.SetActive(true);
                GameObject.Find("endingsCanvas").GetComponent<Animation>().Play("loseScreenAppear");
                Invoke("hideLoseScreen", 2);
            }
        }
        else
        {
            print(availablePositions);
            int rand = Random.Range(0, availablePositions.Count);
            int posx = (int)char.GetNumericValue(availablePositions[rand].ToString()[0]);
            int posy = (int)char.GetNumericValue(availablePositions[rand].ToString()[1]);
            GameObject newBox = Instantiate(boxPrefab, new Vector3(posx, posy, 0), transform.rotation);
            newBox.GetComponent<boxScript>().Refresh();
        }
        // disable script to stop input while boxes are moving
        GetComponent<managerManagerScript>().pauseInput();
        // update score
        if (resetScore)
        {
            score = 0;
            foreach (GameObject a in GameObject.FindGameObjectsWithTag("box"))
            {
                if (a.name != "DELETING")
                {
                    score += a.GetComponent<boxScript>().number;
                }
            }
            if (score > bestScore)
            {
                bestScore = score;
            }
            scoreText.text = score.ToString();
            bestScoreText.text = bestScore.ToString();
        }
    }

    public void win() {
        print("ENDGAME");
        gameRunning = false;
        winScreen.SetActive(true);
        GameObject.Find("endingsCanvas").GetComponent<Animation>().Play("winScreenAppear");
    }
    private void hideWinScreen() {
        GameObject.Find("endingsCanvas").GetComponent<Animation>().Play("winScreenFade");
        Invoke("hideEndingsScreens", 0.35f);
    }
    private void hideLoseScreen() {
        GameObject.Find("endingsCanvas").GetComponent<Animation>().Play("loseScreenFade");
        Invoke("hideEndingsScreens", 0.35f);
        Invoke("unLose", 0.4f);
    }
    private void hideEndingsScreens() {
        foreach (GameObject b in GameObject.FindGameObjectsWithTag("box"))
        {
            Destroy(b);
        }
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        reset();
    }
    public void resetAfterWin() {
        hideWinScreen();
    }

    public void reset()
    {
        foreach (GameObject b in GameObject.FindGameObjectsWithTag("box"))
        {
            Destroy(b);
        }
        score = 4;
        scoreText.text = score.ToString();
        GetComponent<managerManagerScript>().pauseInput();
        gameRunning = true;
        generateNewBox(false);
        generateNewBox(false);
    }
    private void unLose() {
        losing = false;
        generateNewBox(false);
        generateNewBox(false);
    }
}