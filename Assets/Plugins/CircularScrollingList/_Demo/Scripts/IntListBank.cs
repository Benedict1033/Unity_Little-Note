using System;
using UnityEngine;

namespace AirFishLab.ScrollingList.Demo
{
    public class IntListBank : BaseListBank
    {
        public static int[] a = new int[31];

        int aa = 1;



        private void Awake()
        {
            a[0] = DateTime.Now.Day;

            for (int j = DateTime.Now.Day - 1; j >= 1; j--)
            {
                a[aa] = j;
                aa++;
            }
            for (int i = 31; i > DateTime.Now.Day; i--)
            {
                a[aa] = i;
                aa++;
            }

            Array.Copy(a, _contents, 31);
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
