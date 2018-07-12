using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class SearchController : MonoBehaviour,ISearch {

    IntReactiveProperty searchCount = new IntReactiveProperty(0);
    int thisPlayerNo;
    private void Start()
    {
       if(this.gameObject.transform.parent.gameObject.tag == "Player1") { thisPlayerNo = 1; }
        if (this.gameObject.transform.parent.gameObject.tag == "Player2") { thisPlayerNo = 2; }

        GameManager.PPlayerTurn
            .Where(x => x != thisPlayerNo)
            .Subscribe(_ => searchCount.Value--);

        searchCount
            .Where(x => x >= 0)
            .Subscribe(_ => {
                this.gameObject.layer = this.gameObject.transform.parent.gameObject.layer;
                LayerChange();
            });
    }

    public void Searched(int Searchcount)
    {
        searchCount.Value =  Searchcount;
        this.gameObject.layer = 11;
        LayerChange();
    }
	
    private void LayerChange()
    {
        LayerController layerController = gameObject.AddComponent<LayerController>();
        layerController.SetLayer(this.gameObject, this.gameObject);
        Destroy(layerController);
    }
}
