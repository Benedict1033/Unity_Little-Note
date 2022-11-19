using System;
using UnityEngine;

namespace AirFishLab.ScrollingList.Demo
{
    public class IntListBank1 : BaseListBank
    {
        public static int[] a = new int[12];

        int aa = 1;

        private void Awake()
        {
            a[0] = DateTime.Now.Year;

            for (int j = DateTime.Now.Year-1; j >= 2021; j--)
            {

                a[aa] = j;
                aa++;
            }
            for (int i = 2025; i > DateTime.Now.Year; i--)
            {

                a[aa] = i;
                aa++;
            }

            Array.Copy(a, _contents, 5);
        }

        public int[] _contents;

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
