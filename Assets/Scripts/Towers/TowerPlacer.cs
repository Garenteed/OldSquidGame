using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    

    [SerializeField] private Transform _placeToPlaceTower;
    [SerializeField] private MMFeedbacks sound;
    private bool haveTower = false;
    private TowerSO towerSo;
    private PlayerInputs playerInputs;

    private void Start()
    {
        playerInputs = PlayerInputs.Instance;
        playerInputs.placeBuildingPerformed += PlayerInputs_placeBuildingPerformed;
    }

    private void PlayerInputs_placeBuildingPerformed(object sender, System.EventArgs e)
    {
        if(towerSo != null)
        {
            foreach (Transform child in _placeToPlaceTower)
            {
                Destroy(child.gameObject);
            }

            haveTower = true;
            GameObject tower = Instantiate(towerSo.tower);
            tower.transform.parent = _placeToPlaceTower;
            tower.transform.localPosition = Vector3.zero;
            tower.GetComponent<Tower>().OnTowerDestroy += TowerPlacer_OnTowerDestroy;
            towerSo = null;
            sound.PlayFeedbacks();

        }
    }

    private void TowerPlacer_OnTowerDestroy(object sender, System.EventArgs e)
    {
        haveTower = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (haveTower) return;
        if(collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            
            towerSo = player.GetTowerSO();
            if(towerSo != null)
            {
                player.SetPlacer(this);
                GameObject preview = Instantiate(towerSo.towerPreview);
                preview.transform.parent = _placeToPlaceTower;
                preview.transform.localPosition = Vector3.zero;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (haveTower) return;
        
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            towerSo = null;
            player.DeletePlacer();
            foreach (Transform child in _placeToPlaceTower)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
