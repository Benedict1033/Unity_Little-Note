using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace AirFishLab.ScrollingList.Demo
{
    public class DisplayAndSelectExample1 : MonoBehaviour
    {
        [SerializeField]
        private CircularScrollingList _list;

        [SerializeField]
        private Text _centeredContentText;

        //public Text year;
        //public Text month;
        //public Text day;


        private string ssPath;
        private string snFileName;
        string[] files = null;

        //public void DisplayCenteredContent()
        //{
        //    var contentID = _list.GetCenteredContentID();
        //    var centeredContent = (int)_list.listBank.GetListContent(contentID);

        
        //}

        private void Update()
        {
            var contentID = _list.GetCenteredContentID();
            var centeredContent = (int)_list.listBank.GetListContent(contentID);
            _centeredContentText.text = "" + centeredContent;
        }

        public void GetSelectedContentID(int selectedContentID)
        {
            Debug.Log("Selected content ID: " + selectedContentID +
                      ", Content: " +
                      (int)_list.listBank.GetListContent(selectedContentID));
        }

        public void OnListCenteredContentChanged(int centeredContentID)
        {
            var content = (int)_list.listBank.GetListContent(centeredContentID);
            _centeredContentText.text = "" + content;
        }

        public void OnMovementEnd()
        {
            Debug.Log("Movement Ends");
        }


        public void hhihi()
        {
            string path = "sdcard/DCIM/LittleNote/" + "a" + ".txt";

            File.WriteAllText(path, "4124");

        }
    }

}
