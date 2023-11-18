using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class boxScript : MonoBehaviour
{
    public bool locked = false;
    public int number = 2;
    public Text text;
    public Material[] mats;
    public int[] numbers;
    public int coords;
    private bool interpolating = false;
    private bool interpolatingDel = false;
    private bool growing = false;
    private Vector3 preVec;
    private Vector3 targetVec;
    private GameObject targetObj;
    private float lerpNum = -1;
    private float lerpNum2 = -1;
    public int interpSpeed;
    public Renderer rend;
    private Vector3 fullSize;
    private Color preCol;
    private int pastNumber = 2;
    private bool changingColour = false;

    private void Awake()
    {
        fullSize = new Vector3(0.001561947f, 0.001561947f, 0.001561947f);
        lerpNum = 0;
        growing = true;
        coords = (10 * (int)transform.position.x) + (int)transform.position.y;
        name = "BOX " + coords.ToString();
        pastNumber = 2;
    }

    private void Start()
    {
        Refresh();
    }

    public void Refresh() {
        text.text = number.ToString();
        if (number >= 2048) {
            GameObject.Find("Main Camera").GetComponent<boxManager>().win();
        }
        if (pastNumber != number)
        {
            if (number >= 64) {
                text.fontSize = 300 - (number.ToString().Length * 28);
            }
            pastNumber = number;
            preCol = rend.material.color;
            lerpNum2 = 0;
            changingColour = true;
        }
    }

    public void Move(Vector3 pos) {
        interpTo(pos);
    }

    public void delete(GameObject nextPos) {
        interpToDel(nextPos);
    }

    private void interpTo(Vector3 pos) {
        coords = (10 * (int)pos.x) + (int)pos.y;
        targetVec = pos;
        lerpNum = 0;
        preVec = transform.position;
        interpolating = true;
    }

    private void interpToDel(GameObject pos)
    {
        coords = 00;
        lerpNum = 0;
        preVec = transform.position;
        targetObj = pos;
        preCol = rend.material.color;
        text.enabled = false;
        interpolatingDel = true;
    }

    private void Update()
    {
        if (changingColour) {
            if (lerpNum2 <= 1 && lerpNum2 != -1)
            {
                rend.material.color = Color.Lerp(preCol, mats[Array.IndexOf(numbers, number)].color, lerpNum2);
                lerpNum2 += interpSpeed * Time.deltaTime;
            }
            else {
                lerpNum2 = -1;
                changingColour = false;
                rend.material = mats[Array.IndexOf(numbers, number)];
            }
        }
        if (interpolatingDel) {
            if (lerpNum <= 1 && lerpNum != -1)
            {
                transform.position = Vector3.Lerp(preVec, (targetObj.transform.position + new Vector3(0, 0, 0.1f)), lerpNum);
                rend.material.color = Color.Lerp(preCol, targetObj.GetComponent<boxScript>().rend.material.color, lerpNum);
                lerpNum += interpSpeed * Time.deltaTime;
            }
            else {
                lerpNum = -1;
                interpolatingDel = false;
                transform.position = targetObj.transform.position;
                Destroy(gameObject);
            }
        }
        if (interpolating) {
            if (lerpNum <= 1 && lerpNum != -1) {
                transform.position = Vector3.Lerp(preVec, targetVec, lerpNum);
                lerpNum += interpSpeed * Time.deltaTime;
            } else {
                interpolating = false;
                lerpNum = -1;
                transform.position = targetVec;
            }
        }
        if (growing) {
            if (lerpNum <= 1 && lerpNum != -1) {
                rend.gameObject.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), fullSize, lerpNum);
                lerpNum += interpSpeed * Time.deltaTime;
            }
            else {
                growing = false;
                rend.gameObject.transform.localScale = fullSize;
                lerpNum = -1;
            }
        }
    }
}