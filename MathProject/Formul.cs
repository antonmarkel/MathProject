

using System;
using System.Collections.Generic;


namespace MathProject
{
    class Formul
    { 
        static Random random = new Random();
        static List<Formul> ALL_FORMULS;
        public string Name { get; private set; }
        public string Definition { get; private set; }

        public static Formul[] generate_arr(int capacity) {
            #region first_setup
            if (ALL_FORMULS == null) ALL_FORMULS = INIT.UPLOAD_FORMULS();
            #endregion



            Formul[] arrFormuls = new Formul[capacity];
            int[] arrIndexes = new int[capacity];
            int index = 0;
            while(index != capacity)
            {
                int possibleindex = random.Next(0, ALL_FORMULS.Count);
                bool taken = true;
                for(int i = 0;i < index; i++)
                {
                    if (arrIndexes[i] == possibleindex) {
                        taken = false;break;     
                    }
                }
                if (taken) { arrFormuls[index] = ALL_FORMULS[possibleindex]; index++; }
            }

            return arrFormuls;
        }
        public Formul(string name, string definition)
        {
            Name = name;
            Definition = definition;
        }
    }
}
