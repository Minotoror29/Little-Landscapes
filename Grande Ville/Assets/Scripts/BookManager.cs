using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> pages;
    private int _currentPage;

    public void Initialize()
    {
        pages[_currentPage].SetActive(false);
        _currentPage = 0;
        pages[_currentPage].SetActive(true);
    }

    public void PreviousPage()
    {
        pages[_currentPage].SetActive(false);
        _currentPage--;
        pages[_currentPage].SetActive(true);
    }

    public void NextPage()
    {
        pages[_currentPage].SetActive(false);
        _currentPage++;
        pages[_currentPage].SetActive(true);
    }
}
