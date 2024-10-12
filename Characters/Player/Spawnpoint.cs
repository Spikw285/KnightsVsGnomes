using UnityEngine;
using UnityEngine.SceneManagement;
{
    // when currentHP will be equal to 0, it will envoke the Respawn method
    
// current logic of respawn 
    void Respawn() {
        // giving player it's max hp
        currentHP = maxHP;
        // moving player to spawn point
        transform.position = spawnPoint.position;
        Debug.Log("Player has spawned on Spawnpoint");
        ReloadLevel()
    }
    void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Level has been reloaded");
    }
}
