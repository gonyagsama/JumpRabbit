using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Awake()
    {
        player.init();
    }
}
