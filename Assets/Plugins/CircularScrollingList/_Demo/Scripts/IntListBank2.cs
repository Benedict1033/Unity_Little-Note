using System;
using UnityEngine;

namespace AirFishLab.ScrollingList.Demo
{
    public class IntListBank2 : BaseListBank
    {
        public static int[] a = new int[12];

        int aa = 1;

        private void Awake()
        {
            a[0] = DateTime.Now.Month;

            for (int j = DateTime.Now.Month-1; j >= 1; j--)
            {

                a[aa] = j;
                aa++;
            }
            for (int i = 12; i > DateTime.Now.Month; i--)
            {

                a[aa] = i;
                aa++;
            }

            Array.Copy(a, _contents, 12);
        }

        public  int[] _contents;

        public override object GetListContent(int index)
        {
            return _contents[index];
        }

        public override int GetListLength()
        {
            return _contents.Length;
        }
    }
}
