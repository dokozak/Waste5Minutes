using UnityEngine;

public class BigPieceScript : MonoBehaviour
{
    public GameObject[] pieces;

    public void CheckWalls()
    {
        if (!Physics.Raycast(new Vector3(pieces[0].transform.position.x,0, pieces[0].transform.position.z), -pieces[0].transform.forward, 6, LayerMask.GetMask("Default")))
            pieces[0].SetActive(true);
        else
            pieces[0].SetActive(false);
        
        if (!Physics.Raycast(new Vector3(pieces[1].transform.position.x, 0, pieces[1].transform.position.z), pieces[1].transform.forward, 6, LayerMask.GetMask("Default")))
            pieces[1].SetActive(true);
        else
            pieces[1].SetActive(false);

        if (!Physics.Raycast(new Vector3(pieces[2].transform.position.x, 0, pieces[2].transform.position.z), -pieces[2].transform.forward, 6, LayerMask.GetMask("Default")))
            pieces[2].SetActive(true);
        else
            pieces[2].SetActive(false);

        if (!Physics.Raycast(new Vector3(pieces[3].transform.position.x, 0, pieces[3].transform.position.z), pieces[3].transform.forward, 6, LayerMask.GetMask("Default")))
            pieces[3].SetActive(true);
        else
            pieces[3].SetActive(false);
    }
}
